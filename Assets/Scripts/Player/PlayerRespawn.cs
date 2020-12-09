using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private new Controller.CameraMovements  camera;
    [SerializeField] private PlayerCollisionDetection  playerScript;

    [Header("GameObjects and Transform needed:")]
    [SerializeField] private GameObject sf_player;
    [SerializeField] private Transform sf_camera;
    [SerializeField] private Transform sf_start;

    [Header("Canvas questions")]
    [SerializeField] private GameObject sf_canvas;
    [SerializeField] private JsonExtractor sf_script;

    [Header("Other Parameters")]
    [SerializeField] private int respawnDelay;
    [SerializeField] private int startDelay;
    [SerializeField] private int startOffset;
    [SerializeField] private int numberOfRespawnMax;
    [SerializeField] private string tagToRespawn;

    private bool levelEnded;
   
    private int currentNbRespawn;
    private int RepsawnDelayBuffer;
    private GameObject[] goToRespawn;

    /// <summary>
    /// Se lance une fois au début
    /// </summary>
    void Start()
    {
         levelEnded = false;
         goToRespawn = GameObject.FindGameObjectsWithTag(tagToRespawn);
         RepsawnDelayBuffer = respawnDelay;
    }

    /// <summary>
    /// Est appelée à toutes les frames
    /// </summary>
    void Update()
    {
         respawnPlayer();
        if(levelEnded){
            //todo make spawn finish stuff
        }

    }

    /// <summary>
    /// Se lance tout les 0.02 secondes (Basé sur le deltaTime)
    /// </summary>
    void FixedUpdate()
    {
        //On décrémente le délai du start
        if(startDelay>0)
            startDelay--;

        //On regarde si on doit décrémenter le délai de respawn
        if(respawnDelay > 0 && !sf_player.activeInHierarchy){
            respawnDelay--;
        }
      
    }

    /// <summary>
    /// Procédure qui va regarder si le joueur à besoin de respawn ou non
    /// Lance également les questions lorsque l'on meurt
    /// </summary>
    void respawnPlayer(){
        
        //Si le joueur est mort et que le niveau n'est pas fini
        if(!sf_player.activeSelf && !levelEnded){
            sf_canvas.SetActive(true);

            //Si le joueur à trouvé la bonne réponse
            if(sf_script.userFindTrueRep() == 1){
                //On fait respawn le joueur
                sf_canvas.SetActive(false);
                sf_player.SetActive(true);
                sf_script.DieQuestion();
            }
            //Si le joueur à faux
            else if(sf_script.userFindTrueRep() == -1){
                if(!sf_player.activeSelf && currentNbRespawn < numberOfRespawnMax && startDelay <= 0 && respawnDelay<=0){
                    respawnDelay = RepsawnDelayBuffer;
                    currentNbRespawn++;

                    //On reset tous les objets détruits 
                    foreach(GameObject respawn in goToRespawn)
                        if(!respawn.activeSelf)
                            respawn.SetActive(true);

                    //On remet les valeurs à un état normal
                    sf_camera.position = new Vector3(sf_start.position.x + startOffset,sf_camera.position.y, sf_camera.position.z) ;
                    sf_player.GetComponent<Transform>().position = sf_start.position;
                    sf_canvas.SetActive(false);
                    sf_player.SetActive(true);
                    camera.setShouldMove(true);
                    camera.speedCamera = camera.SpeedCameraBuff;
                    playerScript.setDead(false);

                    //On reprends une quetsion au hasard que l'on affichera pas avant la prochaine mort
                    sf_script.DieQuestion();
                }
            }
        }

    }

    /// <summary>
    /// Set juste la valeur de niveau fini à true
    /// <remark>
    /// Est utilisée par d'autres scripts pour signifier que c'est la fin du niveau
    /// </remark>
    /// </summary>
    void EndLevel(){
         levelEnded = true;
    }
}
