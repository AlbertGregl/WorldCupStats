using DataRepository.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.ConverterJson
{
    /*
        code used from https://app.quicktype.io/
    */
    public static class Serialize
    {
        public static string ToJson(this List<Matches> self) 
            => JsonConvert.SerializeObject(self, Converter.JsonSettings);
    }
}
