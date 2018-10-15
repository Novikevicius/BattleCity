using System;
using BattleCity.Miscellaneous;
using UnityEngine;

namespace BattleCity
{
    public class Shooting
    {
        public const float halfTankSize = 0.2f;
        private Direction  bulletDirection;
        private GameObject bulletSpawn;
        private GameObject bulletPrefab;

        public  Shooting   (GameObject _bulletSpawn, GameObject _bulletPrefab)
        {
            bulletSpawn = _bulletSpawn;
            bulletPrefab = _bulletPrefab;
            bulletDirection = Direction.Up;;
        }
        public  void Shoot (GameObject shooter, Movement movement, float speed)
        {
            if (bulletPrefab == null)
                throw new ArgumentNullException("BulletPrefab", "Bullet prefab is not set");
            SetDirection(movement);
            SetBulletSpawnPosition(shooter.transform);
            SpawnBullet(shooter, speed);
        }
        private void SetBulletSpawnPosition (Transform transform)
        {
            Vector3 tankPosition = transform.position;
            switch (bulletDirection)
            {
                case Direction.Up:
                {
                    bulletSpawn.transform.position = new Vector3(0f, halfTankSize, 0f) + tankPosition;
                    break;
                }
                case Direction.Down:
                {
                    bulletSpawn.transform.position = new Vector3(0f, -halfTankSize, 0f) + tankPosition;
                    break;
                }
                case Direction.Left:
                {
                    bulletSpawn.transform.position = new Vector3(-halfTankSize, 0f, 0f) + tankPosition;
                    break;
                }
                case Direction.Right:
                {
                    bulletSpawn.transform.position = new Vector3(halfTankSize, 0f, 0f) + tankPosition;
                    break;
                }
            }
        }
        private void SetDirection (Movement movement)
        {
            bulletDirection = movement.Direction;
        }
        private void SpawnBullet (GameObject shooter, float speed)
        {
            if (bulletDirection == Direction.None) bulletDirection = Direction.Up;
            GameObject.Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity).GetComponent<Bullet>().InitializeBullet(bulletDirection, shooter, speed);
        }
    }
}
