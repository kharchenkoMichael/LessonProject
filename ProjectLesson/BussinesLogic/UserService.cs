﻿

using Storage;
using System.Runtime.CompilerServices;

namespace BussinesLogic
{
    public class UserService
    {
        private DataBase _dataBase;
        public UserService(DataBase dataBase)
        {
            _dataBase = dataBase;
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
            _dataBase.SaveChanges();
        }

        public User CreateUser(User user)
        {
            if (_dataBase.Users.Any(item => item.Phone == user.Phone))
            {
                throw new Exception("user с таким номером телефона уже существует");
            }
            
            _dataBase.Users.Add(user);
            _dataBase.SaveChanges();
            return user;
        }

        public User? Login(string phone,string password)
        {          
            return _dataBase.Users.FirstOrDefault(item => item.Phone == phone && item.Password == password);
        }
        public User? GetUserByPhone(string phone)
        {
            return _dataBase.Users.FirstOrDefault(item => item.Phone == phone);
        }
    }
    
    
}
