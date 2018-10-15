using UnityEngine;
using BattleCity.Miscellaneous;

namespace BattleCity
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField]private float Speed = 1.0f;

        private const float minDelay = 0.5f;
        private const float maxDelay = 1.5f;
        public  Movement    movement { get; private set; }
        private Animator    animator;
        private float       delay = 1f;
        private Timer       timer = new Timer();
        private AudioSource _audio;
        private bool        audioPlayed;
        public  bool        ShouldDestroyObject { get; set; }


        private void Start()
        {
            animator = GetComponent<Animator>();
            movement = new Movement(gameObject, Speed);
            _audio = GetComponent<AudioSource>();
			Cursor.visible = false;
        }
        private void Update()
        {
            if (ShouldDestroyObject)
            {
                if (!audioPlayed)
                {
                    _audio.PlayDelayed(0);
                    audioPlayed = true;
                    animator.SetBool("Destroyed", true);
                }
                if (_audio.time + 0.01f >= _audio.clip.length)
                {
                    Destroy(gameObject);
                }
                return;
            }

            if (!(timer.IsEnded()))
                timer.Update();
            else
            {
                timer.Start(delay);
                movement.ChangeDirection(ChooseDirection());
                delay = Random.Range(minDelay, maxDelay);
            }
            Move(movement.Direction);
            UpdateAnimation();
        }

        private void Move(Direction dir)
        {
            int animatorState = animator.GetInteger("State");

            if      (dir == Direction.Up    && (animatorState == (int)Direction.None || movement.Direction == Direction.Up))
                MoveUp();
            else if (dir == Direction.Down  && (animatorState == (int)Direction.None || movement.Direction == Direction.Down))
                MoveDown();
            else if (dir == Direction.Left  && (animatorState == (int)Direction.None || movement.Direction == Direction.Left))
                MoveLeft();
            else if (dir == Direction.Right && (animatorState == (int)Direction.None || movement.Direction == Direction.Right))
                MoveRight();
        }

        private void UpdateAnimation()
        {
            animator.SetInteger("State", (int)movement.Direction);
            if (GetComponent<HitPoints>() != null)
                animator.SetInteger("Hp", GetComponent<HitPoints>().GetHealth() + 1);
        }
        private Direction ChooseDirection()
        {
            return (Direction)Random.Range(1, 5);
        }
        private void MoveUp()
        {
            movement.MoveUp();
        }
        private void MoveDown()
        {
            movement.MoveDown();
        }
        private void MoveLeft()
        {
            movement.MoveLeft();
        }
        private void MoveRight()
        {
            movement.MoveRight();
        }
    }
}
