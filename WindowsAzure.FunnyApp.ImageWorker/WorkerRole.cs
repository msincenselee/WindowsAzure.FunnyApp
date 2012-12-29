namespace WindowsAzure.FunnyApp.ImageWorker
{
    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.ServiceRuntime;
    using Microsoft.WindowsAzure.StorageClient;
    
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Net;
    using System.Text.RegularExpressions;

    using WindowsAzure.FunnyApp.Common;
    using WindowsAzure.FunnyApp.Data;
    using WindowsAzure.FunnyApp.Entities;

    public class WorkerRole : RoleEntryPoint
    {
        private CloudQueue _queue;
        private CloudBlobContainer _container;

        public override void Run()
        {
            while (true)
            {
                try
                {
                    CloudQueueMessage message = _queue.GetMessage();
                    if (message != null)
                    {
                        string[] messageArray = message.AsString.Split(new char[] { ',' });
                        string outputBlobUri = messageArray[0];
                        string partitionKey = messageArray[1];
                        string rowkey = messageArray[2];

                        _queue.PeekMessage();

                        string inputBlobUri = Regex.Replace(outputBlobUri, "([^\\.]+)(\\.[^\\.]+)?$", "$1-myimage$2");

                        _container.CreateIfNotExist();
                        CloudBlob inputBlob = _container.GetBlobReference(outputBlobUri);
                        CloudBlob outputBlob = _container.GetBlobReference(inputBlobUri);

                        using (BlobStream input = inputBlob.OpenRead())
                        using (BlobStream output = outputBlob.OpenWrite())
                        {
                            ProcessImage(input, output);

                            output.Commit();
                            outputBlob.Properties.ContentType = "image/jpeg";
                            outputBlob.SetProperties();

                            FunnyAppRepository<Post> postRepository = new FunnyAppRepository<Post>();
                            Post post = postRepository.Find(partitionKey, rowkey);
                            
                            post.PostImage = inputBlobUri;
                            post.State = true;
                            postRepository.Update(post);
                            postRepository.SubmitChange();

                            _queue.DeleteMessage(message);
                        }
                    }
                }
                catch (StorageClientException e)
                {
                    Trace.Write(e);
                }
            }
        }

        public override bool OnStart()
        {
            ServicePointManager.DefaultConnectionLimit = 12;
            CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) => 
                configSetter(RoleEnvironment.GetConfigurationSettingValue(configName)));

            var storageAccount = CloudStorageAccount.FromConfigurationSetting(Utils.ConfigurationString);
            CloudQueueClient queueStorage = storageAccount.CreateCloudQueueClient();
            _queue = queueStorage.GetQueueReference(Utils.CloudQueueKey);

            _queue.CreateIfNotExist();

            CloudBlobClient blobStorage = storageAccount.CreateCloudBlobClient();
            _container = blobStorage.GetContainerReference(Utils.CloudBlobKey);

            _container.CreateIfNotExist();
            
            return base.OnStart();
        }

        public void ProcessImage(Stream input, Stream output)
        {
            int width;
            int height;
            var originalImage = new Bitmap(input);

            if (originalImage.Width > originalImage.Height)
            {
                width = 260;
                height = 128 * originalImage.Height / originalImage.Width;
            }
            else
            {
                height = 180;
                width = 128 * originalImage.Width / originalImage.Height;
            }

            var thumbnailImage = new Bitmap(width, height);

            using (Graphics graphics = Graphics.FromImage(thumbnailImage))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage(originalImage, 0, 0, width, height);
            }

            thumbnailImage.Save(output, ImageFormat.Jpeg);
        }
    }
}
