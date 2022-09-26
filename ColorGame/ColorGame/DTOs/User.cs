using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.DTOs
{
    public class User
    {
        public User(string name = "")
        {
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
    }
}
