using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{

    public void LoadLevel(int lvlIndex)
    {
        SceneManager.LoadScene(lvlIndex);
    }

    public void backArrow()
    {
        SceneManager.LoadScene(0);
    }
}
