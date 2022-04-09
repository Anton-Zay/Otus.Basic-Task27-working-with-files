using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace HomeWorkOfLesson27
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        private void Start()
        {
            var fw = new FileWorker();

            string pathDir1 = @"c:\Otus\TestDir1";
            string pathDir2 = @"c:\Otus\TestDir2";
            FileWorker.CreateDir(pathDir1);
            FileWorker.CreateDir(pathDir2);
            MainLogigMethod(fw, pathDir1);
            MainLogigMethod(fw, pathDir2);
        }

        private void MainLogigMethod(FileWorker fw, string path)
        {                     
            for (int i = 0; i < 10; i++)
            {
                string fileName = @$"{path}\File{i + 1}.txt";

                FileWorker.CreateFile(fileName);

                byte[] bytes = Encoding.Default.GetBytes(Path.GetFileName(fileName));
                string fileNameUTF8 = Encoding.UTF8.GetString(bytes);

                DateTime dateTime = DateTime.Now;
                CultureInfo culture = new CultureInfo("ru-ru");
                string data = $"{fileNameUTF8} {dateTime.ToString("d MMMM yyyy HH:mm:ss.fff", culture)}";

                FileWorker.WriteToFile(fileName, data);
                FileWorker.GetTextFromFile(fileName);
            }
        }
    }
}
