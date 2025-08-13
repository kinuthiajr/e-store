using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duka.Domain.Users
{
    public class User
    {
        public int Id { get; set; }
    
        public string Username { get; set; } = string.Empty;
    
        public string Email { get; set; } = string.Empty;
    }
}