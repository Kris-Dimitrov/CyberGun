using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class HandleItem : IItem
{
    public int Level { get; set; }
    public string Name { get; set; }
    public Dictionary<string, int> Attributes { get; set; }
    public string[] Buffs { get; set; }
    public string Type { get; set; }
    public void Generate()
    {
        Buffs = new string[] { "MagazineSize", "ReloadSpeed" };
        List<string> Types = new List<string>() { "Auto", "Single" };
        
        for (int i = 0; i < Level; i++)
        {
            string type = Buffs[Random.Range(0, Buffs.Length)];
            if (Attributes.ContainsKey(type))
            {
                Attributes[type] += Level * Random.Range(1, 3);
            }
            else
            {
                Attributes.Add(type, Level * Random.Range(1, 3));
            }
        }

        if ( Type == "None")
        {
            Type = Types[Random.Range(0, Types.Count)];
        }
    }

    public void Recycle()
    {

    }

    public HandleItem(string name, int level, string type)
    {
        Name = name;
        Level = level;
        Attributes = new Dictionary<string, int>();
        Type = type;
        Generate();
    }
    public HandleItem(string name, int level)
    {
        Name = name;
        Level = level;
        Attributes = new Dictionary<string, int>();
        Type = "None";
        Generate();
    }
    public HandleItem(int level) 
    {
        Name = "New Handle";
        Level = level;
        Attributes = new Dictionary<string, int>();
        Type = "None";
        Generate();
    }
    public override string ToString()
    {
        string res = "";
        res += "Name: " +  Name + "\n";
        res += "Level: " + Level.ToString() + "\n";
        res += "Type: " + Type + "\n";
        res += "Attributes: \n";
        foreach (var type in Attributes.Keys) 
        {
            res += type.ToString()+ ": " + Attributes[type].ToString() + "\n ";
        }

        return res;
    }
}
