using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.TokenDTOs.Token
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; } //token ömrü
    }
}
