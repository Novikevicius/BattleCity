using UnityEngine;
using BattleCity.Miscellaneous;

namespace BattleCity
{
    public class Movement : IMovement
    {
        private GameObject obj;
        public float Speed { get; private set; }
        public readonly float BasicSpeed = 0.75f;
        public Direction Direction { get; private set; }
        
        public Movement(GameObject obj, float speed)
        {
            this.obj = obj;
            Speed = speed * BasicSpeed;
        }
        public void MoveUp()
        {
            Vector2 newPos = new Vector2(0f, Time.deltaTime * Speed);
            Direction = Direction.Up;
            obj.transform.Translate(newPos);
        }
        
        public void MoveDown()
        {
            Vector2 newPos = new Vector2(0f, -Time.deltaTime * Speed);
            Direction = Direction.Down;
            obj.transform.Translate(newPos);
        }

        public void MoveLeft()
        {
            Vector2 newPos = new Vector2(-Time.deltaTime * Speed, 0);
            Direction = Direction.Left;
            obj.transform.Translate(newPos);
        }

        public void MoveRight()
        {
            Vector2 newPos = new Vector2(Time.deltaTime * Speed, 0);
            Direction = Direction.Right;
            obj.transform.Translate(newPos);
        }

        public void ChangeDirection(Direction dir)
        {
            this.Direction = dir;
        }

    }
}
