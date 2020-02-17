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

        List<NetworkDataItem> QueryNetworkData(Expression<Func<NetworkDataItem>> query);

        List<NetworkDataItem> GetAllNetworkData();
    }
}