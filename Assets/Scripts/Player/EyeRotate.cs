using UnityEngine;

namespace Player
{
    public class EyeRotate : MonoBehaviour
    {
        [Header("Camera Ref:")]
        public Camera m_camera;

        [Header("Transform Ref:")]
        [SerializeField] private Transform EyePivot;

        [Header("Rotation:")]
        [SerializeField] private bool rotateOverTime = true;
        [Range(0, 60)] [SerializeField] private float rotationSpeed = 4;


        /// <summary>
        ///    Rotate l'oeil en fonction de la souris
        /// </summary>
        /// <remarks>
        /// Même fonction que RotateGun, on ne peut pas utiliser la même fonction facilement.
        /// </remarks>
        /// <param name="lookPoint"> Le point à regarder</param>
        /// <param name="allowRotationOverTime"> Si l'on doit tourner en fonction du temps</param>
        void RotateEye(Vector3 lookPoint, bool allowRotationOverTime)
        {
            //On calcule la distance où l'on doit regarder
            Vector3 distanceVector = lookPoint - EyePivot.position;
            //Angle de rotation
            float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;

            //On applique la rotation
            if (rotateOverTime && allowRotationOverTime)
                EyePivot.rotation = Quaternion.Lerp(EyePivot.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotationSpeed);
            else
                EyePivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }


        /// <summary>
        /// Update est appelé à toutes les frames
        /// </summary>
        void Update()
        {
            //On prends la position de la souris
            Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
            //On tourne l'oeil
            RotateEye(mousePos, true);
        }
    }
}
