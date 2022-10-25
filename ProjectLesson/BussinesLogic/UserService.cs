

using Storage;
using System.Runtime.CompilerServices;

namespace BussinesLogic
{
    public class UserService
    {
        private DataBase _dataBase;
        public UserService()
        {
            _dataBase = new DataBase();
            _dataBase.InitDataBase();
        }

        public void UpdateUser(User user)
        {
            var userFromDataBase = _dataBase.Users.FirstOrDefault(item => item.Phone == user.Phone);
            if (userFromDataBase == null)
            {
                Console.WriteLine("user с таким номером телефона в базе данных нет");
                return;
            }
            userFromDataBase.Name = user.Name;
            userFromDataBase.LastName = user.LastName;
            _dataBase.Save();
        }

        public User CreateUser(string phone, string password)
        {
            if (_dataBase.Users.Any(item => item.Phone == phone))
            {
                throw new Exception("user с таким номером телефона уже существует");
            }
            var user = new User();
            user.Phone = phone;
            user.Password = password;
            _dataBase.Users.Add(user);
            _dataBase.Save();
            return user;
        }  
        
    }
}
