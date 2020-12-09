﻿using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    [Header("Scripts Ref:")]
    public GrapplingRope grappleRope;

    [Header("Layers Settings:")]
    [SerializeField] private bool grappleToAll = false;
    [SerializeField] private string grappableTag = "";

    [Header("Main Camera:")]
    public Camera m_camera;

    [Header("Transform Ref:")]
    public Transform gunHolder;
    public Transform gunPivot;
    public Transform firePoint;

    [Header("Physics Ref:")]
    public SpringJoint2D m_springJoint2D;
    public Rigidbody2D m_rigidbody;

    [Header("Rotation:")]
    [SerializeField] private bool rotateOverTime = true;
    [Range(0, 60)] [SerializeField] private float rotationSpeed = 4;

    [Header("Distance:")]
    [SerializeField] private bool hasMaxDistance = false;
    [SerializeField] private float maxDistance = 20;

    [Header("Launching:")]
    [SerializeField] private bool launchToPoint = true;
    [SerializeField] private LaunchType launchType = LaunchType.Physics_Launch;
    [SerializeField] private float launchSpeed = 1;

    [Header("No Launch To Point")]
    [SerializeField] private bool autoConfigureDistance = false;
    [SerializeField] private float targetDistance = 3;
    [SerializeField] private float targetFrequncy = 1;

    [HideInInspector] public Vector2 grapplePoint;
    [HideInInspector] public Vector2 grappleDistanceVector;

    /// <summary>Enum qui permet de switch entre les différents types de calculs
    /// <example>Par exemple:
    /// <code>
    ///    LaunchType = Transform_Launch;
    /// </code>
    ///     Cela va résulter dans le fait d'utiliser le transform plutot que la physique.
    /// </example>
    /// </summary>
    private enum LaunchType
    {
        Transform_Launch,
        Physics_Launch
    }

    private void Start()
    {
        grappleRope.enabled = false;
        m_springJoint2D.enabled = false;
    }

    private void Update()
    {
        //Si il y a un clic
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SetGrapplePoint();
        }
        //Si le clic reste appuyé
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            //Si la corde est déjà créée on rotate le gun 
            if (grappleRope.enabled)
                RotateGun(grapplePoint, false);
            else
            {
                //Si la corde n'est pas créée on prends la position de la souris
                Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
                RotateGun(mousePos, true);
            }
            
            //Si tout est prêt pour le grappin
            if (launchToPoint && grappleRope.isGrappling && launchType == LaunchType.Transform_Launch)
            {
                //On va prendre notre position et la position de la cible
                Vector2 pos = firePoint.position - gunHolder.localPosition;
                Vector2 targetPos = grapplePoint - pos ;
                gunHolder.position = Vector2.Lerp(gunHolder.position, targetPos, Time.deltaTime * launchSpeed);
            }
        }
        //Si le clic est relaché
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            //On désactive tout
            grappleRope.enabled = false;
            m_springJoint2D.enabled = false;
            m_rigidbody.gravityScale = 1;
        }
        //Si rien ne se passe
        else
        {
            //On regarde simplement vers la souris
            Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
            RotateGun(mousePos, true);
        }
    }

    /// <summary>Méthode qui permet de rotate le gun vers un point précis
    /// <param name="lookPoint">Vector3 point où regarder.</param>   
    /// <param name="allowRotationOverTime">boolean Si on doit tourner ou pas.</param>
    /// <example>Par exemple:
    /// <code>
    ///    RotateGun(lookPoint, true);
    /// </code>
    ///    Cela va permettre de regarder vers lookpoint tout en rotate 
    /// </example>
    /// </summary>
    void RotateGun(Vector3 lookPoint, bool allowRotationOverTime)
    {
        //On calcule la distance
        Vector3 distanceVector = lookPoint - gunPivot.position;
        //On calcule l'angle
        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;

        //Si on doit rotate alors on applique la rotation sinon on regarde juste devant
        if (rotateOverTime && allowRotationOverTime)
            gunPivot.rotation = Quaternion.Lerp(gunPivot.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotationSpeed);
        else
            gunPivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    /// <summary>Méthode qui permet de set le point d'accroche du grappin
    /// </summary>
    void SetGrapplePoint()
    {
        //On prends la distance
        Vector2 distanceVector = m_camera.ScreenToWorldPoint(Input.mousePosition) - gunPivot.position;
        //On crée un raycast
        RaycastHit2D _hit = Physics2D.Raycast(firePoint.position, distanceVector);


        //Si le raycast touche et que l'object touché peut-être grapple
        if (_hit && (_hit.transform.gameObject.tag == grappableTag || grappleToAll) &&
            (Vector2.Distance(_hit.point, firePoint.position) <= maxDistance || !hasMaxDistance))
        {
            //On fixe le point de grapple
            grapplePoint = _hit.point;
            grappleDistanceVector = grapplePoint - (Vector2)gunPivot.position;
            grappleRope.enabled = true;
            //On fait jouer le son
            playGrappleSound();
        }

    }

    /// <summary>
    /// Permet de s'accrocher à un point
    /// <remarks>
    /// Utilisez SetGrapplePoint(); avant d'utiliser cette fonction
    /// </remarks>
    /// </summary>
    public void Grapple()
    {
        
        m_springJoint2D.autoConfigureDistance = false;
        if (!launchToPoint && !autoConfigureDistance)
        {
            //On configure le spring joint
            m_springJoint2D.distance = targetDistance;
            m_springJoint2D.frequency = targetFrequncy;
        }

        if (!launchToPoint)
        {
            if (autoConfigureDistance)
            {
                //On set le configureDistance de spring joint
                m_springJoint2D.autoConfigureDistance = true;
                 //On configure sa fréquence
                m_springJoint2D.frequency = 0;
            }

            //On configure le spring joint
            m_springJoint2D.connectedAnchor = grapplePoint;
            m_springJoint2D.enabled = true;
        }
        else
        {
            //En fonction de l'enum choisi
            switch (launchType)
            {
                case LaunchType.Physics_Launch:
                    //Si Physics_Launch à été choisi
                    m_springJoint2D.connectedAnchor = grapplePoint;
                    //On calcule la distance
                    Vector2 distanceVector = firePoint.position - gunHolder.position;
                    //On l'applique au joint
                    m_springJoint2D.distance = distanceVector.magnitude/2;
                    m_springJoint2D.frequency = launchSpeed;
                    m_springJoint2D.enabled = true;
                    break;
                case LaunchType.Transform_Launch:
                    //Si Transform_Launch à été choisi on enlève la gravité
                    //Car cela pourrait corrompre notre mouvement
                    //Et on set la veloicity du rb à 0
                    m_rigidbody.gravityScale = 0;
                    m_rigidbody.velocity = Vector2.zero;
                    break;
            }
        }
    }

    /// <summary>
    /// Permet de draw le raycast
    /// <remarks>
    /// Ne fonctionne que dans le mode scene de Unity.
    /// Pas sur les Builds.
    /// </remarks>
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        if (firePoint != null && hasMaxDistance)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(firePoint.position, maxDistance);
        }
    }

    /// <summary>
    /// Joue le son du grappin
    /// </summary>
    private void playGrappleSound(){
        this.gameObject.GetComponent<AudioSource>().Play();
    }

}
