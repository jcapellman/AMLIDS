using AMLIDS.lib.dal.Enums;
using AMLIDS.lib.dal.Models;

using LiteDB;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace AMLIDS.lib.dal.litedb
{
    public class LiteDBDataStorage : IDataStorage
    {
        private const string DB_FILENAME = "ds.db";

        private string DB_PATH;

        public List<NetworkDataItem> GetAllNetworkData()
        {
            using (var db = new LiteDatabase(DB_PATH))
            {
                var collection = db.GetCollection<NetworkDataItem>();

                return collection.FindAll().ToList();
            }
        }

        public OperationResponse InsertBulkNetworkData<T>(List<T> payload, int dataDefinitionVersion)
        {
            using (var db = new LiteDatabase(DB_PATH))
            {
                var collection = db.GetCollection<NetworkDataItem>();

                collection.InsertBulk(payload.Select(a => new NetworkDataItem(a, dataDefinitionVersion)));

                return OperationResponse.SUCCESS;
            }
        }

        public OperationResponse InsertNetworkData<T>(T payload, int dataDefinitionVersion)
        {
            using (var db = new LiteDatabase(DB_PATH))
            {
                var collection = db.GetCollection<NetworkDataItem>();

                collection.Insert(new NetworkDataItem(payload, dataDefinitionVersion));

                return OperationResponse.SUCCESS;
            }
        }

        public List<NetworkDataItem> QueryNetworkData(Expression<Func<NetworkDataItem, bool>> query)
        {
            using (var db = new LiteDatabase(DB_PATH))
            {
                var collection = db.GetCollection<NetworkDataItem>();

                return collection.Find(query).ToList();
            }
        }

        public void SetPath(string pathToDatabase)
        {
            DB_PATH = Path.Combine(pathToDatabase, DB_FILENAME);
        }
    }
}