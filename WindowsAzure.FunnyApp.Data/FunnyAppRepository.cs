namespace WindowsAzure.FunnyApp.Data
{
    using System;
    using System.Linq;
    
    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.StorageClient;

    using WindowsAzure.FunnyApp.Common;
    using WindowsAzure.FunnyApp.Entities;

    public class FunnyAppRepository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : EntityBase
    {
        private static CloudStorageAccount _storageAccount;
        private readonly FunnyAppContext _context;
        private readonly string _entitySetName;

        public FunnyAppRepository()
        {
            _storageAccount = CloudStorageAccount.FromConfigurationSetting(Utils.ConfigurationString);

            CloudTableClient.CreateTablesFromModel(
                typeof (FunnyAppContext),
                _storageAccount.TableEndpoint.AbsoluteUri,
                _storageAccount.Credentials);

            _entitySetName = typeof (TEntity).Name;
            _storageAccount.CreateCloudTableClient().CreateTableIfNotExist(_entitySetName);

            this._context = new FunnyAppContext(_storageAccount.TableEndpoint.AbsoluteUri, _storageAccount.Credentials);

            this._context.RetryPolicy = RetryPolicies.Retry(3, TimeSpan.FromSeconds(1));
        }

        public TEntity Find(string partitionKey, string rowKey)
        {
            return (from g in _context.CreateQuery<TEntity>(_entitySetName)
                    where g.PartitionKey == partitionKey && g.RowKey == rowKey
                    select g).FirstOrDefault();
        }

        public TEntity Find(string rowKey)
        {
            return (from g in _context.CreateQuery<TEntity>(_entitySetName)
                    where g.RowKey == rowKey
                    select g).FirstOrDefault();
        }

        public void Create(TEntity entity)
        {
            this._context.AddObject(_entitySetName, entity);
        }

        public void Delete(TEntity entity)
        {
            this._context.DeleteObject(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            this._context.UpdateObject(entityToUpdate);
        }

        public void SubmitChange()
        {
            this._context.SaveChanges();
        }

        public IQueryable<TEntity> Get()
        {
            return this._context.CreateQuery<TEntity>(_entitySetName);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
