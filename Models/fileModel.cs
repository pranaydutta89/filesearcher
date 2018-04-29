using System;
using fileSearcher.constants;

namespace fileSearcher.Models
{
    public class fileModel
    {
        public string name { get; set; }

        public fileTypes type { get; set; }

        public DateTime createdDateTime { get; set; }

        public DateTime modifiedDateTime { get; set; }

        public string renderUrl { get; set; }

    }
}