using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpticItem : IItem
{
    public int Level { get; set; }
    public string Name { get; set; }
    public Dictionary<string, int> Attributes { get; set; }
    public string[] Buffs { get; set; }

    public string Type { get; set; }

    public void Generate()
    {
        Buffs = new string[] { "Damage", "ShotSpeed", "Multishot", "ShotDelay" };
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
    }

    public void Recycle()
    {

    }

    public OpticItem(string name, int level)
    {
        Name = name;
        Level = level;
        Attributes = new Dictionary<string, int>();
        Generate();
    }

    public OpticItem(int level)
    {
        Name = "New Optic";
        Level = level;
        Attributes = new Dictionary<string, int>();
        Generate();
    }

    public override string ToString()
    {
        string res = "";
        res += "Name: " + Name + "\n";
        res += "Level: " + Level.ToString() + "\n";
        res += "Attributes: \n";
        foreach (var type in Attributes.Keys)
        {
            res += type.ToString() + ": " + Attributes[type].ToString() + "\n ";
        }

        return res;
    }
}
