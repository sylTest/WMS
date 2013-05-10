using System;
using System.Collections.Generic;

namespace THOK.Authority.DbModel
{
    public partial class AUTH_HELP_CONTENT
    {
        public AUTH_HELP_CONTENT()
        {
            this.HelpContents = new List<AUTH_HELP_CONTENT>();
        }

        public string ID { get; set; }
        public string CONTENT_CODE { get; set; }
        public string CONTENT_NAME { get; set; }
        public string CONTENT_TEXT { get; set; }
        public string CONTENT_PATH { get; set; }
        public string NODE_TYPE { get; set; }
        public string FATHER_NODE_ID { get; set; }
        public string MODULE_ID { get; set; }
        public decimal NODE_ORDER { get; set; }
        public string IS_ACTIVE { get; set; }
        public System.DateTime UPDATE_TIME { get; set; }
        public virtual ICollection<AUTH_HELP_CONTENT> HelpContents { get; set; }
        public virtual AUTH_HELP_CONTENT FatherNode { get; set; }
        public virtual AUTH_MODULE AUTH_MODULE { get; set; }
    }
}
