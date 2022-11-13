using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace memberApp.Shared.Models
{
    public class MemberResponse
    {
        [JsonPropertyName(nameof(TotalPage))]
        public int TotalPage { get; set; }




        [JsonPropertyName(nameof(MEMBERS))]
        public IEnumerable<MemberModel> MEMBERS { get; set; }


    }
}
