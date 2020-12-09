using Controller;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndCanvas : MonoBehaviour
{
    public GameObject endMenuUI;
    public GameObject playAgainMenuUI;

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

    public void PlayAgain()
    {
        endMenuUI.SetActive(false);
        playAgainMenuUI.SetActive(true);
    }
    
    
}
