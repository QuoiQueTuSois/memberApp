﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memberApp.Shared.Models
{
    public class CommonResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public int Data { get; set; } 

    }
}