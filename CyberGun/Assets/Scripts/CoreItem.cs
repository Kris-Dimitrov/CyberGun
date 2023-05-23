using JetBrains.Annotations;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreItem : IItem
{
    public int Level { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public Dictionary<string, int> Attributes { get; set; }
    public string[] Buffs { get; set; }

    public void Generate()
    {
        Buffs = new string[] { "Damage", "ShotSpeed", "ShotDelay" };

        List<string> Types = new List<string>();
        Types.Add("Hitscan");
        Types.Add("Projectile");

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

        if (Type == "None")
        {
            Type = Types[Random.Range(0, Types.Count)];
        }
    }

    public void Recycle()
    {

    }

    public CoreItem(string name, int level, string type) 
    {
        Name = name;
        Level = level;
        Type = type;
        Attributes = new Dictionary<string, int>();
        Generate();
    }

    public CoreItem(string name, int level)
    {
        Name = name;
        Level = level;
        Type = "None";
        Attributes = new Dictionary<string, int>();
        Generate();
    }

    public CoreItem(int level)
    {
        Name = "New Core";
        Level = level;
        Type = "None";
        Attributes = new Dictionary<string, int>();
        Generate();
    }

    public override string ToString()
    {
        string res = "";
        res += "Name: " + Name + "\n";
        res += "Level: " + Level.ToString() + "\n";
        res += "Type: " + Type + "\n";
        res += "Attributes: \n";
        foreach (var type in Attributes.Keys)
        {
            res += type.ToString() + ": " + Attributes[type].ToString() + "\n ";
        }

        return res;
    }
}
