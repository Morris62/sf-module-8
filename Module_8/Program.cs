namespace Module_8;

class Program
{
    static void Main(string[] args)
    {
        var drives = DriveInfo.GetDrives();

        foreach (var drive in drives)
        {
            Console.WriteLine($"Название: {drive.Name}");
            Console.WriteLine($"Тип: {drive.DriveType}");
            Console.WriteLine($"Формат: {drive.DriveFormat}");

            if (drive.IsReady)
            {
                Console.WriteLine($"Метка: {drive.VolumeLabel}");
                Console.WriteLine($"Объем: {drive.TotalSize}");
                Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
                Console.WriteLine($"Доступно: {drive.AvailableFreeSpace}");
            }

            Console.Write(Environment.NewLine);
        }

        GetCatalogs();
    }

    private static void GetCatalogs()
    {
        string path = @"/";

        if (Directory.Exists(path))
        {
            Console.WriteLine("Папки:");
            var dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs)
            {
                Console.WriteLine(dir);
            }
            
            Console.Write(Environment.NewLine);
            
            Console.WriteLine("Файлы:");
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}