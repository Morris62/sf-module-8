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

        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"/test");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            dirInfo.CreateSubdirectory("NewFolder");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        GetCatalogs();
        
        DirectoryInfo dirInfo2 = new DirectoryInfo(@"/Users/a.chaturov/test");
        if (!dirInfo2.Exists)
        {
            dirInfo2.Create();
        }
        
        dirInfo2.CreateSubdirectory("NewFolder1");
        dirInfo2.CreateSubdirectory("NewFolder2");

        Console.WriteLine($"Название каталога: {dirInfo2.Name}");
        Console.WriteLine($"Полное название каталога: {dirInfo2.FullName}");
        Console.WriteLine($"Время создания каталога: {dirInfo2.CreationTime}");
        
        var path1 = @"/Users/a.chaturov/test/NewFolder1";
        var path2 = @"/Users/a.chaturov/test/NewFolder2/NewFolder1";
        
        DirectoryInfo dirInfo3 = new DirectoryInfo(path1);
        if (dirInfo3.Exists && !Directory.Exists(path2))
        {
            dirInfo3.MoveTo(path2);
        }
        
        try
        {
            dirInfo2.Delete(true);
            Console.WriteLine($"Каталог {dirInfo2.FullName} удален");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void GetCatalogs()
    {
        string path = @"/";

        try
        {
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

                Console.Write(Environment.NewLine);

                Console.WriteLine($"Количество: {dirs.Length + files.Length}");
                
                Console.Write(Environment.NewLine);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}