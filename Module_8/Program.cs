namespace Module_8;

class Program
{
    static void Main(string[] args)
    {
        var file = @"/Users/a.chaturov/BinaryFile.bin";

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