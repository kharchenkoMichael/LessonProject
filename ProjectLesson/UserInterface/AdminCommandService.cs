

using Storage;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace UserInterface
{
    public class AdminCommandService
    {
    
        public async void ApproveRecord()
        {
            int index = 1;
            using var client = new HttpClient();
            var responce = client.GetAsync($"{Constants.BaseURL}/api/record/not-approve").Result;
            var records = JsonSerializer.Deserialize<List<Record>>(responce.Content.ReadAsStringAsync().Result, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
            foreach (var item in records)
            {
                Console.WriteLine($"{index++} : {item.DateTime}, {item.Procedur},{item.UserPhone}, {item.IsApproved}");
            }
            while (true)
            {
                Console.WriteLine("Введите число которое хотите подтвердить");
                if (int.TryParse(Console.ReadLine(), out index))
                {
                    if (index > 0 && index <= records.Count())
                    {
                        break;
                    }
                }
            }
            var record = records[index - 1];
            client.PostAsync($"{Constants.BaseURL}/api/record/approve", JsonContent.Create(record)).Wait();
            Console.WriteLine("Ваша дата успешно подтверждена");
        }

        public void CancelRecord()
        {
            int index = 1;
            using var client = new HttpClient();
            var responce = client.GetAsync($"{Constants.BaseURL}/api/record/future").Result;
            var records = JsonSerializer.Deserialize<List<Record>>(responce.Content.ReadAsStringAsync().Result, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
            foreach (var item in records)
            {
                Console.WriteLine($"{index++} : {item.DateTime}, {item.Procedur},{item.UserPhone}, {item.IsApproved}");
            }
            while (true)
            {
                Console.WriteLine("Введите число которое хотите удалить");
                if (int.TryParse(Console.ReadLine(), out index))
                {
                    if (index > 0 && index <= records.Count())
                    {
                        break;
                    }
                }
            }
            var record = records[index - 1];
            client.DeleteAsync($"{Constants.BaseURL}/api/record/{record.Id}").Wait();
            Console.WriteLine("Ваша дата успешно удалена");
        }

        public void CreateNewRecord()
        {
            using var client = new HttpClient();

            string procedurName = "";
            string phone = "";
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
                if (procedur != null)
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
            while (true)
            {
                Console.WriteLine("Введите номер телефона клиента");
                phone = Console.ReadLine();
                var responce = client.GetAsync($"{Constants.BaseURL}/api/user/{phone}").Result;
                var user = JsonSerializer.Deserialize<User>(responce.Content.ReadAsStringAsync().Result, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });
                if (user != null)
                {
                    break;
                }

            }
            var record = new Record() {ProcedurId = 0, DateTime = date, UserPhone = phone, IsApproved = true }; //TODO : Chose ProcedurId
            client.PostAsync($"{Constants.BaseURL}/api/record/record", JsonContent.Create(record)).Wait();
            Console.WriteLine("Запись добавлена");
        }

        public void ShowAllFutureRecords()
        {
            using var client = new HttpClient();
            var responce = client.GetAsync($"{Constants.BaseURL}/api/record/future").Result;
            var records = JsonSerializer.Deserialize<List<Record>>(responce.Content.ReadAsStringAsync().Result, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
            foreach (var record in records.OrderBy(item => item.DateTime))
            {
                Console.WriteLine($"{record.Procedur}, {record.UserPhone}, {record.DateTime}, {record.IsApproved}");
            }
        }

        public void ShowAllHistoryRecords()
        {
            using var client = new HttpClient();
            var responce = client.GetAsync($"{Constants.BaseURL}/api/record/history").Result;
            var records = JsonSerializer.Deserialize<List<Record>>(responce.Content.ReadAsStringAsync().Result, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
            foreach(var record in records.OrderBy(item => item.DateTime))
            {
                Console.WriteLine($"{record.Procedur}, {record.UserPhone}, {record.DateTime}, {record.IsApproved}");
            }
        }

        public void ShowAllNotApproveRecord()
        {
            using var client = new HttpClient();
            var responce = client.GetAsync($"{Constants.BaseURL}/api/record/not-approve").Result;
            var records = JsonSerializer.Deserialize<List<Record>>(responce.Content.ReadAsStringAsync().Result, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
            foreach( var record in records.OrderBy(item => item.DateTime))
            {
                Console.WriteLine($"{record.Procedur}, {record.UserPhone}, {record.DateTime}, {record.IsApproved}");
            }
        }
    }
}
