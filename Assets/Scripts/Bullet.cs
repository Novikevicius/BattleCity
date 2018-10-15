using System;
using UnityEngine;
using BattleCity.Miscellaneous;

namespace BattleCity
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private AnimationClip bulletExplosionClip;
        public  Sprite[]   sprites;
        private float      BasicSpeed = 2.5f;
        private Direction  direction = Direction.Up;
        public  GameObject shooter { get; set; }
        private Vector3    movementDirection;
        private bool       destroyed;
        private bool       isInitialized;
        private bool       animationStarted;
        private SpriteRenderer _renderer;
        private Animator       animator;

        void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            animator  = GetComponent<Animator>();
            PlaySound();
        }
        void Update()
        {
            if (animationStarted)
            {
                if (AnimationIsEnded("BulletExplosion"))
                {
                    DestroyBullet();
                }
                return;
            }
            InitializeDirection();
            Move();
            if (shooter == null)
                DestroyBullet();
        }
        void LateUpdate()
        {
            if(!animationStarted)
                SetSprite();
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (shooter == null || collision.gameObject == shooter)
                return;
            if (collision.name.Contains("Grass") || collision.name.Contains("Water"))
                return;
			if (collision.transform.tag == "PowerUp")
				return;
            if (collision.gameObject.GetComponent<Destroyable>() == null ||
                (shooter.transform.name.Contains("Tank") && collision.transform.name.Contains("Tank")))
            {
                StartAnimation();
                return;
            }
            var obj = collision.gameObject.GetComponent<Destroyable>();
            obj.DestroyObject(shooter);
            StartAnimation();
        }
        public void InitializeBullet(Direction _direction, GameObject _shooter, float speed)
        {
            if(isInitialized)
                throw new Exception("Bullet already initialized");
            if(_direction == Direction.None)
                throw new ArgumentNullException("_direction", "Direction cannot be none");
            if(_shooter == null)
                throw new ArgumentNullException("_shooter", "Shooter cannot be null");
            direction = _direction;
            shooter = _shooter;
            BasicSpeed *= speed;
            isInitialized = true;
        }
        private void PlaySound()
        {
            if (!shooter.name.Contains("Player"))
                return;
            if (GetComponent<AudioSource>() != null)
                GetComponent<AudioSource>().PlayDelayed(0);
        }
        private void InitializeDirection()
        {
            switch (direction)
            {
                case Direction.Up:
                    movementDirection = Vector3.up;
                    break;
                case Direction.Down:
                    movementDirection = Vector3.down;
                    break;
                case Direction.Left:
                    movementDirection = Vector3.left;
                    break;
                case Direction.Right:
                    movementDirection = Vector3.right;
                    break;
            }
        }
        private void SetSprite()
        {
            if (direction != Direction.None)
                _renderer.sprite = sprites[(int) direction - 1];
            else
               throw new ArgumentNullException("direction", "Bullet must have direction" );
        }
        private void Move()
        {
            transform.Translate(movementDirection * Time.deltaTime * BasicSpeed);
        }
        private void DestroyBullet()
        {
            Destroy(gameObject);
        }
        private void StartAnimation()
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            animator.SetBool("Collided", true);
            animationStarted = true;

            if (destroyed)
                return;
            if (shooter.transform.name.Contains("Player"))
            {
                PlayerShooting.ShootenBulletsCount--;
            }
            destroyed = true;
        }
        private bool AnimationIsEnded(string animationName)
        {
            const int animationLayer = 0;
            AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(animationLayer);
            return (state.IsName(animationName)) && 
                   (state.normalizedTime >= 1.0f);
        }


    }
}
