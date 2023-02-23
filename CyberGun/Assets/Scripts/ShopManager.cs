using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private ShootingScript shootingScript;
    [SerializeField] private int refreshPrice;
    public Dictionary<IItem, int> itemsInShop;
    public TMP_Text[] itemDisplays;
    public Canvas canvas;
    public bool isShopActive;

    private void Start()
    {
        itemsInShop = new Dictionary<IItem, int>();
        refreshPrice = 10;
        canvas.enabled = false;
        isShopActive = false;
    }
    private void Update()
    {
        ManageInputs();
    }
    public void DisplayShop()
    {
        canvas.enabled = true;
        isShopActive = true;
        RefreshShop();
    }
    public void RefreshShop() 
    {
        for (int i = 0; i < itemDisplays.Length; i++)
        {
            KeyValuePair<IItem, int> item = GenerateNewShopItem();
            Debug.Log(item.Key.ToString());
            Debug.Log(item.Value);
            itemsInShop.Add(item.Key, item.Value);
            itemDisplays[i].text = item.ToString();
            itemDisplays[i].text += "Price: " + item.Value;
        }
    }
    private void ManageInputs() 
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && isShopActive)
        {
            if (TryToBuy(itemsInShop.ElementAt(0))) 
            {
                shootingScript.CheckStats();
                itemDisplays[0].enabled = false;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && isShopActive)
        {
            if (TryToBuy(itemsInShop.ElementAt(1)))
            {
                shootingScript.CheckStats();
                itemDisplays[1].enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && isShopActive)
        {
            if (TryToBuy(itemsInShop.ElementAt(2)))
            {
                shootingScript.CheckStats();
                itemDisplays[2].enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && isShopActive)
        {
            if (TryToBuy(itemsInShop.ElementAt(3)))
            {
                shootingScript.CheckStats();
                itemDisplays[3].enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && scoreManager.score > refreshPrice)
        {

            refreshPrice += refreshPrice/10;
            RefreshShop();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            isShopActive = false;
            canvas.enabled = false;
        }
    }

    bool TryToBuy(KeyValuePair<IItem, int> pair) 
    {
        int price = pair.Value;
        IItem item = pair.Key;

        if (scoreManager.score >= price)
        {
            scoreManager.score -= price;

            if (item is CoreItem)
            {
                Debug.Log(((CoreItem)item).Type);
                shootingScript.inventory.core = (CoreItem)item;
            }
            else if (item is BarrelItem)
            {
                shootingScript.inventory.barrel = (BarrelItem)item;
            }
            else if (item is HandleItem)
            {
                shootingScript.inventory.handle = (HandleItem)item; 
            }
            else if (item is OpticItem)
            {
                shootingScript.inventory.optic = (OpticItem)item;
            }
            return true;
        }
        else 
        {
            return false;
        }
    }

    private KeyValuePair<IItem, int> GenerateNewShopItem() 
    {
        IItem item;

        int itemType = Random.Range(1, 5);

        if (itemType == 1)
        {
            item = new CoreItem(levelManager.round);
        }
        else if (itemType == 2)
        {
            item = new HandleItem(levelManager.round);
        }
        else if (itemType == 3)
        {
            item = new BarrelItem(levelManager.round);
        }
        else 
        {
            item = new OpticItem(levelManager.round);
        }

        int price = Random.Range(levelManager.round * 50, levelManager.round * 100);

        KeyValuePair<IItem, int> keyValuePair = new KeyValuePair<IItem, int>(item, price);

        return keyValuePair;
    }
}
