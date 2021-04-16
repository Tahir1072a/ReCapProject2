using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var result = NewPath(file);
            try
            {
                var sourcePath = Path.GetTempFileName();
                if (file.Length > 0)
                    using (var stream = new FileStream(sourcePath, FileMode.Create))
                        file.CopyTo(stream);
                File.Move(sourcePath, result.newPath);    
                
            }
            catch (Exception e)
            {
               return e.Message;
            }
            return result.path2;
        }

        public static void Delete(string path)
        {
            try
            {
                string deletedPath = Environment.CurrentDirectory + @"\wwwroot" + path;
                File.Delete(deletedPath);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static (string newPath, string path2) NewPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            var newPath = Guid.NewGuid() + fileExtension;

            string path = Environment.CurrentDirectory + @"\wwwroot\Images";

            string result = $@"{path}\{newPath}";

            return (result, $"\\Images\\{newPath}");
        }
    }
}
