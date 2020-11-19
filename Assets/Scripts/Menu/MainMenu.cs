using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject menu;
    
    //Méthode qui permet de charger la scène de sélection de niveaux quand on appuie sur le bouton "Histoire"
    public void LoadLevelSelection()
    {
        SceneManager.LoadScene(1);
    }

    //Méthode qui permet de quitter le jeu quand on appuie sur le bouton "Quit"
    public void QuitGame()
    {
        Application.Quit();
    }

    //Méthode qui permet d'afficher le menu des options
    public void LoadOptionsMenu()
    {
        menu.SetActive(true);
    }
}
