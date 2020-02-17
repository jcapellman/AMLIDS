using AMLIDS.lib.dal.Enums;
using AMLIDS.lib.dal.Models;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AMLIDS.lib.dal
{
    public interface IDataStorage
    {
        OperationResponse InsertNetworkData<T>(T payload, int dataDefinitionVersion);

        OperationResponse InsertBulkNetworkData<T>(List<T> payload, int dataDefinitionVersion);

        List<NetworkDataItem> QueryNetworkData(Expression<Func<NetworkDataItem, bool>> query);

        List<NetworkDataItem> GetAllNetworkData();
    }
}