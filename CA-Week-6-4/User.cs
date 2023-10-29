using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CA_Week_6_4
{
    [Serializable]
    public class User : ISerializable
    {
        private static int _id = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }

        public User(string name, string surname, string username)
        {
            Id = User._id;
            Name = name;
            Surname = surname;
            Username = username;

            User._id++;
        }

        public User()
        {
            
        }

        public User(SerializationInfo info, StreamingContext context)
        {
            Id = (int)info.GetValue("Id", typeof(int));
            Name = (string)info.GetValue("Name", typeof(string));
            Surname = (string)info.GetValue("Surname", typeof(string));
            Username = (string)info.GetValue("Username", typeof(string));
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id, typeof(int));
            info.AddValue("Name", Name, typeof(string));
            info.AddValue("Surname", Surname, typeof(string));
            info.AddValue("Username", Username, typeof(string));


        }
    }
}
