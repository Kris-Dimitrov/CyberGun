using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelItem : MonoBehaviour, IItem
{
    public int Level { get; set; }
    public string Name { get; set; }
    public Dictionary<Buffs, int> Attributes { get; set; }
    Dictionary<IItem.Buffs, int> IItem.Attributes { get; set; }
    public enum Buffs
    {
        Damage,
        ShotSpeed,
        Multishot,
        ShotDelay
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
}
