using System;
using System.Collections.Generic;

namespace TimeManagementApp
{
    public class User
    {
        public User()
        {
            this.Calculation = new HashSet<Calculation>();
        }
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        public virtual ICollection<Calculation> Calculation { get; set; }  
    }
    
}