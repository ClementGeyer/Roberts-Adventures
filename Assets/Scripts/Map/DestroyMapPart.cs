using UnityEngine;

public class DestroyMapPart : MonoBehaviour
{

    // Lorsque une partie de la map sort de le camera
    void OnBecameInvisible()
    {
        //Supprime le gameObject
        Destroy (gameObject);
        //Supprime l'isntance du script utilisé
        Destroy(this);
    }
}
