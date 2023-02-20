using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class HandleItem : IItem
{
    public int Level { get; set; }
    public string Name { get; set; }
    public Dictionary<Buffs, int> Attributes { get; set; }
    public string FireMode { get; set; }
    public enum Buffs
    {
        MagazineSize,
        ReloadSpeed
    }
    public void Generate()
    {
        List<string> FireModes = new List<string>();
        FireModes.Add("Auto");
        FireModes.Add("Single");
        FireModes = new List<string>();
        FireModes.Add("Auto");
        FireModes.Add("Single");

        for (int i = 0; i < Level; i++)
        {
            Buffs type = (Buffs)Random.Range(0, Buffs.GetNames(typeof(Buffs)).Length);
            if (Attributes.ContainsKey(type))
            {
                Attributes[type] += Level * (int)(Random.value * 10);
            }
            else
            {
                Attributes.Add(type, Level * (int)(Random.value * 10));
            }
        }

        if (FireMode == "None")
        {
            FireMode = FireModes[Random.Range(0, FireModes.Count)];
        }
    }

    public void Recycle()
    {

    }

    public HandleItem(string name, int level, string fireMode)
    {
        Name = name;
        Level = level;
        Attributes = new Dictionary<Buffs, int>();
        FireMode = fireMode;
        Generate();
    }

    public HandleItem(string name, int level)
    {
        Name = name;
        Level = level;
        Attributes = new Dictionary<Buffs, int>();
        FireMode = "None";
        Generate();
    }

    public override string ToString()
    {
        string res = "";
        res += "Name: " +  Name + "\n";
        res += "Level: " + Level.ToString() + "\n";
        res += "FireMode: " + FireMode + "\n";
        res += "Attributes: \n";
        foreach (var type in Attributes.Keys) 
        {
            res += type.ToString()+ ": " + Attributes[type].ToString() + "\n ";
        }

        return res;
    }
}
