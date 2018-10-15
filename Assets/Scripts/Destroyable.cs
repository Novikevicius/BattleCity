using System;
using UnityEngine;
using BattleCity.Miscellaneous;

namespace BattleCity
{
    public class Destroyable : MonoBehaviour
    {
        private bool player1Destroyed;
        private Animator animator;

        private void Start()
        {
            if (!name.Contains("Player"))
                return;
            animator = GetComponent<Animator>();
        }
        private void Update()
        {
            DestroyIfOutOfBorders();
            if (!name.Contains("Player"))
                return;
            if (player1Destroyed)
            {
                if (AnimationIsEnded("PlayerExplosion"))
                {
                    animator.SetBool("PlayerDestroyed", false);
                    player1Destroyed = false;

                    HitPoints hp = GetComponent<HitPoints>();
                    if (hp.GetHealth() < 0)
                    {
                        GameOver();
                        return;
                    }
                    var mapSpawner = GameObject.Find("MapSpawner").GetComponent<MapSpawner>();
                    mapSpawner.RespawnPlayer1();
                }
            }
        }
        public  void DestroyObject(GameObject shooter)
        {
            if (IsShieldActive())
                return;
            if (HasHitpointsLeft())
            {
                RemoveHP();
                return;
            }
            if (shooter.transform.name.Contains("Player"))
            {
                GiveScore(shooter);
                GetComponent<BoxCollider2D>().enabled = false;
            }
            if (transform.name.Contains("Tank"))
            {
                DestroyEnemy(shooter);
                return;
            }
            if (transform.name.Contains("Player"))
                GameOver();
            else if (transform.name.Contains("Eagle"))
            {
                GetComponent<SpriteRenderer>().sprite = transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                GameOver();
                return;
            }
            Destroy(gameObject);
        }
        public void DestroyEnemy(GameObject shooter)
        {
            if(EnemySpawner.ActiveEnemiesCount > 0)
                EnemySpawner.ActiveEnemiesCount--;
            else
                Debug.LogWarning(EnemySpawner.ActiveEnemiesCount + " is less than 0");
            if (GetComponent<SpecialEnemy>() != null)
            {
                SpawnBonus();
                GiveScore(shooter);
            }
            if (gameObject.GetComponent<EnemyMovement>() != null)
                gameObject.GetComponent<EnemyMovement>().ShouldDestroyObject = true;
        }
        private void SpawnBonus()
        {
            GameObject bonus = Resources.Load("Prefabs/Bonus") as GameObject;
            if(bonus == null)
                throw new ArgumentNullException("bonus", "Bonus prefab not found");
            var spawner = GameObject.Find("MapSpawner").transform;
            float xPos =  UnityEngine.Random.Range(1, Levels.Width - 1);
            float yPos = -UnityEngine.Random.Range(1, Levels.Hight - 1);
            bonus.transform.position = new Vector3(xPos, yPos, 0);
            Instantiate(bonus, spawner);
        }
        private bool IsShieldActive()
        {
            if (transform.childCount < 1)
                return false;
            for (int i = 0; i < transform.childCount; i++)
                if (transform.GetChild(i).GetComponent<Shield>() != null)
                    if (transform.GetChild(i).GetComponent<Shield>().IsActive)
                        return true;
            return false;
        }
        private bool HasHitpointsLeft()
        {
            if (GetComponent<HitPoints>() == null)
                return false;
            HitPoints hp = GetComponent<HitPoints>();
            return hp.GetHealth() > 0;
        }
        private void RemoveHP()
        {
            HitPoints hp = GetComponent<HitPoints>();
            hp.RemovePoint();
            if (name.Contains("Player"))
                StartAnimationAndAudio();
        }
        private void GameOver()
        {
            GameObject gameOverObj = GameObject.Find("GameOverController");
            if (gameOverObj == null)
                throw new ArgumentNullException("GameOverController", "Controller not found");
            if (gameOverObj.GetComponent<GameOverController>() == null)
                throw new ArgumentNullException("GameOverControllerScript", "Controller script not found");
            var gameOverScript = gameOverObj.GetComponent<GameOverController>();
            gameOverScript.isGameOver = true;
            if(name.Contains("Player"))
                Destroy(gameObject);
        }
        private void GiveScore(GameObject player)
        {
            var counter = GameObject.Find("ScoreCounter");
            if(counter == null)
                throw new ArgumentNullException("counter", "ScoreCounter not found");
            if (counter.GetComponent<PlayerScore>() == null)
                return;
            var scoreScript = counter.GetComponent<PlayerScore>();
            scoreScript.AddScore(gameObject, transform.position, player);
        }
        private void StartAnimationAndAudio()
        {
            if (!player1Destroyed)
            {
                player1Destroyed = true;
                animator.SetBool("PlayerDestroyed", true);
                GetComponent<AudioSource>().PlayDelayed(0);
            }
        }
        private bool AnimationIsEnded(string animationName)
        {
            const int animationLayer = 0;
            AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(animationLayer);
            return state.IsName(animationName) && state.normalizedTime >= 1.0f;
        }
        private void DestroyIfOutOfBorders()
        {
            if( !(name.Contains("Tank") || name.Contains("Bullet")) )
                return;

            Vector2 mapSpawnerPos = GameObject.Find("MapSpawner").transform.position;

            Vector2 pos = transform.position;
            float maxX = Levels.Columns * Levels.tileSize + mapSpawnerPos.x;
            float minX = 0f + mapSpawnerPos.x;
            float maxY = 0f + mapSpawnerPos.y;
            float minY = -Levels.Rows * Levels.tileSize + mapSpawnerPos.y;
            
            if (pos.x < minX  || pos.x > maxX ||
                pos.y < minY || pos.y > maxY)
            {
                if (name.Contains("Bullet"))
                {
                    try
                    {
                        gameObject.GetComponent<Bullet>().shooter.GetComponent<PlayerShooting>().RemoveBullet();
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine("You may left bullet prefab on the scene\n"+ e.StackTrace);
                    }
                }
                Destroy(gameObject);
            }
        }
    }
}

