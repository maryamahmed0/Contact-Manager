using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manger
{
    class Contact
    {
        int Count=0;
        public void AddUser(User user)
        { 
            File.AppendAllText("Contact.txt", user.Id.ToString() +
                                   " " + user.FirstName
                                  +" " + user.LastName
                                  +" "+user.Gender
                                  +" "+user.City
                                  +" "+user.AddedDate+"-"
                                  );
        }
        public void EditUser(User user,int id)
        {
            string NewData = user.Id.ToString() +
                                   " " + user.FirstName
                                  + " " + user.LastName
                                  + " " + user.Gender
                                  + " " + user.City
                                  + " " + user.AddedDate;
            Edit(NewData, 0,id);
        }
        public int CountUser()
        {
            string[] userData = File.ReadAllText("Contact.txt").Split(',');
            for(int i = 0;i<userData.Length;i++)
            {
                if (userData[i] !=string.Empty)
                {
                    Count++;
                }
            }
            return Count;
        }
        public void DeleteUser(int id)
        {
            string oldData = SearchUser(id);
            string[] data = File.ReadAllLines("Contact.txt");
            string newData = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Contains(oldData))
                {
                    data[i] = data[i].Replace(oldData, string.Empty);
                    break;
                }
            }
            for (int i = 0; i < data.Length; i++)
            {
                newData += data[i];
            }
            File.WriteAllText("Contact.txt", newData);

        }
        public string SearchUser(int id)
        {
            string[] userData = ShowAll();
            for (int i = 0; i < userData.Length; i++)
            {
                if (userData[i].Contains(id.ToString()))
                {
                    for (int j = 0; j < userData.Length; j++)
                    {
                        string[] data = userData[j].Split(' ');
                        if (data[0].Contains(id.ToString()))
                            return userData[j];
                        else
                            continue;
                    }

                }
            }
            return "User doesn't exist!";
        }
        public string Search(string data)
        {
            string [] userData = ShowAll();
            string matchedUsers = "";
            for(int i = 0;i<userData.Length; i++)
            {
               
                if (userData[i].Contains(data))
                {
                    matchedUsers+= userData[i]+',';
                }
            }
            return matchedUsers;
        }
        public string[] ShowAll()
        {
            string fileData = File.ReadAllText("Contact.txt");
            return fileData.Split(',');
        }
        public void Edit(string newData,int index,int id)
        {
            string[] oldData = SearchUser(id).Split('-');
            string[] data = File.ReadAllLines("Contact.txt");
            string fullData = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Contains(oldData[index]))
                {
                    data[i] = data[i].Replace(oldData[index], newData);
                    break;
                }
            }
            for (int i = 0; i < data.Length; i++)
            {
                fullData += data[i];
            }
            File.WriteAllText("Contact.txt", fullData);
        }
    }
}
