using UnityEngine;
using BattleCity.Miscellaneous;
using UnityEngine.SceneManagement;

namespace BattleCity
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private AudioClip movementSound;
        [SerializeField] private AudioClip defaultMovementSound;
        [SerializeField] private AudioClip explosionSound;
        [SerializeField] private Sprite defaultSprite;
        public  Movement        movement { get; private set; }
        private Animator        animator;
        private float           Speed = 2f;
        private AudioSource     audioSource;

        private void Start()
        {
            movement = new Movement(gameObject, Speed );
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = defaultMovementSound;
            audioSource.PlayDelayed(1);
            GameObject.Find("MapSpawner").GetComponent<MapSpawner>().OnLevelLoadingStart += OnLevelLoadingStart;
        }
        private void Update()
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerExplosion"))
                return;
            CheckInput();
        }
        private void LateUpdate()
        {

            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) ||
                Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                animator.SetInteger("State", (int)Direction.None);
            }
        }
        private void OnLevelLoadingStart(System.Object obj, System.EventArgs args)
        {
            if (audioSource == null)
                return;
            audioSource.enabled = false;
        }
        private void CheckInput()
        {
            int animatorState = animator.GetInteger("State");
            
            if      (Input.GetKey(KeyCode.UpArrow)    && (animatorState == (int)Direction.None || movement.Direction == Direction.Up))
                MoveUp();
            else if (Input.GetKey(KeyCode.DownArrow)  && (animatorState == (int)Direction.None || movement.Direction == Direction.Down))
                MoveDown();
            else if (Input.GetKey(KeyCode.LeftArrow)  && (animatorState == (int)Direction.None || movement.Direction == Direction.Left))
                MoveLeft();
            else if (Input.GetKey(KeyCode.RightArrow) && (animatorState == (int)Direction.None || movement.Direction == Direction.Right))
                MoveRight();

            if (audioSource.enabled)
            {
                if (IsMovementKeyPressed())
                    audioSource.clip = movementSound;
                else
                    audioSource.clip = defaultMovementSound;
                if (!audioSource.isPlaying)
                    audioSource.PlayDelayed(0);
            }

            if(Input.GetKeyDown(KeyCode.Escape))
                SceneManager.LoadSceneAsync("MainMenu");
        }
        private bool IsMovementKeyPressed()
        {
            return Input.GetKey(KeyCode.UpArrow)   || Input.GetKey(KeyCode.DownArrow) ||
                   Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);
        }
        private void MoveUp()
        {
            animator.SetInteger("State", (int)movement.Direction);
            movement.MoveUp();
        }
        private void MoveDown()
        {
            animator.SetInteger("State", (int)movement.Direction);
            movement.MoveDown();
        }
        private void MoveLeft()
        {
            animator.SetInteger("State", (int)movement.Direction);
            movement.MoveLeft();
        }
        private void MoveRight()
        {
            animator.SetInteger("State", (int)movement.Direction);
            movement.MoveRight();
        }
    }
}

