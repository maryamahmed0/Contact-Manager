using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manger
{
    internal class Email 
    {
        string email;
        string type;
        string description;
        public void SetEmail(string email)
        {
            this.email = email;
        }
        public void SetType(string type)
        {
            this.type = type;
        }
        public void SetDescription(string description)
        {
            this.description = description;
        }
        public string GetEmail()
        {
            return this.email + " " + this.type + " " + this.description;
        }
    }
}
