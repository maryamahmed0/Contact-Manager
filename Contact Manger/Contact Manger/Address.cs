using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manger
{
    internal class Address
    {
        string place;
        string type;
        string description;
        public void SetPlace(string place)
        {
            this.place = place;
        }
        public void SetType(string type)
        {
            this.type = type;
        }
        public void SetDescription(string description)
        {
            this.description = description;
        }
        public string GetAddress()
        {
            return this.place+" "+this.type+" "+this.description;
        }
    }
}
