using UnityEngine;

namespace Movement
{
    public class KinematicMovement : MonoBehaviour, Movement
    {
        public float MoveSpeed;
        public float TurnSpeed;
        public float FallSpeed;
        public float CharacterSize;
        public float CharacterHeight;
        public LayerMask ColliderMask;

        private bool CanMoveForward => !Physics.Raycast(transform.position + Vector3.up * 0.2f, transform.forward,
            CharacterSize, ColliderMask);
        private bool CanMoveBackwards => !Physics.Raycast(transform.position + Vector3.up * 0.2f, -transform.forward,
            CharacterSize, ColliderMask);
        private bool FloorIsAvailable => Physics.Raycast(transform.position, -transform.up, CharacterHeight, ColliderMask);

        private Vector3 FloorSpot
        {
            get
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, -transform.up, out hit, CharacterHeight, ColliderMask))
                {
                    return hit.point;
                }

                return Vector3.zero;
            }
        }

        void Update()
        {
            if (FloorIsAvailable)
                StandOnFloor();
            else
                Fall();
        }

        public void MoveForward()
        {
            if(CanMoveForward)
                transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }

        public void MoveBackwards()
        {
            if(CanMoveBackwards)
                transform.Translate(-Vector3.forward * MoveSpeed * Time.deltaTime);
        }

        public void TurnRight()
        {
            Turn(1f);
        }
        
        public void TurnLeft()
        {
            Turn(-1f);
        }

        void Fall()
        {
            transform.Translate(-Vector3.up * FallSpeed * Time.deltaTime);
        }

        void StandOnFloor()
        {
            transform.position = FloorSpot + new Vector3(0f, CharacterHeight - 0.01f, 0f);
        }
        
        public void Turn(float axis)
        {
            transform.Rotate(Vector3.up * TurnSpeed * axis);
        }
    }
}