using System;
using System.Collections.Generic;
using System.Text;

namespace GettingRealConsoleApp.Domain
{
    public class User
    {
        public int Id;
        public int Level;
        public string UserName;
        public string FullName;
        public string Phone;


        public User GetLevel()
        {
            return new User();
        }

        public override string ToString()
        {
            string result = "Username: " + UserName;
            return result; 
        }

    }
}
