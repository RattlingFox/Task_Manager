using System;
//using System.Collections.Generic;
using System.IO;

class Storage
{
    const string PATH = @"D:\Task Manager Directory";

    public Storage()
    {
        
    }

    public static string[] getFiles()
    {
        string[] files = Directory.GetFiles(PATH);
        return files;
    }


}