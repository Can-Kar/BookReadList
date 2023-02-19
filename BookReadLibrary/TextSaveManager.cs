using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadLibrary
{
    public static class TextSaveManager
    {
        // private const string fileName = "BookReadData.csv";
        public static string FullFilePath = ConfigurationManager.AppSettings["filePath"] + "BookReadData.csv";
        public static string FilePath = ConfigurationManager.AppSettings["filePath"];

        /// <summary>
        /// Converts the string list to BookModel list.
        /// </summary>
        /// <param name="lines">Text lines saved inside text file.</param>
        /// <returns>Converted BookModels based on text lines.</returns>
        public static List<BookModel> ConvertToBookModels(this List<string> lines)
        {
            List<BookModel> output = new List<BookModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                BookModel b = new BookModel();
                b.Title = cols[0];
                b.Author = cols[1];
                b.Publisher = cols[2];

                output.Add(b);
            }

            return output;
        }

        /// <summary>
        /// Saves BookModels into the text file.
        /// </summary>
        /// <param name="books"></param>
        public static void SaveToFile(this List<BookModel> books)
        {
            List<string> lines = new List<string>();

            foreach (BookModel b in books)
            {
                lines.Add($"{b.Title},{b.Author},{b.Publisher}");
            }

            File.WriteAllLines(FullFilePath, lines);
        }

        /// <summary>
        /// Loads the lines from the given file as parameter
        /// </summary>
        /// <param name="file">Saved data's file path.</param>
        /// <returns>Text lines in file as List of string.</returns>
        public static List<string> LoadFile()
        {
            if (!File.Exists(FullFilePath))
            {
                return new List<string>();
            }

            return File.ReadAllLines(FullFilePath).ToList();
        }
    }
}
