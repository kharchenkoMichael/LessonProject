


using Storage;
using Storage.Response;
using System.Net.Http.Json;
using System.Numerics;
using System.Text.Json;

namespace UserInterface
{
    public class UserCommandService
    {

        public void ShowAllProcedurs()
        {
            using var client = new HttpClient();
            var responce = client.GetAsync($"{Constants.BaseURL}/api/procedur").Result;
            var procedurs = JsonSerializer.Deserialize<List<Procedur>>(responce.Content.ReadAsStringAsync().Result, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
            foreach (var item in procedurs)
            {
                Console.WriteLine($"{item.Name}, {item.Price}, {item.Time}");
            }
            Console.WriteLine("------------------");
        }
        public void ShowFreeDates()
        {
            using var client = new HttpClient();
            var responce = client.GetAsync($"{Constants.BaseURL}/api/record/week").Result;
            var responseContent = responce.Content.ReadAsStringAsync().Result;
            var records = JsonSerializer.Deserialize<List<RecordTuppleResponse>>(responseContent, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
            Console.WriteLine("Я работа с 10 - 18, но у меня уже есть записи на такое то время");
            foreach (var item in records.OrderBy(item => item.RecordStart))
            {
                Console.WriteLine($"{item.RecordStart} - {item.RecordEnd}");
            }
            Console.WriteLine("-------------------");
        }
        public void CreateNewRecord(string userPhone)
        {
            using var client = new HttpClient();
            string procedurName = "";
            DateTime date = new DateTime();
            while (true)
            {
                Console.WriteLine("Введите название процедуры");
                procedurName = Console.ReadLine();
                var responce = client.GetAsync($"{Constants.BaseURL}/api/procedur/{procedurName}").Result;
                var procedur = JsonSerializer.Deserialize<Procedur>(responce.Content.ReadAsStringAsync().Result, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });
                if(procedur != null)
                {
                    break;
                }

            }
            while (true)
            {
                Console.WriteLine("Введите дату");
                string dateString = Console.ReadLine();
                if (DateTime.TryParse(dateString, out date))
                {
                    break;
                }
                
              
            }
            var record = new Record() { Procedur = procedurName, DateTime = date, UserPhone = userPhone, IsApproved = false };
            client.PostAsync($"{Constants.BaseURL}/api/record/record", JsonContent.Create(record)).Wait();
            Console.WriteLine("Запись добавлена");
        }
        public void ShowFutureRecord(User user)
        {
            using var client = new HttpClient();
            var responce = client.GetAsync($"{Constants.BaseURL}/api/record/future/{user.Phone}").Result;
            var records = JsonSerializer.Deserialize<List<Record>>(responce.Content.ReadAsStringAsync().Result, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
            foreach(var item in records)
            {
                Console.WriteLine($"{item.DateTime}, {item.Procedur}, {item.IsApproved}");
            }
        }
        public void CancelRecord(User user)
        {
            int index = 1;
            using var client = new HttpClient();
            var responce = client.GetAsync($"{Constants.BaseURL}/api/record/future/{user.Phone}").Result;
            var records = JsonSerializer.Deserialize<List<Record>>(responce.Content.ReadAsStringAsync().Result, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
            foreach (var item in records)
            {
                Console.WriteLine($"{index++} : {item.DateTime}, {item.Procedur}, {item.IsApproved}");
            }
            while (true)
            {
                Console.WriteLine("Введите число которое хотите удалить");
                if(int.TryParse(Console.ReadLine(), out index))
                {
                    if(index > 0 && index <= records.Count())
                    {
                        break;
                    }
                }
            }
            var record = records[index - 1];
            client.DeleteAsync($"{Constants.BaseURL}/api/record/{record.Id}").Wait();
            Console.WriteLine("Ваша дата успешно удалена");
        }
        public void ShowPastRecord(User user)
        {
            using var client = new HttpClient();
            var responce = client.GetAsync($"{Constants.BaseURL}/api/record/history/{user.Phone}").Result;
            var records = JsonSerializer.Deserialize<List<Record>>(responce.Content.ReadAsStringAsync().Result, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
            foreach (var item in records)
            {
                Console.WriteLine($"{item.DateTime}, {item.Procedur}, {item.IsApproved}");
            }
        }
    }
}
