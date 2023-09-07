using System.Security.Cryptography;
using System.Text;

namespace MvcMessageLogger.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get;  set; }
        public string Username { get;  set; }
        public List<Message> Messages { get; } = new List<Message>();
        public string Password { get; set; }



       // Parameterless constructor for model binding
     public User(string name, string username, string password)
        {
            Name = name;
            Username = username;
            Password = password;

        }
        public User()
        {

            Name = string.Empty;
            Username = string.Empty;
            Password = string.Empty;

        }

        

        public string GetDigestedPassword(string password)
        {
            HashAlgorithm sha = SHA256.Create();

            string PasswordInput = password;

            byte[] firstInputBytes = Encoding.ASCII.GetBytes(PasswordInput);
            byte[] firstInputDigested = sha.ComputeHash(firstInputBytes);

            StringBuilder firstInputBuilder = new StringBuilder();
            foreach (byte b in firstInputDigested)
            {
                Console.Write(b + ", ");
                firstInputBuilder.Append(b.ToString("x2"));
            }

            return firstInputBuilder.ToString();
        }


        public bool VerifyPassword(string password)
        {
            string inputHash = GetDigestedPassword(password).ToString();
            return inputHash == Password.ToString();
        }


    }
}
