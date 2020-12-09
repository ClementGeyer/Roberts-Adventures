using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCanvas : MonoBehaviour
{
    public GameController gc;
    public GameObject endMenuUI;
    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Time.timeScale = 0f;
        endMenuUI.SetActive(true);
    }
}
