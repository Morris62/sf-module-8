namespace Module_8;

class Program
{
    static void Main(string[] args)
    {
        string tempFile = Path.GetTempFileName();
        var fileInfo = new FileInfo(tempFile);
        
        using (var sw = fileInfo.CreateText())
        {
            sw.WriteLine("Олег");
            sw.WriteLine("Дмитрий");
            sw.WriteLine("Иван");
        }
        
        using (var sr = fileInfo.OpenText())
        {
            string? line = "";
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        try
        {
            var tempFile2 = Path.GetTempFileName();
            var fileInfo2 = new FileInfo(tempFile2);
            fileInfo2.Delete();
            fileInfo.CopyTo(tempFile2);
            Console.WriteLine($"Файл {tempFile} скопирован в {tempFile2}");
            fileInfo.Delete();
            Console.WriteLine($"Файл {tempFile} удален");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        var fileProgram = @"/Users/a.chaturov/RiderProjects/learning/SkillFactory/Module_8/Module_8/Program.cs";
        using (var sr = File.OpenText(fileProgram))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string? line = "";
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            Console.ResetColor();
        }
    }
}