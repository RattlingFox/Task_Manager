using System;
using System.Collections.Generic;

class Manager // бэк программы
{
    protected List<Task> _list;

    public Manager()
    {
        _list = new List<Task>();
    }

    public void add(Task task)
    {
        _list.Add(task);
    }

    public void remove(int index)
    {
        _list.RemoveAt(index);
    }

    public List<Task> getList()
    {
        return _list;
    }

    public void edit(int index, Task task)
    {

        _list.RemoveAt(index);
        _list.Insert(index, task);
    }

    public bool isExist(int index)
    {
        return _list.Count > index && index >= 0;
    }
}
