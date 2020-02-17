using AMLIDS.lib.dal.Enums;
using AMLIDS.lib.dal.Models;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AMLIDS.lib.dal
{
    public interface IDataStorage
    {
        OperationResponse InsertNetworkData(object payload);

        OperationResponse InsertBulkNetworkData(List<object> payload);

        List<NetworkDataItem> QueryNetworkData(Expression<Func<NetworkDataItem, bool>> query);

        List<NetworkDataItem> GetAllNetworkData();
    }
}