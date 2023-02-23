using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button StartGame;
    [SerializeField] Button EndGame;
    // Start is called before the first frame update
    void Start()
    {
        StartGame.onClick.AddListener(GameStart);
        EndGame.onClick.AddListener(Quit);
    }

    void GameStart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
