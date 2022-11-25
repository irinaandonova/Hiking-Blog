using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Models
{
    internal interface IUser
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public int HikingSkill { get; set; }

        //public bool IsSubscribed { get; set; } = false;
    }
}
