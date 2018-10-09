using UnityEngine;

namespace Movement
{
    public class PhysicsMovement : MonoBehaviour, Movement
    {
        public float MoveSpeed;
        public float TurnSpeed;
        
        private Rigidbody body;

        void Start()
        {
            body = GetComponent<Rigidbody>();
        }
        
        public void MoveForward()
        {
             body.AddForce(transform.forward * MoveSpeed * Time.deltaTime);
        }

        public void MoveBackwards()
        {
            body.AddForce(-transform.forward * MoveSpeed * Time.deltaTime);
        }

        public void TurnRight()
        {
            body.AddTorque(Vector3.up * TurnSpeed * Time.deltaTime);
        }

        public void TurnLeft()
        {
            body.AddTorque(Vector3.up * -TurnSpeed * Time.deltaTime);
        }

        public void Turn(float axis)
        {
            
        }
    }
}