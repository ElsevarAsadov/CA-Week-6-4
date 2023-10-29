using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace CA_Week_6_4
{
    internal class Program
    {
        private static string _desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        static void Main(string[] args)
        {
            User user1 = new("Elsevar", "Asadov", "eli123");

            //SerBinary(user);

            //User u = DeSerBinary(Path.Combine(Program._desktopPath, "TestBinary.dat"));

            //SerXML(user2);
            //User ser u = DeSerXML(Path.Combine(Program._desktopPath, "TestXML.xml"));

            SerJSON(user1);
            User u = DeSerJSON(Path.Combine(Program._desktopPath, "TestJSON.json"));


           //Console.WriteLine(u.Id);
           //Console.WriteLine(u.Name);
           //Console.WriteLine(u.Surname);
        }

        static void SerBinary(User user)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            
            Stream stream = new FileStream(Path.Combine(Program._desktopPath, "TestBinary.dat"), FileMode.Create);

            formatter.Serialize(stream, user);
        }

        static void SerXML(User user)
        {
            Stream stream = new FileStream(Path.Combine(Program._desktopPath, "TestXML.xml"), FileMode.Create);
            XmlSerializer formatter = new XmlSerializer(typeof(User));

            formatter.Serialize(stream, user);
        }

        static void SerJSON(User user)
        {
            
            string json = JsonSerializer.Serialize(user);

            File.WriteAllText(Path.Combine(Program._desktopPath, "TestJSON.json"), json);
        }

        static User? DeSerJSON(string path)
        {

            return JsonSerializer.Deserialize<User>(File.ReadAllText(path));
        }

        static User DeSerXML(string path)
        {
            Stream stream = new FileStream(path, FileMode.Open);

            XmlSerializer formatter = new XmlSerializer(typeof(User));
            User user = (User) formatter.Deserialize(stream);

            return user;
        }


        static User DeSerBinary(string path)
        {
            Stream stream = new FileStream(path, FileMode.Open);

            BinaryFormatter formatter = new BinaryFormatter();
            User user = (User) formatter.Deserialize(stream);

            return user;
        }
    }
}