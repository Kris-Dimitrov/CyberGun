using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    public int Level { get; set; }
    public string Name { get; set; }
    public enum Buffs { }
    public void Generate()
    {
        // gets overriden by inherited classes in order to generate specific 
    }
    public void Recycle()
    {
        // Deletes item, grants player permanent stats based on the level of the item 
    }
}
