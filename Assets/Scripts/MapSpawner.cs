using System;
using UnityEngine;
using BattleCity.Miscellaneous;

namespace BattleCity
{
    public class MapSpawner : MonoBehaviour
    {
        public event EventHandler OnLevelLoaded;
        public event EventHandler OnLevelLoadingStart;
        public event EventHandler OnPlayerRespawn;

        [SerializeField] private GameObject Empty;
        [SerializeField] private GameObject Border;
        [SerializeField] private GameObject Brick;
        [SerializeField] private GameObject Iron;
        [SerializeField] private GameObject Grass;
        [SerializeField] private GameObject Water;
        [SerializeField] private GameObject Eeagle;
        [SerializeField] private GameObject Player1Prefab;
        [SerializeField] private GameObject SpawnPrefab;

        private EnemySpawner spawner;
        private Vector3      player1SpawnPos;
        private static Level activeLevel;
        private bool         unLoadLevel;
        public  bool         levelUnLoaded { get; private set; }
        public  Vector2      tilePos;

        private void Start()
        {
            activeLevel = Levels.defaultLevel;
            if (OnLevelLoadingStart != null) OnLevelLoadingStart(this, null);
            levelUnLoaded = true;
            spawner = GetComponent<EnemySpawner>();
        }
        private void FixedUpdate()
        {
            DestroyLevel();
            if (levelUnLoaded)
            {
                SpawnLevel(5);
            }
        }

        public  void LoadLevel(Level lvl)
        {
            activeLevel = lvl;
        }
        public  void ResetLevelToDefault()
        {
            activeLevel = Levels.defaultLevel;
        }
        public  void UnLoadlevel()
        {
            unLoadLevel = true;
            if (OnLevelLoadingStart != null) OnLevelLoadingStart(this, null);
            tilePos = new Vector2();
        }
        public  void RespawnPlayer1()
        {
            var player1 = GameObject.FindWithTag("Player1");
            player1.transform.position = player1SpawnPos;
            player1.GetComponent<BoxCollider2D>().enabled = true;
            if (OnPlayerRespawn != null) OnPlayerRespawn(this, null);
        }
        public  static Level GetActiveLevel()
        {
            return activeLevel;
        }
        private void SpawnLevel(int speed)
        {
            if (tilePos.y == Levels.Rows - 1 && tilePos.x == Levels.Columns - 1)
            {
                EnemySpawner.ActiveEnemiesCount = 0;
                EnemyCounter.EnemyCount = 20;
                levelUnLoaded = false;
                EnemySpawner.ShouldSpawnEnemies = true;
                if (OnLevelLoaded != null) OnLevelLoaded(this, null);
                GameObject.Find("EnemyCounter").GetComponent<EnemyCounter>().ResetCounter();
                return;
            }
            if (tilePos.y < Levels.Rows)
            {
                CheckX();
                if (tilePos.x == Levels.Columns - 1)
                {
                    tilePos.x = 0;
                    tilePos.y++;
                    return;
                }
                tilePos.x++;
                if (speed > 0) SpawnLevel(speed - 1);
                return;
            }
            if (tilePos.y == Levels.Rows - 1)
            {
                tilePos.y = 0;
            }
        }
        private void CheckX()
        {
            if (tilePos.x < Levels.Columns)
            {
                Vector3 tilePosition = new Vector3(tilePos.x * Levels.tileSize, -tilePos.y * Levels.tileSize) +
                                       transform.position;
                int index = Levels.Columns * (int)tilePos.y + (int)tilePos.x;
                char c = activeLevel.level[index];
                SpawnTile(c, tilePosition);

            }
        }
        private void SpawnTile(char tileCode, Vector3 position)
        {
            GameObject tile = null;
            switch (tileCode)
            {
                case '|':
                {
                    tile = Border;
                    break;
                }
                case 'B':
                {
                    tile = Brick;
                    break;
                }
                case 'I':
                {
                    tile = Iron;
                    break;
                }
                case 'G':
                {
                    tile = Grass;
                    break;
                }
                case 'W':
                {
                    tile = Water;
                    break;
                }
                case 'E':
                {
                    tile = Eeagle;
                    break;
                }
                case 'S':
                {
                    tile = SpawnPrefab;
                    break;
                }
                case '1':
                {
                    tile = Player1Prefab;
                    SetPlayer1Position(tile, position);
                    break;
                }
                case '2':
                {
                    //TODO: change player2 position and spawn empty tile
                    break;
                }
            }
            if (tile != Border)
                Instantiate(Empty, position, Quaternion.identity, transform);
            if (tile != null)
            {
                if (tile == Eeagle)
                {
                    position += new Vector3(Levels.tileSize / 2, Levels.tileSize / 2);
                }
                else if (tile == SpawnPrefab)
                {
                    position -= new Vector3(Levels.tileSize / 2, Levels.tileSize / 2);
                    GameObject obj = Instantiate(tile, position, Quaternion.identity, transform);
                    spawner.spawners.Add(obj);
                    return;
                }
                else if (tile == Player1Prefab)
                {
                    Instantiate(tile, position, Quaternion.identity, transform);
                    return;
                }
                Instantiate(tile, position, Quaternion.identity, transform);
            }
        }
        private void SetPlayer1Position(GameObject player1, Vector3 position)
        {
            position += new Vector3(Levels.tileSize / 2, Levels.tileSize / 2);
            player1.transform.position = position;
            player1SpawnPos = position;
        }
        private void DestroyLevel()
        {
            if(!unLoadLevel)
                return;
            if (transform.childCount < 1)
            {
                unLoadLevel = false;
                levelUnLoaded = true;
                return;
            }
            if (transform.childCount > 6)
            {
                Destroy(transform.GetChild(6).gameObject);
            }
            if (transform.childCount > 5)
            {
                Destroy(transform.GetChild(5).gameObject);
            }
            if (transform.childCount > 4)
            {
                Destroy(transform.GetChild(4).gameObject);
            }
            if (transform.childCount > 3)
            {
                Destroy(transform.GetChild(3).gameObject);
            }
            if (transform.childCount > 2)
            {
                Destroy(transform.GetChild(2).gameObject);
            }
            if (transform.childCount > 1)
            {
                Destroy(transform.GetChild(1).gameObject);
            }
            Destroy(transform.GetChild(0).gameObject);
            if (spawner.spawners.Count > 0)
                spawner.spawners.Remove(spawner.spawners[0]);
        }
    }
}
