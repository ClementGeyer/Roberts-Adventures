using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [Header("GameObjects and Transform needed:")]
    [SerializeField] private GameObject sf_player;
    [SerializeField] private Transform sf_camera;
    [SerializeField] private Transform sf_start;

    [Header("Other Parameters")]
    [SerializeField] private int respawnDelay;
    [SerializeField] private int startDelay;
    [SerializeField] private int startOffset;
    [SerializeField] private int numberOfRespawnMax;
    [SerializeField] private string tagToRespawn;

    private GameObject[] goToRespawn;
    private int currentNbRespawn;
    private int RepsawnDelayBuffer;
    void Start()
    {
         goToRespawn = GameObject.FindGameObjectsWithTag(tagToRespawn);
         RepsawnDelayBuffer = respawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        //Si le joueur est mort
        if(!sf_player.active && currentNbRespawn < numberOfRespawnMax && startDelay <= 0 && respawnDelay<=0){
            respawnDelay = RepsawnDelayBuffer;
            currentNbRespawn++;
             
            foreach(GameObject respawn in goToRespawn)
                if(!respawn.active)
                    respawn.active = true;

            sf_camera.position = new Vector3(sf_start.position.x + startOffset,sf_camera.position.y, sf_camera.position.z) ;
            sf_player.GetComponent<Transform>().position = sf_start.position;
            sf_player.active = true;

        }

    }

    public void killPlayer(){
        this.gameObject.SetActive(false);
        sf_player.GetComponent<Transform>().Find("GunPivot/GrapplinGun").gameObject.GetComponent<GrapplingGun>().grappleRope.enabled = false;
        sf_player.GetComponent<Transform>().Find("GunPivot/GrapplinGun").gameObject.GetComponent<GrapplingGun>().m_springJoint2D.enabled = false;
        sf_player.GetComponent<Transform>().Find("GunPivot/GrapplinGun").gameObject.GetComponent<GrapplingGun>().m_rigidbody.gravityScale = 1;
    }

    void FixedUpdate()
    {
        if(startDelay>0)
            startDelay--;

        if(respawnDelay > 0 && !sf_player.active){
            respawnDelay--;
        }
      
    }
}
