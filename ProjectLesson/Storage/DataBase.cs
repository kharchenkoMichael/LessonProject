

using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text.Json;

namespace Storage
{
    public class DataBase : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Procedur> Procedurs { get; set; }
        public DbSet<Record> Records { get; set; }

        private const string path = "database.json";
        public DataBase()
        {

        }
        public DataBase(DbContextOptions<DataBase> options)
            :base(options)
        {

        }

        public void InitDataBase()
        {
            if (File.Exists(path))
            {
                string json = "";
                using (var reader = new StreamReader(new FileStream(path, FileMode.OpenOrCreate)))
                {
                    json = reader.ReadToEnd();
                }
                var item = JsonSerializer.Deserialize<DataBase>(json);
                Users = item.Users;
                Procedurs = item.Procedurs;
                Records = item.Records;
                return;
            }
            else
            {
                Procedurs.Add(new Procedur() { Name = "Manikur", Price = 250, Time = new TimeSpan(1, 0, 0) });
                Procedurs.Add(new Procedur() { Name = "Manikur + pokruttya", Price = 400, Time = new TimeSpan(1, 30, 0) });
                Procedurs.Add(new Procedur() { Name = "Pedikur", Price = 200, Time = new TimeSpan(0, 40, 0) });
                Procedurs.Add(new Procedur() { Name = "Pedikur + pokruttya", Price = 250, Time = new TimeSpan(1, 30, 0) });
                Procedurs.Add(new Procedur() { Name = "Ysilenie", Price = 100, Time = new TimeSpan(0, 20, 0) });
                Save();
            }
          
        }
        public void Save()
        {
            File.Delete(path);
            string jsonString = JsonSerializer.Serialize(this);
            using (var writer = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate)))
            {               
                writer.Write(jsonString);
            }
        }
    }
}