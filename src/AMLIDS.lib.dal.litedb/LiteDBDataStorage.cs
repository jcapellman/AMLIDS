using AMLIDS.lib.dal.Enums;
using AMLIDS.lib.dal.Models;

using LiteDB;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AMLIDS.lib.dal.litedb
{
    public class LiteDBDataStorage : IDataStorage
    {
        private const string DB_FILENAME = "ds.db";

        public List<NetworkDataItem> GetAllNetworkData()
        {
            using (var db = new LiteDatabase(DB_FILENAME))
            {
                var collection = db.GetCollection<NetworkDataItem>();

                return collection.FindAll().ToList();
            }
        }

        public OperationResponse InsertBulkNetworkData(List<object> payload)
        {
            using (var db = new LiteDatabase(DB_FILENAME))
            {
                var collection = db.GetCollection<NetworkDataItem>();

                collection.InsertBulk(payload.Select(a => new NetworkDataItem(a)));

                return OperationResponse.SUCCESS;
            }
        }

        public OperationResponse InsertNetworkData(object payload)
        {
            using (var db = new LiteDatabase(DB_FILENAME))
            {
                var collection = db.GetCollection<NetworkDataItem>();

                collection.Insert(new NetworkDataItem(payload));

                return OperationResponse.SUCCESS;
            }
        }

        public List<NetworkDataItem> QueryNetworkData(Expression<Func<NetworkDataItem, bool>> query)
        {
            using (var db = new LiteDatabase(DB_FILENAME))
            {
                var collection = db.GetCollection<NetworkDataItem>();

                return collection.Find(query).ToList();
            }
        }
    }
}