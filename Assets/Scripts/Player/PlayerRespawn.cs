using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public static bool levelEnded;
    public static bool playerDead = false;
   
    private int currentNbRespawn;
    private int RepsawnDelayBuffer;
    int luckyDay;
    private GameObject[] goToRespawn;

    /// <summary>
    /// Se lance une fois au début
    /// </summary>
    void Start()
    {
         luckyDay = Random.Range(0, 10);
         sf_canvas.SetActive(false);
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
        if(!sf_player.activeSelf && !levelEnded)
        {
            playerDead = true;
            if (luckyDay == 2 && respawnDelay <= 0)
            {
                sf_canvas.SetActive(true);
                camera.setShouldMove(false);
                //Si le joueur à trouvé la bonne réponse
                if (sf_script.userFindTrueRep() == 1)
                {

                    //On fait respawn le joueur
                    sf_canvas.SetActive(false);
                    camera.setShouldMove(true);
                    camera.speedCamera = camera.SpeedCameraBuff;
                    sf_player.SetActive(true);
                    PlayerCollisionDetection.setInvicible(true);
                    sf_script.DieQuestion();
                    luckyDay = Random.Range(0, 3);
                }
                //Si le joueur à faux
                else if (sf_script.userFindTrueRep() == -1)
                {
                    if (!sf_player.activeSelf && currentNbRespawn < numberOfRespawnMax && startDelay <= 0 &&
                        respawnDelay <= 0)
                    {

                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                        //On reprends une quetsion au hasard que l'on affichera pas avant la prochaine mort
                        sf_script.DieQuestion();
                        luckyDay = Random.Range(0, 3);
                    }
                }
                else if (respawnDelay <= 0 && !levelEnded)
                {
                    sf_canvas.SetActive(false);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
    public static void EndLevel(){
         levelEnded = true;
    }
}
