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


        void RotateEye(Vector3 lookPoint, bool allowRotationOverTime)
        {
            Vector3 distanceVector = lookPoint - EyePivot.position;
            float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;

            if (rotateOverTime && allowRotationOverTime)
                EyePivot.rotation = Quaternion.Lerp(EyePivot.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotationSpeed);
            else
                EyePivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }


        // Update is called once per frame
        void Update()
        {
            Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
            RotateEye(mousePos, true);
        }
    }
}
