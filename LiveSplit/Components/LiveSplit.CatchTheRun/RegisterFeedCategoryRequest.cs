using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSplit.CatchTheRun
{
    internal class RegisterFeedCategoryRequest
    {
        public string Producer { get; set; }
        public string Game { get; set; }
        public string Category { get; set; }
    }
}
