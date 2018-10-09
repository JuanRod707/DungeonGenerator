using UnityEngine;

namespace Movement
{
    public class CameraLook : MonoBehaviour
    {
        public float PitchFactor;
        
        public void Pitch(float axis)
        {
            transform.Rotate(transform.right * PitchFactor * axis * Time.deltaTime);
            NormalizeRotation();
        }

        void NormalizeRotation()
        {
            var normalizedEuler = transform.eulerAngles;
            normalizedEuler.z = 0f;
            transform.eulerAngles = normalizedEuler;
        }
    }
}