using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaReader
{
    internal class HtmlTemplate
    {
        // 辅助方法：生成图片标签
        private static string GenerateImageTags()
        {
            // 1. 获取程序当前运行的目录
            string currentDirectory = Environment.CurrentDirectory;

            // 2. 定义支持的图片文件后缀名
            var imageExtensions = new string[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };

            // 3. 查找所有图片文件，并按文件名排序
            var imageFiles = Directory.EnumerateFiles(currentDirectory)
                                      .Where(file => imageExtensions.Contains(Path.GetExtension(file).ToLowerInvariant()))
                                      .OrderBy(file => file);

            // 4. 为每个图片文件生成一个 <img> 标签
            // 使用 StringBuilder 比简单的字符串拼接性能更好
            var htmlBuilder = new StringBuilder();
            foreach (var imageFile in imageFiles)
            {
                // 在内插字符串中，花括号需要写成双花括号 {{ }} 来转义
                htmlBuilder.AppendLine(@$"  <img src=""{imageFile}"" alt=""Image"">");
            }

            return htmlBuilder.ToString().TrimEnd();
        }
        public HtmlTemplate(Config config)
        {
            if (string.IsNullOrEmpty(Html))
            {
                string imageTags = GenerateImageTags();
                string directoryName = System.Environment.CurrentDirectory.Substring(System.Environment.CurrentDirectory.LastIndexOf('\\') + 1);
                Html = @$"<!DOCTYPE html>
<html>
<head>
  <title>{directoryName}</title>
  <link rel=""icon"" type=""image/x-icon"" href=""{config.favicon}"" />
  <link rel=""stylesheet"" type=""text/css"" href=""{config.stylesheet}"" />
  <style>
    img {{
      display: block;
      padding: 12px;
      max-width: 964px;
      max-height: 1350px;
    }}
  </style>
  <script>
    window.onload = function() {{
      var img = document.getElementsByTagName(""img"")[0];
      if (img) {{
        document.querySelector('.sni').style.width = img.width + 20 + 'px';
      }}
    }};
  </script>
</head>
<body>
  <div class=""sni"">
  <font color=""#f1f1f1"" size=""1""><h1>{directoryName}</h1></font>
{imageTags}
  <br />
  <a href=""javascript:void(0);"" style=""color: #f1f1f1;"">Created by West-Pavilion</a>
  </div>
</body>
</html>
";
            }
        }
        public HtmlTemplate(string template) { }
        private string _html;
        public string Html
        {
            get { return _html; }
            set { _html = value; }
        }
    }
}
