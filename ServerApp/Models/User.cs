using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class User
    {
        [Key]
        public int idUser { get; set; }
        public string name { get; set; }

        public string role { get; set; }
    }
}
