using System.Text.Json;

namespace Module_8;

class Program
{
    private static readonly string file = @"/Users/a.chaturov/BinaryFile.bin";
    
    [Serializable]
    class Pet
    {
        public string Name{ get; set;}
        public int Age { get; set; }
        public Pet(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    
    static void Main(string[] args)
    {
        WriteValues();
        ReadValues();

        var pet = new Pet(name: "Max", age: 3);
        // сериализация
        var options = new JsonSerializerOptions{WriteIndented = true};
        var jsonString = JsonSerializer.Serialize(pet, options);
        File.WriteAllText("myPets.json", jsonString);
        Console.WriteLine("Объект сериализован");
        
        jsonString = File.ReadAllText("myPets.json");
        var newPet = JsonSerializer.Deserialize<Pet>(jsonString);
        Console.WriteLine("Объект десериализован");

        Console.WriteLine($"Имя {newPet.Name} - возраст {newPet.Age}");

    }
    private static void WriteValues()
    {
        using (var bw = new BinaryWriter(File.Open(file, FileMode.OpenOrCreate)))
        {
            bw.Write($"Файл изменен {DateTime.Now} на компьютере {Environment.OSVersion}");
        }
    }
    private static void ReadValues()
    {
        if (File.Exists(file))
        {
            using (var br = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                string str = br.ReadString();
                Console.WriteLine($"{str}");
            }
        }
    }
}