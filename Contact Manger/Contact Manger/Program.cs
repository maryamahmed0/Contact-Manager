using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartProgram();
        }

        static void StartProgram()
        {
            string Continue;
            do
            {
                Console.Clear();
                Console.WriteLine("Contact List :");
                Console.WriteLine("1.Add user " +
                    "\n2.Edit" +
                    "\n3.Delete" +
                    "\n4.Search for a specific user" +
                    "\n5.Show Contact information" +
                    "\n6.To Know How many users" +
                    "\n7.Search" +
                    "\n8.Check for a specific data if exist");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                int id;
                string fname, lname, gender, city, addedDate,phoneNum,phoneType,phoneDescription,address,addressType,addressDescription,
                    email,emailType,emailDescription,Data;
                string[] Userdata;
                Console.Clear();
                Contact contact = new Contact();
                User user = new User();
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter user's id : ");
                        id= int.Parse(Console.ReadLine());
                        Console.Write("Enter user's first name : ");
                        fname= Console.ReadLine();
                        Console.Write("Enter user's last name : ");
                        lname= Console.ReadLine();
                        Console.Write("Enter user's gender : ");
                        gender= Console.ReadLine();
                        Console.Write("Enter user's city : ");
                        city= Console.ReadLine();
                        addedDate = DateTime.Now.ToString();
                        Console.Write("Enter phone number : ");
                        phoneNum= Console.ReadLine();
                        Console.Write("Enter phone type : ");
                        phoneType = Console.ReadLine();
                        Console.Write("Enter phone description : ");
                        phoneDescription = Console.ReadLine();
                        Console.Write("Enter user's address: ");
                        address= Console.ReadLine();
                        Console.Write("Enter address type : ");
                        addressType = Console.ReadLine();
                        Console.Write("Enter address descripton : ");
                        addressDescription = Console.ReadLine();
                        Console.Write("Enter user's email : ");
                        email= Console.ReadLine();
                        Console.Write("Enter email type : ");
                        emailType= Console.ReadLine();
                        Console.Write("Enter email description : ");
                        emailDescription = Console.ReadLine();
                        user = new User(id,fname,lname,gender,city,addedDate);
                        contact.AddUser(user);
                        user.AddPhone(phoneNum, phoneType,phoneDescription);
                        user.AddAddress(address, addressType,addressDescription);
                        user.AddEmail(email, emailType,emailDescription);
                        break;
                    case 2:
                        Console.Write("Enter the id of the user you want to edit : ");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Edit List :");
                        Console.WriteLine("1.Phone" +
                            "\n2.Address" +
                            "\n3.Email" +
                            "\n4.other");
                        Console.Write("What do you want to edit : ");
                        int ch = int.Parse(Console.ReadLine());
                        switch (ch)
                        {
                            case 1:
                                Console.Write("Enter new phone number :");
                                phoneNum = Console.ReadLine();
                                Console.Write("Enter phone type :");
                                phoneType = Console.ReadLine();
                                Console.Write("Enter phone description : ");
                                phoneDescription = Console.ReadLine();
                                user.EditPhone(phoneNum, phoneType, phoneDescription, id);
                                break;
                            case 2:
                                Console.Write("Enter new Address :");
                                address = Console.ReadLine();
                                Console.Write("Enter address type:");
                                addressType = Console.ReadLine();
                                Console.Write("Enter address description : ");
                                addressDescription = Console.ReadLine();
                                user.EditAddress(address,addressType,addressDescription, id);
                                break;
                            case 3:
                                Console.Write("Enter new Email :");
                                email = Console.ReadLine();
                                Console.Write("Enter email type :");
                                emailType = Console.ReadLine();
                                Console.Write("Enter email description : ");
                                emailDescription = Console.ReadLine();
                                user.EditEmail(email ,emailType, emailDescription, id);
                                break;
                            case 4:
                                Console.Write("Enter user's first name : ");
                                fname = Console.ReadLine();
                                Console.Write("Enter user's last name : ");
                                lname = Console.ReadLine();
                                Console.Write("Enter user's gender : ");
                                gender = Console.ReadLine();
                                Console.Write("Enter user's city : ");
                                city = Console.ReadLine();
                                addedDate = DateTime.Now.ToString();
                                user = new User(id, fname, lname, gender, city, addedDate);
                                contact.EditUser(user, id);
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Delete options :");
                        Console.WriteLine("1.Delete Phone number" +
                            "\n2.Delete Address" +
                            "\n3.Delete Email" +
                            "\n4.Delete user");
                        Console.Write("Enter your choice : ");
                        choice=int.Parse(Console.ReadLine());
                        Console.Write("Enter id of the user you want to delete : ");
                        id = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                user.DeletePhone(id);
                                Console.WriteLine("Phone number have been deleted succesfully!");
                                break;
                            case 2:
                                user.DeleteAddress(id);
                                Console.WriteLine("Addres have been deleted successfully!");
                                break;
                            case 3:
                                user.DeleteEmail(id);
                                Console.WriteLine("Email have been deleted successfully!");
                                break;
                            case 4:
                                contact.DeleteUser(id);
                                Console.WriteLine("User have been deleted successfully!");
                                break;
                        }
                        break;
                    case 4:
                        Console.Write("Enter the id of the user you want to search for: ");
                        id = int.Parse(Console.ReadLine());
                        if(contact.CountUser() > 0)
                        {    string []data = contact.SearchUser(id).Split(' ');
                             string[] splitData =contact.SearchUser(id).Split('-');
                            Console.WriteLine("Id : " + data[0] + "\nFirst Name : " + data[1] + "\nLast Name: " + data[2] + "\nGender : " + data[3]
                         + "\nCity : " + data[4] + "\nAdded date : " + data[5] + "\nPhone : " + splitData[1] + "\nAddres : " + splitData[2] + "\nEmail : " + splitData[3] + "\n");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Contact is empty!");
                        }
                        break;
                    case 5:
                        if(contact.CountUser()>0)
                        {
                            Userdata = contact.ShowAll();
                            Print(Userdata);
                        }
                        else
                        {
                            Console.WriteLine("Contact is empty!");
                        }
                        break;
                    case 6:
                        Console.WriteLine(contact.CountUser());
                        break;
                    case 7:
                        Console.Write("Enter data you want to search for :");
                        Data = Console.ReadLine();
                        Userdata = user.Search(Data).Split(',');
                        Print(Userdata);
                        break;
                    case 8:
                        Console.Write("Enter data : ");
                        Data = Console.ReadLine();
                        if (user.CheckData(Data))
                        {
                            Console.WriteLine(Data + " exist!");
                        }
                        else
                        {
                            Console.WriteLine(Data + " doesn't exist!");
                        }
                        break;
                    default:
                        Console.WriteLine("you entered an invalid number!");
                        break;
                }
                Console.Write("Enter y or Y to go back to the contact list otherwise press any other key : ");
                Continue = Console.ReadLine();
            } while (Continue == "y" || Continue == "Y");
        }
        static void Print(string[] Userdata)
        {
            for (int i = 0; i < Userdata.Length; i++)
            {
                string[] data = Userdata[i].Split(' ');
                string[] splitData = Userdata[i].Split('-');
                if (Userdata[i] != string.Empty)
                {
                    Console.WriteLine("Id : " + data[0] + "\nFirst Name : " + data[1] + "\nLast Name: " + data[2] + "\nGender : " + data[3]
                        + "\nCity : " + data[4] + "\nAdded date : " + data[5] + "\nPhone : " + splitData[1] + "\nAddres : " + splitData[2] + "\nEmail : " + splitData[3] + "\n");
                }
            }
        }
    }
}
