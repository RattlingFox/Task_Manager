using System;
using System.Collections.Generic;

class Task //тип элементов списка
{
    public string _subject;
    public DateTime _date;

    public Task(string subject, DateTime date)
    {
        _subject = subject;
        _date = date;
    }

    public string toString()
    {
        return _date.ToString("d") + " " + _subject;
    }

    public static string convertToFile(List<Task> task)
    {
        string result = "";
        for (int i = 0; i < task.Count; i++)
            result += task[i].convert() + "\n";
        return result;
    }

    public string convert()
    {
        return _date.ToString("d") + "\t" + _subject;
    }
}
