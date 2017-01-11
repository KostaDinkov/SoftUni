using System;
using System.Collections.Generic;
using System.Linq;

public class Tree<T>
{
    public T Value { get; set; }
    public List<Tree<T>> Children { get; private set; }= new List<Tree<T>>();

    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        if (children.Length != 0)
        {
            foreach (var child in children)
            {
                this.Children.Add(child);
            }
        }
            
    }

    public void Print(int indent = 0)
    {
        Console.Write(new String(' ', 2*indent));
        Console.WriteLine(this.Value);
        foreach (var child in this.Children)
        {
            child.Print(indent +1);   
        }
    }

    public void Each(Action<T> action)
    {
        action(this.Value);
        foreach (var child in this.Children)
        {
            child.Each(action);
        }
    }
}
