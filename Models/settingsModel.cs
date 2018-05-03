using System.Collections.Generic;
using fileSearcher.constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace fileSearcher.Models
{


    public class searchFolder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid searchFolderId { get; set; }

        public string folderPath { get; set; }
    }
    public class fileType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid fileTypeId { get; set; }

        public fileTypes type { get; set; }
    }
}