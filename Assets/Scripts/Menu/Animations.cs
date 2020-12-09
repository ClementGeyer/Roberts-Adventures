using UnityEngine;
using UnityEngine.SceneManagement;

public class Animations : MonoBehaviour
{
    
    public Animator animator;
    
    public void InfiniteMode()
    {
        animator.SetTrigger("FullScreen");
    }

    public void OnAnimationComplete()
    {
        SceneManager.LoadScene(3);
    }
}
