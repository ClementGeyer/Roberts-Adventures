using TMPro;
using UnityEngine;

namespace Controller
{
    public class TextsTutorial : MonoBehaviour
    {

        public GameObject player;

        public TextMeshPro text;
        public Transform waypoint;

        private Transform hud;
        
        private float distance;
        private float minimumDistance = 14f;
        private bool spawned = false;

        /// <summary>
        /// Start est appelé au premier frame
        /// </summary>
        void Start()
        {
            player = GameObject.FindWithTag("Player");
            hud = GameObject.Find("Canvas").transform;
        }
 
        /// <summary>
        /// Update est appelé à chaque frame
        /// </summary>
        void Update()
        {
            if (!spawned)
            {
                distance = Vector3.Distance(player.transform.position, waypoint.position);
                if (distance <= minimumDistance)
                {
                    var positionHud = hud.position;
                    TextMeshPro textHud = Instantiate(text, new Vector3(positionHud.x-1, positionHud.y-5, positionHud.z), Quaternion.identity);
                    textHud.GetComponent<Transform>().SetParent(hud.transform);
                    Destroy(textHud, 3);
                    spawned = true;
                }
            }

        }
    }
}
