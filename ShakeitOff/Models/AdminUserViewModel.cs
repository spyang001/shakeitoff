﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShakeitOff.Models
{
    public class AdminUserViewModel
    {
        public ApplicationUser user { get; set; }
        public List<string> role { get; set; }
    }
}