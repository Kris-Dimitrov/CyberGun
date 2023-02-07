using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelItem : IItem
{
    public int Level { get; set; }
    public string Name { get; set; }
    public Dictionary<Buffs, int> Attributes { get; set; }
    public enum Buffs
    {
        Damage,
        ShotSpeed,
        Multishot,
        ShotDelay,
            
    }
    public void Generate()
    {
        for (int i = 0; i < Level; i++)
        {
            Buffs type = (Buffs)Random.Range(0, Buffs.GetNames(typeof(Buffs)).Length);
            if (Attributes.ContainsKey(type))
            {
                Attributes[type] += Level * 10;
            }
            else
            {
                Attributes.Add(type, Level * 10);
            }
        }
    }

    public void Recycle()
    {

    }

    public BarrelItem(string name, int level)
    {
        Name = name;
        Level = level;
        Attributes = new Dictionary<Buffs, int>();
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
