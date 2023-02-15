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
    [SerializeField] TMP_Text playerHealth;
    [SerializeField] TMP_Text ammo;
    [SerializeField] TMP_Text score;

    bool isInventoryOpen;
    Inventory currentPlayerInventory;
    ShootingScript shootingScript;
    PlayerHealth playerHealthScript;
    ScoreManager scoreManager;

    private void Start()
    {
        shootingScript = GameObject.FindWithTag("Player").GetComponent<ShootingScript>();
        playerHealthScript = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
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
        playerHealth.text = "HP: " + playerHealthScript.health.ToString() + "/" + playerHealthScript.maxHealth.ToString();
        ammo.text = shootingScript.currentBulletsInMagazine.ToString() + "/" + shootingScript.magazineSize.ToString();
        score.text = scoreManager.score.ToString();
    }

    private void OpenInventory() 
    {
        currentPlayerInventory = shootingScript.inventory;
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
 