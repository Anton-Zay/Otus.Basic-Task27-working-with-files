using System;
using System.IO;


namespace HomeWorkOfLesson27
{
    class FileWorker
    {
        public static void CreateDir(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            try
            {
                if (di.Exists)
                {
                    Console.WriteLine("Такой каталог уже существует.");
                    return;
                }
                di.Create();
            }

            catch (Exception e)
            {
                Console.WriteLine("Возникла непредвиденная ошибка");
            }
        }

        public static void CreateFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    Console.WriteLine("Такой файл уже существует.");
                    return;
                }
                File.Create(path).Close();
            }

            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Отсутствуют права на запись");
            }
            catch (Exception e)
            {
                Console.WriteLine("Возникла непредвиденная ошибка");
            }
        }

        public static void WriteToFile(string path, string message)
        {
            try
            {
                using StreamWriter writer = new StreamWriter(path);
                {

                    writer.AutoFlush = true;
                    writer.Write(message);
                    return;
                }             
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Отсутствуют права на запись");
            }
            catch (Exception e)
            {
                Console.WriteLine("Возникла непредвиденная ошибка");
            }
        }

        public static void GetTextFromFile(string path)
        {

            if (!File.Exists(path))
            {
                Console.WriteLine("Такого файла не существует.");
                return;
            }

            try
            {
                using (StreamReader sr = new StreamReader(path))
                    Console.WriteLine($"{Path.GetFullPath(path)}: {sr.ReadToEnd()}");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Отсутствуют права на запись");
            }
            catch (Exception e)
            {
                Console.WriteLine("Возникла непредвиденная ошибка");
            }
        }
    }
}
