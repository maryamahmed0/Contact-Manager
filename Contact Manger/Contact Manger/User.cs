using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manger
{
    internal class User : Contact
    {
        int id;
        string first_name;
        string last_name;
        string gender;
        string city;
        string added_date;

        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public string FirstName
        {
            set { first_name = value; }
            get { return first_name; }
        }
        public string LastName
        {
            set { last_name = value; }
            get { return last_name; }
        }
        public string Gender
        {
            set {  gender = value; }
            get { return gender; }
        }
        public string City
        {
            set { city = value; }
            get { return city; }
        }
        public string AddedDate
        {
            set { added_date = value; }
            get { return added_date; }
        }
        public User()
        {
            
        }
        public User(int id,string firstName,string lastName,string gender,string city,string addedDate)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.City = city;
            this.AddedDate = addedDate;
        }

        Phone phone = new Phone();
        Email emaill = new Email();
        Address address1 = new Address();
        public void AddPhone(string phoneNum, string type, string description)
        {
            phone.SetPhone(phoneNum);
            phone.SetType(type);
            phone.SetDescription(description);
            string data = phone.GetPhone();
            File.AppendAllText("Contact.txt", data+"-");
        }
        public void AddAddress(string Address, string type, string description)
        {
            address1.SetPlace(Address);
            address1.SetType(type);
            address1.SetDescription(description);
            string data = address1.GetAddress();
            File.AppendAllText("Contact.txt", data +"-");
        }
        public void AddEmail(string Email,string type,string description)
        {
              emaill.SetEmail(Email);
              emaill.SetType(type);
              emaill.SetDescription(description);
              string data = emaill.GetEmail();
              File.AppendAllText("Contact.txt", data+",");
        }

        public void EditPhone(string newPhone, string newType, string newDescription,int id)
        {
            phone.SetPhone(newPhone);
            phone.SetType(newType);
            phone.SetDescription(newDescription);
            string NewData=phone.GetPhone();
            Edit(NewData, 1, id);

        }

        public void EditAddress(string NewPlace, string NewType, string NewDescription ,int id)
        {
            address1.SetPlace(NewPlace);
            address1.SetType(NewType);
            address1.SetDescription(NewDescription);
            string NewData=address1.GetAddress();
            Edit(NewData, 2, id);
        }
        public void EditEmail(string NewEmail, string NewType, string NewDescription,int id)
        {
            emaill.SetEmail(NewEmail);
            emaill.SetDescription(NewDescription);
            emaill.SetType(NewType);
            string NewData = emaill.GetEmail();
            Edit(NewData, 3, id);
        }
        public void DeletePhone(int id)
        {
            Edit(string.Empty,1,id);
        }
        public void DeleteAddress(int id)
        {
            Edit(string.Empty,2,id);
        }
        public void DeleteEmail(int id)
        {
            Edit(string.Empty,3,id);
        }
        public bool CheckData(string data)
        {
            string[] FileData = File.ReadAllLines("Contact.txt");
            for (int i = 0; i < FileData.Length; i++)
            {
                if (FileData[i].Contains(data))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
