using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TASKMANAGER21.Models
{
    public partial class Resinf
    {
        public string Rescode { get; set; }
        [Display(Name = "User Name")]
        public string Resname { get; set; }
        [Display(Name = "User Type")]
        public string Restype { get; set; }
        [Display(Name = "Email")]
        public string Resemail { get; set; }
        [Display(Name = "Phone")]
        public string Resphone { get; set; }
        [Display(Name = "Status")]
        public string Resstatus { get; set; }
        [Display(Name = "Designation")]
        public string Resdesig { get; set; }
    }
}
