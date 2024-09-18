using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Choose a city:");
        string city = Console.ReadLine();
        string apiKey = "088cc16a30acbf478a4e1917aac174a6";  // API anahtarınızı buraya ekleyin
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                string response = await client.GetStringAsync(url);
                var data = JObject.Parse(response);
                
                Console.WriteLine($"CITY: {data["name"]}");
                Console.WriteLine($"WEATHER: {data["weather"][0]["description"]}");
                Console.WriteLine($"TEMPERATURE: {data["main"]["temp"]}°C");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Hata: {e.Message}");
            }
        }
    }
}

