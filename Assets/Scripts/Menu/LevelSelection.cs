using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{

    public void LoadLevel(int lvlIndex)
    {
        SceneManager.LoadScene(lvlIndex);
    }
    
}
