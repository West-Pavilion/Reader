using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaReader
{
    internal class Config
    {
        public Config() { }
        public Config(string path) 
        {
            string config_raw = File.ReadAllText(path);
            foreach (string line in config_raw.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (line.StartsWith("favicon="))
                {
                    favicon = line.Substring("favicon=".Length).Trim();
                }
                else if (line.StartsWith("stylesheet="))
                {
                    stylesheet = line.Substring("stylesheet=".Length).Trim();
                }
                else if (line.StartsWith("indexLink="))
                {
                    indexLink = line.Substring("indexLink=".Length).Trim();
                }
            }
        }
        public string? favicon { get; set; }
        public string? stylesheet { get; set; }
        public string? indexLink { get; set; }


    }
}
