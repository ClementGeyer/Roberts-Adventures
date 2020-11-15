using UnityEngine;

public class GrapplingRope : MonoBehaviour
{
    [Header("General Refernces:")]
    public GrapplingGun grapplingGun;
    public LineRenderer m_lineRenderer;

    [Header("General Settings:")]
<<<<<<< HEAD
    [SerializeField] private int precision = 40;
=======
    [SerializeField] private int percision = 40;
>>>>>>> b70f8da98bfdf476a968c7f806885a114c80c911
    [Range(0, 20)] [SerializeField] private float straightenLineSpeed = 5;

    [Header("Rope Animation Settings:")]
    public AnimationCurve ropeAnimationCurve;
    [Range(0.01f, 4)] [SerializeField] private float StartWaveSize = 2;
    float waveSize = 0;

    [Header("Rope Progression:")]
    public AnimationCurve ropeProgressionCurve;
    [SerializeField] [Range(1, 50)] private float ropeProgressionSpeed = 1;

    float moveTime = 0;

    [HideInInspector] public bool isGrappling = true;

<<<<<<< HEAD
    bool straightLine = true;
=======
    bool strightLine = true;
>>>>>>> b70f8da98bfdf476a968c7f806885a114c80c911

    private void OnEnable()
    {
        moveTime = 0;
<<<<<<< HEAD
        m_lineRenderer.positionCount = precision;
        waveSize = StartWaveSize;
        straightLine = false;
=======
        m_lineRenderer.positionCount = percision;
        waveSize = StartWaveSize;
        strightLine = false;
>>>>>>> b70f8da98bfdf476a968c7f806885a114c80c911

        LinePointsToFirePoint();

        m_lineRenderer.enabled = true;
    }

    private void OnDisable()
    {
        m_lineRenderer.enabled = false;
        isGrappling = false;
    }

    private void LinePointsToFirePoint()
    {
<<<<<<< HEAD
        for (int i = 0; i < precision; i++)
            m_lineRenderer.SetPosition(i, grapplingGun.firePoint.position);
        
=======
        for (int i = 0; i < percision; i++)
        {
            m_lineRenderer.SetPosition(i, grapplingGun.firePoint.position);
        }
>>>>>>> b70f8da98bfdf476a968c7f806885a114c80c911
    }

    private void Update()
    {
        moveTime += Time.deltaTime;
        DrawRope();
    }

    void DrawRope()
    {
<<<<<<< HEAD
        if (!straightLine)
        {
            if (m_lineRenderer.GetPosition(precision - 1).x == grapplingGun.grapplePoint.x) 
                straightLine = true;   
            else
                DrawRopeWaves();
=======
        if (!strightLine)
        {
            if (m_lineRenderer.GetPosition(percision - 1).x == grapplingGun.grapplePoint.x)
            {
                strightLine = true;
            }
            else
            {
                DrawRopeWaves();
            }
>>>>>>> b70f8da98bfdf476a968c7f806885a114c80c911
        }
        else
        {
            if (!isGrappling)
            {
                grapplingGun.Grapple();
                isGrappling = true;
            }
<<<<<<< HEAD

            waveSize = (waveSize > 0) ? waveSize -= Time.deltaTime * straightenLineSpeed : 0;
            m_lineRenderer.positionCount = precision ;
            DrawRopeWaves();
=======
            if (waveSize > 0)
            {
                waveSize -= Time.deltaTime * straightenLineSpeed;
                DrawRopeWaves();
            }
            else
            {
                waveSize = 0;

                if (m_lineRenderer.positionCount != 2) { m_lineRenderer.positionCount = 2; }

                DrawRopeNoWaves();
            }
>>>>>>> b70f8da98bfdf476a968c7f806885a114c80c911
        }
    }

    void DrawRopeWaves()
    {
<<<<<<< HEAD
        Vector2 offset ;
        Vector2 targetPosition ;
        Vector2 currentPosition;

        for (int i = 0; i < m_lineRenderer.positionCount; i++)
        {
            float delta = (float)i / ((float)precision - 1f);
            offset = Vector2.Perpendicular(grapplingGun.grappleDistanceVector).normalized * ropeAnimationCurve.Evaluate(delta) * waveSize;
            targetPosition = Vector2.Lerp(grapplingGun.firePoint.position, grapplingGun.grapplePoint, delta) + offset;
            currentPosition = Vector2.Lerp(grapplingGun.firePoint.position, targetPosition, ropeProgressionCurve.Evaluate(moveTime) * ropeProgressionSpeed);
=======
        for (int i = 0; i < percision; i++)
        {
            float delta = (float)i / ((float)percision - 1f);
            Vector2 offset = Vector2.Perpendicular(grapplingGun.grappleDistanceVector).normalized * ropeAnimationCurve.Evaluate(delta) * waveSize;
            Vector2 targetPosition = Vector2.Lerp(grapplingGun.firePoint.position, grapplingGun.grapplePoint, delta) + offset;
            Vector2 currentPosition = Vector2.Lerp(grapplingGun.firePoint.position, targetPosition, ropeProgressionCurve.Evaluate(moveTime) * ropeProgressionSpeed);
>>>>>>> b70f8da98bfdf476a968c7f806885a114c80c911

            m_lineRenderer.SetPosition(i, currentPosition);
        }
    }

    void DrawRopeNoWaves()
    {
        m_lineRenderer.SetPosition(0, grapplingGun.firePoint.position);
        m_lineRenderer.SetPosition(1, grapplingGun.grapplePoint);
    }
}
