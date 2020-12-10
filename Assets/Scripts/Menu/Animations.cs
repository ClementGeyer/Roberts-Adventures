using UnityEngine;
using UnityEngine.SceneManagement;

public class Animations : MonoBehaviour
{
    
    public Animator animator;
    
    /// <summary>
    /// Gère le trigger de l'animation qui met le jeu en plein écran
    /// </summary>
    public void InfiniteMode()
    {
        animator.SetTrigger("FullScreen");
    }

    /// <summary>
    /// Charge la scène du mode infini
    /// </summary>
    public void OnAnimationComplete()
    {
        SceneManager.LoadScene(3);
    }
}
