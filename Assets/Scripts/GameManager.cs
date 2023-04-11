using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool isGameActive, restartGame;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;


    public void  StartGame()
    {
        isGameActive = true;
        restartGame = false;
        titleScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (restartGame == true)
        {
            Time.timeScale = 1f;
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        restartGame = true;
    }
}
