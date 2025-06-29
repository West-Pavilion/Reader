namespace MangaReader
{
    internal class Program
    {
        static Config config;
        static void Main(string[] args)
        {
            string configPath = Path.Combine(System.Environment.GetEnvironmentVariable("MY_HOME") ?? "", "config.txt");
            config = new Config(configPath);
            //Console.WriteLine($"Favicon: {config.favicon}");
            //Console.WriteLine("Hello, World!");
            //Console.WriteLine("=============================");
            //Console.WriteLine(new HtmlTemplate(config).Html);
            string directoryName = System.Environment.CurrentDirectory.Substring(System.Environment.CurrentDirectory.LastIndexOf('\\') + 1);
            File.WriteAllText($"{Path.Combine(System.Environment.CurrentDirectory, directoryName)}.html", new HtmlTemplate(config).Html);
        }
    }
}
