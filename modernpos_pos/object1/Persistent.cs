﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class Persistent
    {
        public String table = "";
        public String pkField = "";
        public String sited = "";

        public String active { get; set; }
        public String remark { get; set; }
        public String sort1 { get; set; }

        public String device_id { get; set; }
        public String branch_id { get; set; }
        public String host_id { get; set; }

        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        
        Random r = new Random();
        public String getGenID()
        {
            //return r.Next().ToString();
            return DateTime.Now.Ticks.ToString();
        }
    }
}
