using System.Text.Json;

namespace Module_8;

class Program
{
    private static readonly string file = @"/Users/a.chaturov/BinaryFile.bin";

    [Serializable]
    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Pet(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    [Serializable]
    class Contact
    {
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(string name, long phoneNumber, string email)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public void Serilize(BinaryWriter bw)
        {
            bw.Write(Name);
            bw.Write(PhoneNumber);
            bw.Write(Email);
        }

        public static Contact Deserilize(BinaryReader br)
        {
            string name = br.ReadString();
            long phoneNumber = br.ReadInt64();
            string email = br.ReadString();

            return new Contact(name, phoneNumber, email);
        }
    }

    static void Main(string[] args)
    {
        WriteValues();
        ReadValues();

        var pet = new Pet(name: "Max", age: 3);
        // сериализация
        var options = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(pet, options);
        File.WriteAllText("myPets.json", jsonString);
        Console.WriteLine("Объект сериализован");

        jsonString = File.ReadAllText("myPets.json");
        var newPet = JsonSerializer.Deserialize<Pet>(jsonString);
        Console.WriteLine("Объект десериализован");

        Console.WriteLine($"Имя {newPet.Name} - возраст {newPet.Age}");

        var contact = new Contact(name: "Max", phoneNumber: 123456789, email: "max@mail.ru");

        using (var fs = new FileStream("contact.bin", FileMode.Create))
        using (var bw = new BinaryWriter(fs))
        {
            contact.Serilize(bw);
        }

        Contact deserilizedContact;
        using (var fs = new FileStream("contact.bin", FileMode.Open))
        using (var br = new BinaryReader(fs))
        {
            deserilizedContact = Contact.Deserilize(br);
        }
        
        Console.WriteLine($"Contact: {deserilizedContact.Name} - {deserilizedContact.PhoneNumber} - {deserilizedContact.Email}");
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