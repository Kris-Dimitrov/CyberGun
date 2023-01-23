using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpticItem : MonoBehaviour, IItem
{
    public int Level { get; set; }
    public string Name { get; set; }
    public Dictionary<IItem.Buffs, int> Attributes { get; set; }

    public enum Buffs
    {
        Damage,
        ShotSpeed,
        Multishot,
        ShotDelay
    }
    public void Generate()
    {

    }

    public void Recycle()
    {

    }
}
