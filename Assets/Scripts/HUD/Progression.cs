﻿﻿using UnityEngine;
using UnityEngine.UI;

public class Progression : MonoBehaviour
{

    [Header("Text to change")]
    [SerializeField] private Text sf_text;
    [Header("Transform of Start and Finish objects:")]
    [SerializeField] private Transform sf_start;
    [SerializeField] private Transform sf_finish;
    [Header("Main camera")]
    [SerializeField] private Controller.CameraMovements sf_camera;

    [Header("Transform of the player:")]
    [SerializeField] private GameObject sf_player;

    [Header("Finish Line Effects")]
    [SerializeField] private GameObject sf_particles;


    private int progression;
    private float posPlayer;
    private float length;
    private GameObject playerChild;


    /// <summary>
    /// Est appelé une fois au début
    /// </summary>
    void Start()
    {
        sf_particles.SetActive(false);//false
        sf_text.text =  0 + " %";
        length = (sf_finish.position.x - sf_start.position.x);
    }

    /// <summary>
    /// Est appelé à toutes les frames
    /// </summary>
    void Update()
    {   
        printProgression();
    }

    /// <summary>
    /// Se lance tout les 0.02 secondes (Basé sur le deltaTime)
    /// </summary>
    void FixedUpdate(){
        endAnimation();
    }

    /// <summary>
    /// Lance l'animation de fin
    /// </summary>
    void endAnimation(){
        //Si on a passé la fin
        if(posPlayer >= 99.5){
            
            sf_particles.SetActive(true);
          
            //On récupère le grapplinGun 
            playerChild = sf_player.GetComponent<Transform>().GetChild(0).gameObject;

            //On vérifie que ce dernier est bien trouvé
            if(playerChild != null)
                playerChild.SetActive(false);

            //On applique des forces pour prendre le controle du joueur et aller vers le mur
            sf_player.GetComponent<Rigidbody2D>().AddForce(Vector3.right *  1000);

            //Si on a besoin de le faire monter ou descndre en Z on applique la force
            Vector2 additionnalForce = sf_player.GetComponent<Transform>().position.y > sf_finish.position.y ? Vector3.down : Vector3.up ;
            sf_player.GetComponent<Rigidbody2D>().AddForce(additionnalForce *  1000);

            //On enlève la gravité
            if(sf_player.GetComponent<Rigidbody2D>().gravityScale != 0)
                 sf_player.GetComponent<Rigidbody2D>().gravityScale = 0;

           
        }

        if(posPlayer >= 100)
             sf_camera.setShouldMove(false);

        //Todo appeler fin
    }

    /// <summary>
    /// Affiche la progression du joueur en %
    /// </summary>
    void printProgression(){

        //On regarde si le joueur n'est pas null ou désactivé
        if(sf_player != null && sf_player.activeSelf){

            //On récupère la position en x de notre joueur vu que les niveaux sont exclusivement horizontaux
            posPlayer = sf_player.GetComponent<Transform>().position.x;

            //On regarde si il est entre la ligne d'arrivée et la ligne de fin 
            if(sf_finish.position.x > posPlayer && sf_start.position.x < posPlayer){

                //Si c'est le cas on applique un produit en croix pour avoir son avancement sur 100 et donc en %
                posPlayer -= sf_start.position.x;
                posPlayer *= 100;
                posPlayer /= length;
            }
            else if(posPlayer < sf_start.position.x ){
                posPlayer = 0;
            }   
            else {
                //Si il est à la fin, alors on lance l'animation de fin
                posPlayer = 100;
                //sf_particles.SetActive(true);
            }
            
            //On applique le résultat obtenu dans le texte de progression
            sf_text.text =  (int)posPlayer + " %";
            ProgressBar.instance.IncrementProgress(posPlayer/100);
        }
    }
}
