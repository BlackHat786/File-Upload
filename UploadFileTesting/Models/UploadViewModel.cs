using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UploadFileTesting.Models
{
    public class UploadViewModel
    {
        [Key]
        public int key { get; set; }
        [Required]
        public HttpPostedFileBase File { get; set; }
        public string FileName { get; set; }

    }
}