using UnityEngine;

namespace Movement
{
    public class Input : MonoBehaviour
    {
        Movement movement;
        public CameraLook cameraLook;
        private Vector3 previousMousePos;
        
        void Start()
        {
            movement = GetComponent<Movement>();
            Cursor.lockState = CursorLockMode.Confined;
        }
        
        void Update()
        {
            if (UnityEngine.Input.GetKey(KeyCode.W))
            {
                movement.MoveForward();
            }
            else if (UnityEngine.Input.GetKey(KeyCode.S))
            {
                movement.MoveBackwards();
            }

            ReadMouseMovement();
            previousMousePos = UnityEngine.Input.mousePosition;
        }

        private void ReadMouseMovement()
        {
            var mouseDelta = UnityEngine.Input.mousePosition - previousMousePos;
            movement.Turn(mouseDelta.x);
            cameraLook.Pitch(mouseDelta.y);
        }
    }
}