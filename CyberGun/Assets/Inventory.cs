using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    CoreItem core;
    OpticItem optic;
    HandleItem handle;
    BarrelItem barrel;

    int permaDamage = 0;
    int permaShotDelay = 0;
    int permaMagazineSize = 0;
    int permaReloadSpeed = 0;

    public Dictionary<string, int> attributes = new Dictionary<string, int>();

    public void CheckStats() 
    {
        foreach (var item in core.Attributes)
        {
            if (attributes.ContainsKey(item.Key.ToString()))
            {
                attributes[item.Key.ToString()] += item.Value;
            }
            else 
            {
                attributes.Add(item.Key.ToString(), item.Value);
            }
        }
        foreach (var item in optic.Attributes)
        {
            if (attributes.ContainsKey(item.Key.ToString()))
            {
                attributes[item.Key.ToString()] += item.Value;
            }
            else
            {
                attributes.Add(item.Key.ToString(), item.Value);
            }
        }
        foreach (var item in barrel.Attributes)
        {
            if (attributes.ContainsKey(item.Key.ToString()))
            {
                attributes[item.Key.ToString()] += item.Value;
            }
            else
            {
                attributes.Add(item.Key.ToString(), item.Value);
            }
        }
        foreach (var item in handle.Attributes)
        {
            if (attributes.ContainsKey(item.Key.ToString()))
            {
                attributes[item.Key.ToString()] += item.Value;
            }
            else
            {
                attributes.Add(item.Key.ToString(), item.Value);
            }
        }
    }
}
