using System;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Data.Common;
using System.Text.RegularExpressions;



class Program
{
    static async Task Main(string[] args)
    {

        // System.Net.Http (для роботи з HTTP-запитами)

        try
        {
            using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/1");
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при Http запиті: {ex.Message}");
        }
        Console.WriteLine();
        // Newtonsoft.Json (для роботи з JSON)

        string json = "{\"Name\":\"John\",\"Age\":30}";
        Console.WriteLine(json);
        Person person_1 = JsonSerializer.Deserialize<Person>(json);
        Console.WriteLine($"Class info:\nName: {person_1.Name}, Age: {person_1.Age}");
        Console.WriteLine();

        //System.IO.Compression (для роботи з архівами)

        try
        {
        string sourceDirectory = @"D:\source";
        string zipFile = @"D:\destination\archive.zip";
        ZipFile.CreateFromDirectory(sourceDirectory, zipFile);
        Console.WriteLine("Archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при створенi архiва: {ex.Message}");
        }
        Console.WriteLine();

        //System.IO (для роботи з файлами та директоріями)

        string path = @"D:\source\test.txt";
        try {
            File.WriteAllText(path, "Hello, World!");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Помилка при записі даних в файл: {ex.Message}");
        }

        if (File.Exists(path))
        {
            string content = File.ReadAllText(path);
            Console.WriteLine(content);
        }
        Console.WriteLine();

        //System.Text.RegularExpressions (для роботи з регулярними виразами)

        string input = "Hello, 65123456!";
        string pattern = @"\d+";
        Match match = Regex.Match(input, pattern);
        if (match.Success)
        {
            Console.WriteLine("Found: " + match.Value);
        }
        Console.WriteLine();

        //System.Linq (для роботи з колекціями)

        List<Person> people = new List<Person>
        {
            new Person { Name = "Alice", Age = 25 },
            new Person { Name = "Bob", Age = 30 },
            new Person { Name = "Charlie", Age = 20 },
            new Person { Name = "David", Age = 35 }
        };
        // LINQ запит для фільтрації та сортування

        var result = from person in people
                     where person.Age > 25
                     orderby person.Name
                     select person;


        foreach (var person in result)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }



    }


    class Person
    {
       
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
