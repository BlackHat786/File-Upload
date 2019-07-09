using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UploadFileTesting.Models
{
    public class FileUpload
    {
        [Key]
        public int FileId { get; set; }
        [Required]
        public byte[] File { get; set; }
        public string FileName { get; set; }
    }
}