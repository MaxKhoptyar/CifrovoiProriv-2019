using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using TheHermesEntities;
using Extentions;
using TheHermesEntities.Common;

namespace DbWorker
{
    public class DbHelper
    {
        public static List<CommonType> GetRelationshipTypes()
        {
            var f = Enum.GetValues(typeof(RelationshipType));
            var resultList = new List<CommonType>();
            foreach (var e in f)
            {
                resultList.Add(new CommonType() { Id = (int)e, Name = e.DescriptionAttr() });
            }
            return resultList;
        }


    }
}