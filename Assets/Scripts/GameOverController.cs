using System;
using BattleCity.Miscellaneous;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BattleCity
{
    public class GameOverController : MonoBehaviour
    {
        public  GameObject gameOverTextObj;
        public  bool       isGameOver;
        private Animator   gameOverTextAnim;
        private bool       animationEnded;
		
        private void Start()
        {
            if (gameOverTextObj == null)
                throw new ArgumentNullException("gameOverTextObj");
            gameOverTextAnim = gameOverTextObj.GetComponent<Animator>();
        }
        private void Update()
        {
            if(!isGameOver)
                return;
            GameObject.Find("MapSpawner").GetComponent<MapSpawner>().ResetLevelToDefault();
            animationEnded = IsAnimationEnded();
            if (!animationEnded)
            {
                PlayAnimation();
                return;
            }
            //TODO: after animation completed count players scores
            SceneManager.LoadScene("MainMenu");
        }

        private void PlayAnimation()
        {
            gameOverTextAnim.SetBool("GameOver", true);
        }

        private bool IsAnimationEnded()
        {
            var state = gameOverTextAnim.GetCurrentAnimatorStateInfo(0);
            return (state.IsName("GameOver") &&
                    state.normalizedTime >= 1.5f);
        }
    }

}