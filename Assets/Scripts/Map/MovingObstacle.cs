using UnityEngine;
using UnityEngine.UIElements;

public class MovingObstacle : MonoBehaviour
{
    // Tableau contenant les deux extrémités à ne pas dépasser
    public Transform[] waypoints;
    public float speed;

    private Transform target;
    private int destPoint = 0;


    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        // Récupère la distance entre l'obstacle et une des extremités
        Vector3 dir = target.position - transform.position;

        // Déplace l'obstacle vers l'extremité
        transform.Translate(dir.normalized * (speed * Time.deltaTime), Space.World);

        // Lorsque l'obstacle est assez proche de l'extremité
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            // On passe à l'autre extremité
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
        }
    }
}
