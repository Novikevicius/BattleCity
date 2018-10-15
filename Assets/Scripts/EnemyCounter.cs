using System.Collections.Generic;
using BattleCity.Miscellaneous;
using UnityEngine;

namespace BattleCity
{
    public class EnemyCounter : MonoBehaviour
    {
        public  static int       EnemyCount;
        public  List<GameObject> enemies;

        void Awake()
        {
            EnemyCount = 20;
            SetEnemyCountDependingOnChildCount();
        }

        public void ResetCounter()
        {
            SetEnemyCountDependingOnChildCount();
        }

        public bool SpawnEnemy()
        {
            if (EnemyCount < 1)
                return false;
            enemies.Remove(transform.GetChild(EnemyCount - 1).gameObject);
            transform.GetChild(EnemyCount - 1).gameObject.SetActive(false);
            EnemyCount--;
            return true;
        }

        private void SetEnemyCountDependingOnChildCount()
        {
            EnemyCount = transform.childCount;

            for (int i = 0; i < EnemyCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
                if (transform.GetChild(i).GetComponent<TankGroup>() != null)
                    Destroy(transform.GetChild(i).GetComponent<TankGroup>());
                enemies = new List<GameObject>();
            }
            for (int i = 0; i < EnemyCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                enemies.Add(transform.GetChild(i).gameObject);
            }

            int tankNumber = 0;
            var activeLevel = MapSpawner.GetActiveLevel();

            int maxIndex = tankNumber + activeLevel.Tank1Count;
            for (int i = tankNumber; i < maxIndex; i++)
            {
                TankGroup group = enemies[i].AddComponent<TankGroup>();
                group.Group = TankGroups.Basic;
                tankNumber++;
            }

            maxIndex += activeLevel.Tank2Count;
            for (int i = tankNumber; i < maxIndex; i++)
            {
                TankGroup group = enemies[i].AddComponent<TankGroup>();
                group.Group = TankGroups.Fast;
                tankNumber++;
            }

            maxIndex = tankNumber + activeLevel.Tank3Count;
            for (int i = tankNumber; i < maxIndex; i++)
            {
                TankGroup group = enemies[i].AddComponent<TankGroup>();
                group.Group = TankGroups.Power;
                tankNumber++;
            }

            maxIndex = tankNumber + activeLevel.Tank4Count;
            for (int i = tankNumber; i < maxIndex; i++)
            {
                TankGroup group = enemies[i].AddComponent<TankGroup>();
                group.Group = TankGroups.Armor;
                tankNumber++;
            }

            ShuffleTanks();
        }

        private void ShuffleTanks()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<TankGroup>() == null)
                    return;

                var newPos = Random.Range(0, transform.childCount);
                var temp = transform.GetChild(i).GetComponent<TankGroup>().Group;

                transform.GetChild(i).GetComponent<TankGroup>().Group      = transform.GetChild(newPos).GetComponent<TankGroup>().Group;
                transform.GetChild(newPos).GetComponent<TankGroup>().Group = temp;
                SetSpecialTanks();
            }
        }

        private void SetSpecialTanks()
        {
            transform.GetChild(16).gameObject.AddComponent<SpecialEnemy>(); // 4th tank
            transform.GetChild(10).gameObject.AddComponent<SpecialEnemy>(); // 11th tank
            transform.GetChild(2).gameObject.AddComponent<SpecialEnemy>();  // 18th tank
        }
    }
}