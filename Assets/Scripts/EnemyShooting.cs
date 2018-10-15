using System;
using UnityEngine;
using BattleCity.Miscellaneous;
using Random = UnityEngine.Random;

namespace BattleCity
{
    public class EnemyShooting : MonoBehaviour
    {
        [SerializeField]private float maxCoolDown = 1.5f;
        [SerializeField]private float minCoolDown = 0.5f;
        [SerializeField]private float BulletSpeed = 1.0f;

        public  GameObject    bulletPrefab;
        public  GameObject    bulletSpawn;
        private EnemyMovement enemyMovement;
        private Shooting      shooting;
        private Sprite[]      bulletSprites;
        private Timer         coolDown = new Timer();

        void Start()
        {
            shooting = new Shooting(bulletSpawn, bulletPrefab);
            enemyMovement = GetComponent<EnemyMovement>();
            ResetCooldown();

            if (maxCoolDown < 0)
                throw new ArgumentOutOfRangeException("maxCoolDown", "maxCoolDown cannot be negative");
            if (minCoolDown < 0)
                throw new ArgumentOutOfRangeException("minCoolDown", "minCoolDown cannot be negative");
        }
        void Update()
        {
            if (enemyMovement.ShouldDestroyObject)
                return;
            if (!IsTankShooting())
                return;
            shooting.Shoot(gameObject, enemyMovement.movement, BulletSpeed);
        }
        private bool IsTankShooting()
        {
            if (!(coolDown.IsEnded()))
            {
                coolDown.Update();
                return false;
            }
            ResetCooldown();
            return true;
        }
        private void ResetCooldown()
        {
            coolDown.Start(Random.Range(minCoolDown, maxCoolDown));
        }
    }
}
