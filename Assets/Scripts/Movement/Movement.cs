namespace Movement
{
    public interface Movement
    {
        void MoveForward();
        void MoveBackwards();
        void TurnRight();
        void TurnLeft();
        void Turn(float axis);
    }
}