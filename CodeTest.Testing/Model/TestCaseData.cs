using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Testing.Model
{
    public class TestCaseData
    {
        [JsonProperty("input")]
        public List<int> InputData { get; set; } = new List<int>();

        [JsonProperty("output")]
        public List<int> OutputData { get; set; } = new List<int>();
    }

}
