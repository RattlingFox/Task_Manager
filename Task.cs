using System;
//using System.Collections.Generic;

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
}
