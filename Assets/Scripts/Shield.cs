using UnityEngine;

namespace BattleCity.Miscellaneous
{
    public class Shield : MonoBehaviour
    {
        public  bool     IsActive { get; private set; }
        private Timer    duration = new Timer();
        private Animator animator;

        private void Start()
        {
            animator = gameObject.GetComponent<Animator>();

            duration.OnTimerEnded += OnShieldEnded;
            GameObject.Find("MapSpawner").GetComponent<MapSpawner>().OnPlayerRespawn += OnPlayerRespawn;
            GameObject.Find("MapSpawner").GetComponent<MapSpawner>().OnLevelLoaded   += OnPlayerRespawn;
        }
        private void Update()
        {
            if(animator == null)
                animator = gameObject.GetComponent<Animator>();
            duration.Update();
            if (IsActive)
                PlayAnimation();
        }
        public void EnableShield(float _duration)
        {
            if (!duration.IsEnded())
            {
                duration.AddSeconds(_duration);
            }
            IsActive = true;
            duration.Start(_duration);
        }
        private void PlayAnimation()
        {
            if (animator == null)
                throw new MissingReferenceException("Shield animator compononent is null");
            animator.SetBool("IsActive", true);
        }
        private void StopAnimation()
        {
            if(animator != null)
                animator.SetBool("IsActive", false);
        }

        private void OnShieldEnded(System.Object obj, System.EventArgs args)
        {
            StopAnimation();
            IsActive = false;
        }
        private void OnPlayerRespawn(System.Object obj, System.EventArgs args)
        {
            EnableShield(5);
        }
    }
}
