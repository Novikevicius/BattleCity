using System;
using System.Collections.Generic;
using BattleCity.Miscellaneous;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BattleCity
{

    public class EnemySpawner : MonoBehaviour
    {
        public  List<GameObject> spawners;
        public  GameObject       Tank1;
        public  GameObject       FastTankPrefab;
        public  GameObject       PowerTankPrefab;
        public  GameObject       ArmorTankPrefab;
        public  static int       ActiveEnemiesCount;
        public  static bool      ShouldSpawnEnemies;

        private int              lastIndex;
        private bool             GameWon;
        private Timer            gameWonDelayTimer = new Timer();
        private Timer            spawnDelay        = new Timer();
        private List<Spawner>    toSpawn           = new List<Spawner>();
        private const float      SpawnDelayLength  = 2f; // How max often enemies will spawn
        private MapSpawner       mapSpawner;

        private void Awake()
        {
            mapSpawner = GameObject.Find("MapSpawner").GetComponent<MapSpawner>();
            ActiveEnemiesCount = 0;
            spawnDelay.Start(0.1f);
        }
        private void Update()
        {
            if (GameWon)
            {
                gameWonDelayTimer.Update();
                if (gameWonDelayTimer.IsEnded())
                {
                    CountScore();
                    LoadNextLevel();
                }
                return;
            }
            if (!ShouldSpawnEnemies)
                return;

            spawnDelay.Update();
            if(!(spawnDelay.IsEnded()))
                return;
            if (toSpawn.Count > 0)
            {
                if ((toSpawn[0].IsAnimationEnded() || toSpawn[0].IsIdle()))
                {
                    var spawnedTank      = SpawnTank().transform;
                    spawnedTank.position = toSpawn[0].spawnPosition;
                    spawnedTank.parent   = transform;
                    if(spawnedTank.GetComponent<SpecialEnemy>() != null)
                        foreach (var powerUp in GameObject.FindGameObjectsWithTag("PowerUp"))
                            Destroy(powerUp);
                    toSpawn.Remove(toSpawn[0]);
                    spawnDelay.Start( Random.Range(0.0f, SpawnDelayLength) );
                }
                return;
            }
            if (ActiveEnemiesCount < 0)
                ActiveEnemiesCount = 0;
            if (ActiveEnemiesCount > 3)
            {
                ActiveEnemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
                return;
            }
            SpawnEnemy();
        }
        private void SpawnEnemy()
        {
            if (spawners.Count < 1)
                return;
            if ( !GameObject.Find("EnemyCounter").GetComponent<EnemyCounter>().SpawnEnemy())
            {
                if (ActiveEnemiesCount < 1)
                {
                    GameWon = true;
                    gameWonDelayTimer.Start(2);
                    ShouldSpawnEnemies = false;
                }
                return;
            }
            ActiveEnemiesCount++;
            int spawnerIndex  = GetIndex();
            var spawner       = spawners[spawnerIndex];
            var animator      = spawner.GetComponent<Animator>();
            var spawnEnemyPos = spawners[spawnerIndex].transform.position;
            toSpawn.Add(new Spawner(animator, spawnEnemyPos));
        }
        private int GetIndex()
        {
            int index = lastIndex + 1;
            if (index >= spawners.Count)
            {
                lastIndex = 0;
                return lastIndex;
            }
            lastIndex++;
            return index;
        }
        private GameObject SpawnTank()
        {
            var enemyCounter = GameObject.Find("EnemyCounter").transform;
            if(EnemyCounter.EnemyCount > enemyCounter.childCount)
            {
                Debug.LogError(EnemyCounter.EnemyCount + " > " + enemyCounter.childCount);
                throw new ArgumentOutOfRangeException("EnemyCounter.EnemyCount");
            }
            try
            {
                if (enemyCounter.GetChild(EnemyCounter.EnemyCount).GetComponent<TankGroup>() ==
                    null)
                    return Tank1;
                var groupComponent = enemyCounter.GetChild(EnemyCounter.EnemyCount).GetComponent<TankGroup>();
                GameObject tank;
                
                switch (groupComponent.Group)
                {
                    case TankGroups.Basic:
                        tank = Tank1;
                        break;
                    case TankGroups.Fast:
                        tank = FastTankPrefab;
                        break;
                    case TankGroups.Power:
                        tank = PowerTankPrefab;
                        break;
                    case TankGroups.Armor:
                        tank = ArmorTankPrefab;
                        break;
                    default:
                        tank = Tank1;
                        break;
                }
                tank = Instantiate(tank);
                if (enemyCounter.GetChild(EnemyCounter.EnemyCount).GetComponent<SpecialEnemy>() != null)
                    tank.AddComponent<SpecialEnemy>().EnableBlinking();
                return tank;
            }
            catch (UnityException e)
            {
                Console.WriteLine("EnemyCount " + EnemyCounter.EnemyCount + " " + e);
                throw;
            }
        }
        private void CountScore()
        {
            //TODO: implement score counting
        }
        private void LoadNextLevel()
        {
            GameWon = false;
            mapSpawner.UnLoadlevel();
            int nextLevel = MapSpawner.GetActiveLevel().Lv;
            if (nextLevel >= Levels.GetLevelsCount() || nextLevel < 1)
                nextLevel = 1;
            mapSpawner.LoadLevel(Levels.GetLevel(nextLevel));
        }
    }
}
