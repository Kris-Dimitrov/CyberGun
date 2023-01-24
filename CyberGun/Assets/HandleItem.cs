using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleItem : IItem
{
    public int Level { get; set; }
    public string Name { get; set; }
    public Dictionary<Buffs, int> Attributes { get; set; }
    public enum Buffs
    {
        MagazineSize,
        ReloadSpeed
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

    public HandleItem(string name, int level)
    {
        Name = name;
        Level = level;
        Attributes = new Dictionary<Buffs, int>();
        Generate();
    }
}
