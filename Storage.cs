using System;
using System.Collections.Generic;
using System.IO;

class Storage
{
    public const string PATH = @"D:\Task Manager Directory";

    public Storage()
    {
        
    }


    public static string[] getFiles()
    {
        string[] files = Directory.GetFiles(PATH);
        return files;
    }

    public static void viewFiles()
    {
        Console.WriteLine("");
        string[] filesView = Storage.getFiles();
        try
        {
            for (int indexString = 0; indexString < filesView.Length; indexString++)
            {
                Console.WriteLine(indexString + ")" + filesView[indexString]);

            }
        }
        catch (Exception)
        {
            Console.WriteLine("Error. No files in directory");
            Console.WriteLine("");
        }
        Console.WriteLine("");
    }

    public static void readFileToList(Manager manager)
    {
        Storage.viewFiles();
        UI.clear(manager);
        Console.WriteLine("Choose the file ID");
        try
        {
            string chooseFile = Storage.getFiles()[int.Parse(Console.ReadLine())];
            string[] filesRead = File.ReadAllLines(chooseFile);
            for (int indexString = 0; indexString < filesRead.Length; indexString++)
            {
                string[] words = filesRead[indexString].Split('\t');
                Task task = new Task(words[1], Convert.ToDateTime(words[0]));
                manager.add(task);
            }
            Console.WriteLine("");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Error. No file on ID");
        }
        catch (Exception)
        {
            Console.WriteLine("Error. Wrong number");
        }
    }

    public static void saveFile(Manager manager)
    {
        string[] filesSave = Storage.getFiles();
        List<Task> task = manager.getList();
        string str = Convert.ToString(task);
        Storage.viewFiles();
        Console.WriteLine(filesSave.Length + ")Create new file");
        Console.WriteLine("");
        Console.WriteLine("Change the file to overwrite, or create new.");
        while (true)
        {
            int change_int = UI.insertInt();
            if (change_int == filesSave.Length)
            {
                try
                {
                    Console.WriteLine("Enter a name for the new file");
                    string fileName = Console.ReadLine();
                    File.WriteAllText(Storage.PATH + "'\'" + fileName + ".txt", str);
                    return;
                }
                catch (Exception)
                {
                    Console.WriteLine("Error. Wrong file name. Type 'y' for repeat ");
                    if (Console.ReadLine() != "y")
                    {
                        Console.WriteLine("");
                        return;
                    }
                }
            }
            else if (manager.isExist(change_int))
            {
                File.WriteAllText(@filesSave[change_int], str);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Error. Wrong number");
                Console.WriteLine("");
                return;
            }
        }
    }
}