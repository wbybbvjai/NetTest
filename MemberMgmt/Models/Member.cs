﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberMgmt.Models
{
    class Member
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public int? NoConsumption { get; set; }
        public int Step { get; internal set; }
    }
}
