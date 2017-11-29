using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApiCore.Models
{
    public class ContactModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastNames { get; set; }
        [Required]
        [Range(1 , 125)]
        public int Age { get; set; }

        public string DisplayName
        {
            get
            {
                return string.Format("{0} {1}", Name, LastNames);
            }
        }
    }
}
