using System;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using Microsoft.Extensions.FileProviders;

namespace FileReaderUtility
{
    public class ReadFiles
    {
        public static String ReadTextFile(String filePath)
        {

            try
            {
                Console.Out.WriteLine("PATH DU FICHIER: " + filePath);

                string contents;
                var fileStream = new FileStream(@filePath, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    contents = streamReader.ReadToEnd();

                   
                }

                if ((System.IO.File.Exists(filePath)))
                {
                    System.IO.File.Delete(filePath);
                }

                Console.Out.WriteLine("CONTENU DU FICHIER: " + contents);
                return contents;

            }
            catch (IOException e) {

                Console.Out.WriteLine("MESSAGE ERREUR: "+e.Message);
                return null;
            }

        }

        public static String ReadXMLFile(String filePath)
        {
            return ReadTextFile(filePath);
        }

        public static String ReadJSONFile(String filePath)
        {
            return "";
        }

    }
}
