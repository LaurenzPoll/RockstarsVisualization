using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    public class EmailDTO
    {
        string Email { get; set; }
        public EmailDTO()
        {
        }

        public EmailDTO(string email)
        {
            email = Email;
        }
    }
}
