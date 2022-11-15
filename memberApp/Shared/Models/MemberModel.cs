using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace memberApp.Shared.Models
{
    public class MemberModel 
    {
        [JsonPropertyName(nameof(SEQ))]
        public int SEQ { get; set; }
           
        [JsonPropertyName(nameof(ID))]
        public string ID { get; set; }
       
        [JsonPropertyName(nameof(NICKNAME))]
        public string NICKNAME { get; set; }

        [JsonPropertyName(nameof(LEVEL))]
        public int? LEVEL { get; set; }

        [JsonPropertyName(nameof(POINT))]
        public int? POINT { get; set; }

        [JsonPropertyName(nameof(REG_DATE))]
        
        public DateTime? REG_DATE { get; set; }

        [JsonPropertyName(nameof(EXPIRE_DATE))]
        public DateTime? EXPIRE_DATE { get; set; }

        [JsonPropertyName(nameof(MEMBER_CLASS))]
        public string? MEMBER_CLASS { get; set; }

        //이메일 추가할것 

    }
}
