

using System.Net.Http.Headers;
using System.Text.Json;

namespace Storage
{
    public class DataBase
    {
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Procedur> Procedurs { get; set; } = new List<Procedur>();
        public ICollection<Record> Records { get; set; } = new List<Record>();

        private const string path = "database.json";

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
                Procedurs.Add(new Procedur() { Name = "Манікюр", Price = 250, Time = new TimeSpan(1, 0, 0) });
                Procedurs.Add(new Procedur() { Name = "Манікюр + покриття", Price = 400, Time = new TimeSpan(1, 30, 0) });
                Procedurs.Add(new Procedur() { Name = "Педікюр", Price = 200, Time = new TimeSpan(0, 40, 0) });
                Procedurs.Add(new Procedur() { Name = "Педікюр + покриття", Price = 250, Time = new TimeSpan(1, 30, 0) });
                Procedurs.Add(new Procedur() { Name = "Усилення", Price = 100, Time = new TimeSpan(0, 20, 0) });

            }
          
        }
        public void Save()
        {
            string jsonString = JsonSerializer.Serialize(this);
            using (var writer = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate)))
            {
                writer.Write(jsonString);
            }
        }
    }
}