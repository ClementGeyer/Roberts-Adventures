using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ProjectileWarning : MonoBehaviour
{
    public Image warning;
    public float onScreenTime;
    public float minFlickerSpeed = 0.1f;
    public float maxFlickerSpeed = 1.0f;
    
    /// <summary>
    /// Start est appelé avant que la première frame se mette à jour
    /// </summary>
    void Start()
    {
        // Supprime le warning après un certain temps
        Destroy(warning, onScreenTime);
    }

    /// <summary>
    /// Update est appelé à chaque frame
    /// </summary>
    private void Update()
    {
        if (warning != null)
        {
            // Fait clignoter le warning
            var color = warning.color;
            warning.color = new Color(color.r, color.g, color.b, Random.Range(minFlickerSpeed, maxFlickerSpeed));
        }
    }
}
