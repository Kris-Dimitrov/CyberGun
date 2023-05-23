using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Canvas inventoryCanvas;
    [SerializeField] TMP_Text barrel;
    [SerializeField] TMP_Text optic;
    [SerializeField] TMP_Text core;
    [SerializeField] TMP_Text handle;
    [SerializeField] TMP_Text playerHealth;
    [SerializeField] TMP_Text ammo;
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text scoreInShop;
    [SerializeField] RectTransform reloadMeterScale;
    [SerializeField] RectTransform dashMeterScale;

    bool isInventoryOpen;
    Inventory currentPlayerInventory;
    ShootingScript shootingScript;
    PlayerHealth playerHealthScript;
    ScoreManager scoreManager;
    PlayerMovement playerMovementScript;
    private void Start()
    {
        shootingScript = GameObject.FindWithTag("Player").GetComponent<ShootingScript>();
        playerHealthScript = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        playerMovementScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        isInventoryOpen = false;
        CloseInventory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isInventoryOpen = !isInventoryOpen;
            if (isInventoryOpen)
            {
                CloseInventory();
            }
            else 
            {
                OpenInventory();
            }   
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        }

        playerHealth.text = "HP: " + playerHealthScript.health.ToString() + "/" + playerHealthScript.maxHealth.ToString();
        ammo.text = shootingScript.currentBulletsInMagazine.ToString() + "/" + shootingScript.magazineSize.ToString();
        score.text = scoreManager.score.ToString();
        scoreInShop.text = "Score: " + scoreManager.score.ToString();
        reloadMeterScale.localScale = new Vector3(shootingScript.reloadProgress, reloadMeterScale.localScale.y); // add to start
        dashMeterScale.localScale = new Vector3(playerMovementScript.currentDashAmount /200 , dashMeterScale.localScale.y);
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
 