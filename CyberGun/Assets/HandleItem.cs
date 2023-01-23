using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleItem : MonoBehaviour, IItem
{
    public int Level { get; set; }
    public string Name { get; set; }
    public Dictionary<IItem.Buffs, int> Attributes { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public enum Buffs
    {
        MagazineSize,
        ReloadSpeed
    }
    public void Generate()
    {

    }

    public void Recycle()
    {

    }
}
