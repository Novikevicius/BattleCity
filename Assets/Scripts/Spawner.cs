using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity.Miscellaneous
{
    public class Spawner
    {
        public  Vector3  spawnPosition { get; }
        private Animator animator;
        private const    float  animationLenght      = 4.0f;
        private readonly string AnimationName        = "SpawnEnemyAnim";
        private readonly string IdleAnimationName    = "Idle";
        private readonly string AnimationTriggerName = "SpawnEnemy";

        public Spawner(Animator animator, Vector3 spawnPosition)
        {
            this.animator = animator;
            this.spawnPosition = spawnPosition;
            animator.SetBool(AnimationTriggerName, true);
        }

        public bool IsIdle()
        {
            AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
            return state.IsName(IdleAnimationName);
        }
        public bool IsAnimationEnded()
        {
            AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
            if ((state.IsName(AnimationName)) &&
                (state.normalizedTime >= animationLenght))
            {
                animator.SetBool(AnimationTriggerName, false);
                return true;
            }
            return false;
        }
    }
}