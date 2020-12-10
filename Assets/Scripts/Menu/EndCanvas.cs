using System;
using Controller;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndCanvas : MonoBehaviour
{
    public GameObject endMenuUI;
    public GameObject playAgainMenuUI;
    public GameObject Map;
    public GameObject UI;
    public GameObject confetti;
    public GameObject player;
    public CameraMovements cameraController;
    public TimeManager timeManager;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI tempsText;

    /// <summary>
    /// Charge le niveau suivant
    /// </summary>
    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Charge le menu principal
    /// </summary>
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    
    /// <summary>
    /// Quand le player entre dans le trigger, désactive le temps, la map, le mouvement de caméra, l'interface utilisateur et active le meni
    /// de fin de niveau et les confetis
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        timeManager.EndTimer();
        player.SetActive(false);
        Map.SetActive(false);
        UI.SetActive(false);
        endMenuUI.SetActive(true);
        confetti.SetActive(true);
        cameraController.setShouldMove(false);
        setTime();
    }

    /// <summary>
    /// Permet au joueur de rejouer le niveau
    /// </summary>
    public void PlayAgain()
    {
        endMenuUI.SetActive(false);
        confetti.SetActive(false);
        playAgainMenuUI.SetActive(true);
    }

    /// <summary>
    /// Met à jour le temps dans l'interface de fin de niveau
    /// </summary>
    public void setTime()
    {
        tempsText.text = "Temps : " + timeManager.getTimePlaying().ToString("mm':'ss'.'ff");
    }

    /// <summary>
    /// Met à jour le score dans l'interface de fin de niveau
    /// </summary>
    public void setScore()
    {
        
    }
    
}
