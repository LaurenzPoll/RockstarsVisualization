using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    public class EmailDTO
    {
        public string Email { get; set; }
        public EmailDTO()
        {
        }

        public EmailDTO(string email)
        {
            Email = email;
        }
    }
}
