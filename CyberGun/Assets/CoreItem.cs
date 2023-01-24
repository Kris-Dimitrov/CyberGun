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
    public Dictionary<Buffs, int> Attributes { get; set; }
    public enum Buffs {
        Damage,
        ShotSpeed,
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

    public CoreItem(string name, int level, string type) 
    {
        Name = name;
        Level = level;
        Type = type;
        Attributes = new Dictionary<Buffs, int>();
        Generate();
    }
}
