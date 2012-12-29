using System.Web.Security;

namespace WindowsAzure.FunnyApp.Web.Manager
{
    using System;
    using System.IO;
    using System.Net;
    using System.Web.UI;
    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.StorageClient;

    using WindowsAzure.FunnyApp.Data;
    using WindowsAzure.FunnyApp.Common;
    using WindowsAzure.FunnyApp.Entities;

    public partial class ImageUploadPage : Page
    {
        private static readonly object _look = new object();
        private static bool _storageInitialized = false;
        private static CloudBlobClient _blobClient;
        private static CloudQueueClient _queueClient;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = "Image Uploads";
            if (IsPostBack) return;
            InitializeStorage();
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (FileUploadImage.HasFiles & Page.IsValid)
            {
                string uniqueBobName = string.Format("{0}/funnyimage_{1}{2}", Utils.CloudBlobKey,
                                                     Guid.NewGuid().ToString(),
                                                     Path.GetExtension(FileUploadImage.FileName));

                CloudBlockBlob blob = _blobClient.GetBlockBlobReference(uniqueBobName);
                blob.Properties.ContentType = FileUploadImage.PostedFile.ContentType;
                blob.UploadFromStream(FileUploadImage.FileContent);

                FunnyAppRepository<Post> postRepository = new FunnyAppRepository<Post>();
                FunnyAppRepository<Tag> tagRepository = new FunnyAppRepository<Tag>();

                MembershipUser user = Membership.GetUser(Page.User.Identity.Name);
                if (user != null)
                {
                    Post post = new Post
                        {
                            PostContent = TextBoxDescription.Text,
                            PostTitle = TextBoxTitle.Text,
                            State = false,
                            UserId = user.ProviderUserKey.ToString()
                        };

                    string[] tags = TextBoxTag.Text.Split(';');
                    foreach (string tag in tags)
                    {
                        if (!string.IsNullOrEmpty(tag))
                        {
                            tagRepository.Create(new Tag()
                                {
                                    PostRowKey = post.RowKey,
                                    PostPartitionKey = post.PartitionKey,
                                    TagName = tag,
                                });
                            tagRepository.SubmitChange();
                        }
                    }

                    postRepository.Create(post);
                    postRepository.SubmitChange();

                    CloudQueue queue = _queueClient.GetQueueReference(Utils.CloudQueueKey);
                    CloudQueueMessage message =
                        new CloudQueueMessage(string.Format("{0},{1},{2}", blob.Uri, post.PartitionKey, post.RowKey));
                    queue.AddMessage(message);

                    LabelResult.Text = "Uploaded";
                }
                else
                {
                    LabelResult.Text = "Failed";
                }
            }
        }

        private void InitializeStorage()
        {
            if (_storageInitialized)
            {
                return;
            }

            
            lock (_look)
            {
                if (_storageInitialized)
                {
                    return;
                }

                try
                {
                    // read account configuration settings
                    CloudStorageAccount storageAccount = CloudStorageAccount.FromConfigurationSetting(Utils.ConfigurationString);

                    // create blob container for images
                    _blobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer container = _blobClient.GetContainerReference(Utils.CloudBlobKey);
                    container.CreateIfNotExist();

                    // configure container for public access
                    var permissions = container.GetPermissions();
                    permissions.PublicAccess = BlobContainerPublicAccessType.Container;
                    container.SetPermissions(permissions);

                    // create queue to communicate with worker role
                    _queueClient = storageAccount.CreateCloudQueueClient();
                    CloudQueue queue = _queueClient.GetQueueReference(Utils.CloudQueueKey);
                    queue.CreateIfNotExist();
                }
                catch (WebException exception)
                {
                    Trace.Write(exception.Message);
                }

                _storageInitialized = true;
            }
        }
    }
}