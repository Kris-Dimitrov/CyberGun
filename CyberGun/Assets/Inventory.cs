using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public CoreItem core;
    public OpticItem optic;
    public HandleItem handle;
    public BarrelItem barrel;

    int permaDamage = 0;
    int permaShotDelay = 0;
    int permaMagazineSize = 0;
    int permaReloadSpeed = 0;

    private Dictionary<string, int> attributes = new Dictionary<string, int>();

    public void Start()
    {
        core = new CoreItem("Default Core", 1, "HitScan");
        optic = new OpticItem("Default Optic", 1);
        handle = new HandleItem("Default Handle", 1);
        barrel = new BarrelItem("Barrel Handle", 1);
        CheckStats();
    }

    public Dictionary<string, int> CheckStats() 
    {
        attributes.Clear();
        AddBaseStats();

        Debug.Log(core.Name);

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

        return attributes;
    }

    public void AddBaseStats() 
    {
        attributes.Add("Damage", 1);
        attributes.Add("ShotSpeed", 1);
        attributes.Add("MagazineSize", 1);
        attributes.Add("ReloadSpeed", 1);
    }

    public void ApplyPermaBuffs() 
    {
        
    }
}
