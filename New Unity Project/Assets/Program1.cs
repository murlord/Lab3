using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Program1 : MonoBehaviour
{
    public static void Main()
    {
        Hashtable ht = new Hashtable();
        ht.Add("Ray", "Level 1");
        ht.Add("Tom", "Level 2");
        ht.Add("Joe", "Level 3");
        ht.Add("Sam", "Level 1");

        string capital = (string)ht["Ray"];
        Console.WriteLine(ht.Contains("Tom"));
        ht.Remove("Joe");
        ht.Clear();
    }
}
