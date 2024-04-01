using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class FullName
    {
        [MinLength(3, ErrorMessage = "3 caractere au minimum")]
        [MaxLength(25, ErrorMessage = "25 caractere au maximum")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
