using Programatica.Framework.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsDotNetCore.Models
{
    public class User : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
