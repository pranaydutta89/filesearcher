using System;
using fileSearcher.constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace fileSearcher.Models
{
    public class file
    {
        public file()
        {
            this.lastRefreshed = new DateTime();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid fileId { get; set; }
        public string name { get; set; }

        public fileTypes type { get; set; }

        public DateTime createdDateTime { get; set; }

        public DateTime modifiedDateTime { get; set; }

        public DateTime lastRefreshed { get; set; }

    }
}