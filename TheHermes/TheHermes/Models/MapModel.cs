using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheHermes.Models
{
    public class KeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }

    }
    public class MapModel
    {
        public List<KeyValue> KeyValues { get; set; } 

    }
}