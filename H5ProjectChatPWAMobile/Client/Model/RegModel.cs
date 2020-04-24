using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace H5ProjectChatPWAMobile.Client.Model
{
    public class RegModel
    {
        [Required]
        public string username="";
        [Required]
        public string password="";
        [Required]
        public string IP="";
        [Required]
        public string CreateState="";
    }
}
