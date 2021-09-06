using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {
        /// <summary>
        /// Получения списка дисков и файлов на выбранном диске.
        /// </summary>
        /// <param name="nameOfDrive">Имя метода</param>
        /// <returns>Возвращает имя диска</returns>
        public static string GetDrives1(ref string nameOfDrive)
        {
            try
            {
                DriveInfo[] drivesOnPC = DriveInfo.GetDrives();
                // Получение имен дисков в массиве класса DriveInfo.
                int k;
                int num = 1;
                foreach (DriveInfo drInform in drivesOnPC)
                {
                    Console.WriteLine(num + $")Название: {drInform.Name}");
                    Console.WriteLine($"Тип: {drInform.DriveType}");
                    num++;
                    if (drInform.IsReady)
                    {
                        Console.WriteLine($"Объем диска: {drInform.TotalSize}");
                        Console.WriteLine($"Свободное пространство: {drInform.TotalFreeSpace}");
                        Console.WriteLine($"Метка: {drInform.VolumeLabel}");
                    }
                    Console.WriteLine();
                }
                do
                {
                    Console.WriteLine("Введи номер диска, о котором хочешь узнать");
                } while (!int.TryParse(Console.ReadLine(), out k) || k < 1 || k > drivesOnPC.Length);
                // Метод по выбору диска для просмотра его папок и файлов.
                for (; ; )
                {
                    nameOfDrive = drivesOnPC[k - 1].ToString();
                    break;
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return nameOfDrive;
        }
        /// <summary>
        /// Метод, выводящий список файлов на диске.
        /// </summary>
        /// <param name="nameOfDrive">Имя диска</param>
        /// <returns>Выводит папки или файлы на диске</returns>
        public static void DirSelection(string nameOfDrive)
        {
            try
            {
                if (nameOfDrive == "")
                {
                    do
                    {
                        Console.WriteLine("Введи имя диска для его просмотра");
                        nameOfDrive = Console.ReadLine();
                    } while (!Directory.Exists(nameOfDrive));
                    // Проверка файла на существование.
                }
                for (; ; )
                {
                    int num, temp, count;
                    count = 0;
                    string[] listOfDirectories = Directory.GetDirectories(nameOfDrive);
                    string[] listOfFiles = Directory.GetFiles(nameOfDrive);
                    // Получения в строковый массив списка файлов и директорий.
                    num = 1;
                    do
                    {
                        Console.WriteLine("\nВведи 1, чтобы увидеть список директорий\n" +
                            "Введи 2 для просмотра файлов");
                    } while (!int.TryParse(Console.ReadLine(), out temp) || temp < 1 || temp > 2);
                    if (temp == 1)
                    {
                        Console.WriteLine($"\nДиректории диска {nameOfDrive}: \n");
                        foreach (string strOfDir in listOfDirectories)
                        {
                            Console.WriteLine(num + ") " + strOfDir);
                            num++;
                        }
                        // Вывод на консоль директорий диска.
                        do
                        {
                            Console.WriteLine("Введи номер директории для ее просмотра");
                        } while (!int.TryParse(Console.ReadLine(), out count) || count < 1 || count > listOfDirectories.Length);
                        nameOfDrive = listOfDirectories[count - 1];
                    }
                    else
                    {
                        Console.WriteLine($"\nФайлы диска {nameOfDrive}:\n");
                        foreach (string strOfFile in listOfFiles)
                        {
                            Console.WriteLine(strOfFile);
                        }
                        // Вывод списка файлов на диске.
                        Console.WriteLine();
                        break;
                    }
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Метод для открытия файла в определенной кодировке.
        /// </summary>
        public static void OpenFile()
        {
            try
            {
                string nameOfFile;
                int num;
                do
                {
                    Console.WriteLine("Введи имя файла");
                    nameOfFile = Console.ReadLine();
                } while (!File.Exists(nameOfFile));
                // Проверка на существование.
                Console.WriteLine("Выбери кодировку чтения файла,введя число от 1 до 3\n" +
                    "1)UTF8\n" +
                    "2)ASCII\n" +
                    "3)Unicode\n");
                while (!int.TryParse(Console.ReadLine(), out num) || num < 1 || num > 3)
                {
                    Console.WriteLine("Введи число снова");
                }
                if (num == 1)
                {
                    string[] textOnFile = File.ReadAllLines(nameOfFile, System.Text.Encoding.UTF8);
                    for (int i = 0; i < textOnFile.Length; i++)
                    {
                        Console.WriteLine("Текст файла:\n");
                        Console.WriteLine(textOnFile[i]);
                    }
                }
                if (num == 2)
                {
                    string[] textOnFile = File.ReadAllLines(nameOfFile, System.Text.Encoding.ASCII);
                    for (int i = 0; i < textOnFile.Length; i++)
                    {
                        Console.WriteLine("Текст файла:\n");
                        Console.WriteLine(textOnFile[i]);
                    }
                }
                if (num == 3)
                {
                    string[] textOnFile = File.ReadAllLines(nameOfFile, System.Text.Encoding.Unicode);
                    for (int i = 0; i < textOnFile.Length; i++)
                    {
                        Console.WriteLine("Текст файла:\n");
                        Console.WriteLine(textOnFile[i]);
                    }
                }
                // Используя ReadAllLunes, получаем текст файла и выводим его на консоль в выбранной кодировке.
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (System.Security.SecurityException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Создание нового файла в выбранной кодировке.
        /// </summary>
        public static void CreateNewFile()
        {
            try
            {
                Console.WriteLine("Введи текст файла");
                string phrase = Console.ReadLine();
                string pathOfFile;
                int num;
                do
                {
                    Console.WriteLine("Введите путь создания файла в соответствии с вашей операционной системой\n(Без названия файла)");
                    pathOfFile = Console.ReadLine();
                } while (!Directory.Exists(pathOfFile));
                // Проверка на существование пути.
                Console.WriteLine("Введите название файла.(Пример: Text.txt)");
                pathOfFile += Path.DirectorySeparatorChar;
                // Для трансплатформенности, испольую Path.DirectorySeparatorChar.
                string newName = Console.ReadLine();
                pathOfFile += newName;
                Console.WriteLine("Выбери кодировку записи файла,введя число от 1 до 3\n" +
                     "1)UTF8\n" +
                     "2)ASCII\n" +
                     "3)Unicode\n");
                while (!int.TryParse(Console.ReadLine(), out num) || num < 1 || num > 3)
                {
                    Console.WriteLine("Введи число снова");
                }
                if (num == 1)
                {
                    File.WriteAllText(pathOfFile, phrase, System.Text.Encoding.UTF8);
                    Console.WriteLine("Файл записан, для проверки откройте его, используя программу");
                }
                if (num == 2)
                {
                    File.WriteAllText(pathOfFile, phrase, System.Text.Encoding.ASCII);
                    Console.WriteLine("Файл записан, для проверки откройте его, используя программу");
                }
                if (num == 3)
                {
                    File.WriteAllText(pathOfFile, phrase, System.Text.Encoding.Unicode);
                    Console.WriteLine("Файл записан, для проверки откройте его, используя программу");
                }
                // Создание файла с помощью WriteAllText, была выбранна эта операция, тк требовалась запись текста в файл.
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (System.Security.SecurityException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Метод для удаления файла.
        /// </summary>
        public static void DeleteFile()
        {
            try
            {
                string nameOfFile;
                do
                {
                    Console.WriteLine("Введи путь удаляемого файла");
                    nameOfFile = Console.ReadLine();
                } while (!File.Exists(nameOfFile));
                // Проверка на существование.
                File.Delete(nameOfFile);
                // Использование функции Delete для удаления файла.
                Console.WriteLine("Файл удален");
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Метод для перемещения файла.
        /// </summary>
        public static void MoveFile()
        {
            try
            {
                string nameOfFile, pathOfDirectory, pathOffile;
                for (; ; )
                {
                    Console.WriteLine("Введи путь файла");
                    pathOffile = Console.ReadLine();
                    if (File.Exists(pathOffile))
                    {
                        do
                        {
                            Console.WriteLine("Введи путь перемещения");
                            pathOfDirectory = Console.ReadLine();
                        } while (!Directory.Exists(pathOfDirectory));
                        Console.WriteLine("Введи имя файла");
                        nameOfFile = Console.ReadLine();
                        pathOfDirectory += Path.DirectorySeparatorChar + nameOfFile;
                        if (!File.Exists(pathOfDirectory))
                        {
                            File.WriteAllText(pathOfDirectory, "");
                        }
                        File.Move(pathOffile, pathOfDirectory, true);
                        // Перемещение с помощью функции Move.
                        Console.WriteLine("Перемещение выполнено");
                        break;
                    }
                    else Console.WriteLine("Файл не был найден");
                    // Использование бесконечного цикла For для того, чтобы пользователь ввел правильные данные.
                }
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (System.Security.SecurityException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Метод для копирования файла.
        /// </summary>
        public static void CopyFile()
        {
            try
            {
                string nameOfFile, pathOfDirectory, pathOffile;
                for (; ; )
                {
                    Console.WriteLine("Введи путь файла");
                    pathOffile = Console.ReadLine();
                    if (File.Exists(pathOffile))
                    {
                        do
                        {
                            Console.WriteLine("Введи путь копирования");
                            pathOfDirectory = Console.ReadLine();
                        } while (!Directory.Exists(pathOfDirectory));
                        Console.WriteLine("Введи имя файла");
                        nameOfFile = Console.ReadLine();
                        pathOfDirectory += Path.DirectorySeparatorChar + nameOfFile;
                        if (!File.Exists(pathOfDirectory))
                        {
                            File.WriteAllText(pathOfDirectory, "");
                        }
                        File.Copy(pathOffile, pathOfDirectory, true);
                        Console.WriteLine("Копирование выполнено");
                        break;

                    }
                    else Console.WriteLine("Файл не был найден");
                    // Структура кода схожа со структурой перемещения, различие лишь в функциях выполняеме кодом.
                }
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (System.Security.SecurityException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Метод для конкатенации текста файлов и вывода его на консоль.
        /// </summary>
        public static void FileConnection()
        {
            try
            {
                int num, temp, count;
                string nameOfFile;
                temp = 0;
                count = 1;
                string[] allText = new string[0];
                Console.WriteLine("Введи количество файлов");
                while (!int.TryParse(Console.ReadLine(), out num) || num > 10 || num < 2)
                {
                    Console.WriteLine("Введи число снова");
                }
                // Для облегчения работы пользователю я ограничил количество файлов.
                // При желании можно убрать ограничения и метод будет работать для любого количества файлов.
                for (int i = 0; i < num; i++)
                {
                    do
                    {
                        Console.WriteLine($"Введи путь файла №{count}");
                        nameOfFile = Console.ReadLine();
                        if (!File.Exists(nameOfFile))
                        {
                            Console.WriteLine("Путь неверен");
                        }
                        else
                        {
                            count++;
                        }
                    } while (!File.Exists(nameOfFile));
                    string[] textOnFile = File.ReadAllLines(nameOfFile);
                    Array.Resize(ref allText, allText.Length + textOnFile.Length);
                    // Использование Array.Resize для увеличения массива.
                    for (int j = 0; j < textOnFile.Length; j++)
                    {
                        allText[temp] = textOnFile[j];
                        temp++;
                    }
                    // Использование двух счетчиков было введено для того, чтобы массив AllText не был перезаписан,
                    // и не потерял текст из предыдущих файлов.
                }
                Console.WriteLine($"\nТекст {count - 1} файлов:\n");
                foreach (string let in allText)
                {
                    Console.WriteLine(let, System.Text.Encoding.UTF8);
                    Console.WriteLine();
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                do
                {
                    string nameOfDrive;
                    nameOfDrive = "";
                    int num;
                    Console.WriteLine("\t\t     Добро пожаловать в файловый менеджер!\n\n" +
                        "Для работы с дисками и выбором диска введите 1.\n" +
                        "Для выбора папки введите 2\n" +
                        "Для вывода текста файла введите 3\n" +
                        "Для создания нового файла введите 4\n" +
                        "Для удаления файла введите 5\n" +
                        "Для перемещения файла введите 6\n" +
                        "Для копирования файла введите 7\n" +
                        "Для конкатенации файлов нажмите 8\n");
                    Console.WriteLine("\t\t     Правила работы с файловым менеджером.\n\n" +
                        "1)Первые три метода выполняют информационные функции и выводят на экран,\nлишь пути выбранных папок.\n" +
                        "2)Если вы решили использовать программу не просматривая диск и директории.\n Вам придется " +
                        "вводить пути директорий, файлов в соответствии \n с операционной системой.\n" +
                        "3)Для удаления, копирования и премещения файла требуется его первоначальное\nсоздание." +
                        "Поэтому для выполнения этих действий создайте файл с помощью программы.\n" +
                        "Примеры ввода: E:\\(для Windows)\n" +
                        "               E:/(для MacOS)");
                    Console.WriteLine("\nВведи номер функции");
                    while (!int.TryParse(Console.ReadLine(), out num) || num < 1 || num > 8)
                    {
                        Console.WriteLine("Введи число снова");
                    }
                    // Проверка верности вводимого.
                    // Использование переменной Num для выбора функции.
                    if (num == 1)
                    {
                        GetDrives1(ref nameOfDrive);
                        DirSelection(nameOfDrive);

                    }
                    if (num == 2)
                    {
                        DirSelection(nameOfDrive);
                    }

                    if (num == 3)
                    {
                        OpenFile();
                    }
                    if (num == 4)
                    {
                        CreateNewFile();
                    }
                    if (num == 5)
                    {
                        DeleteFile();
                    }
                    if (num == 6)
                    {
                        MoveFile();
                    }
                    if (num == 7)
                    {
                        CopyFile();
                    }
                    if (num == 8)
                    {
                        FileConnection();
                    }
                    Console.WriteLine("\nНажмите Escape для выхода из программы.\n Для продолжения нажмите любую клавишу");
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
