using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class MenuManager : MonoBehaviour
{
    [SerializeField]Canvas inventoryCanvas;
    [SerializeField] TMP_Text barrel;
    [SerializeField] TMP_Text optic;
    [SerializeField] TMP_Text core;
    [SerializeField] TMP_Text handle;

    bool isInventoryOpen;
    Inventory currentPlayerInventory;

    private void Start()
    {
        isInventoryOpen = false;
        CloseInventory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isInventoryOpen)
            {
                isInventoryOpen = !isInventoryOpen;
                CloseInventory();
            }
            else 
            {
                isInventoryOpen = !isInventoryOpen;
                OpenInventory();
            }   
        }
    }

    private void OpenInventory() 
    {
        currentPlayerInventory = GameObject.FindWithTag("Player").GetComponent<ShootingScript>().inventory;
        Debug.Log(currentPlayerInventory.core.ToString());
        inventoryCanvas.enabled = true;
        barrel.text = currentPlayerInventory.barrel.ToString();
        optic.text = currentPlayerInventory.optic.ToString();
        core.text = currentPlayerInventory.core.ToString();
        handle.text = currentPlayerInventory.handle.ToString();
    }

    private void CloseInventory() 
    {
        inventoryCanvas.enabled = false;
    }
}
