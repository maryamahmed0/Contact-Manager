using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manger
{
    internal class Phone 
    {
        string phone;
        string type;
        string description;

        public void SetPhone(string phone)
        {
            this.phone = phone;
        }
        public void SetType(string type)
        {
            this.type = type;
        }
        public void SetDescription(string description)
        {
            this.description = description;
        }
        public string GetPhone()
        {
            return this.phone + " " + this.type + " " + this.description;
        }
    }
}
