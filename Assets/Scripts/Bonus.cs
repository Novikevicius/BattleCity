using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BattleCity.Miscellaneous
{
    public class Bonus : MonoBehaviour
    {
        [SerializeField] private Sprite[] bonusesSprites;
        private Bonuses bonusType;
        private Timer blinkingTimer = new Timer();
        private const float blinkingSpeed = 0.5f;
        private AudioSource _audio;

        private void Start()
        {
            _audio = gameObject.GetComponent<AudioSource>();
            //TODO: Implement all bonuses
             do
             {
                 bonusType = (Bonuses) Random.Range(0, 6);
             }
             while ((bonusType == Bonuses.Shovel || bonusType == Bonuses.Star || bonusType == Bonuses.Timer));
             if (bonusesSprites.Length <= (int)bonusType)
                 throw new ArgumentOutOfRangeException("bonusType", "Sprite is not set for + " + bonusType);
            GetComponent<SpriteRenderer>().sprite = bonusesSprites[(int)bonusType];

            blinkingTimer.Start(blinkingSpeed);
            blinkingTimer.OnTimerEnded += OnTimerEnd;
        }
        private void Update()
        {
            blinkingTimer.Update();
            if(!_audio.isPlaying)
                return;
            if (_audio.time + 0.01f >= _audio.clip.length)
                DestroyBonus();
        }
        private void OnTriggerEnter2D(Collider2D obj)
        {
            if( !obj.transform.name.Contains("Player"))
                return;
            UseBonus(obj.gameObject);
            PlaySound();
        }
        private void UseBonus(GameObject player)
        {
            var counter = GameObject.Find("ScoreCounter");
            var scoreScript = counter.GetComponent<PlayerScore>();
            scoreScript.AddScore(gameObject, transform.position, player);

            switch (bonusType)
            {
                case Bonuses.Grenade:
                {
                    var enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    foreach (var enemy in enemies)
                    {
                       if( enemy.GetComponent<Destroyable>() == null)
                           return;
                       enemy.GetComponent<Destroyable>().DestroyEnemy(player);
                    }
                    return;
                }
                case Bonuses.Shovel:
                {
                    Debug.LogWarning("Not implemented");
                    return;
                }
                case Bonuses.Star:
                {
                    Debug.LogWarning("Not implemented");
                    return;
                }
                case Bonuses.Helmet:
                {
                    if(player.transform.GetComponentInChildren<Shield>() == null)
                        throw new NullReferenceException("Shield component not found");
                    player.transform.GetComponentInChildren<Shield>().EnableShield(10);
                    break;
                }
                case Bonuses.Tank:
                {
                    if(player.GetComponent<HitPoints>() == null)
                        throw new NullReferenceException("Player don't have HitPoint component");
                    player.GetComponent<HitPoints>().AddPoint();
                    return;
                }
                case Bonuses.Timer:
                {
                    Debug.LogWarning("Not implemented");
                    return;
                }
            }
        }
        private void DestroyBonus()
        {
            Destroy(gameObject);
        }
        private void OnTimerEnd(System.Object obj, System.EventArgs args)
        {
            Blink();
        }
        private void Blink()
        {
            if (GetComponent<SpriteRenderer>().color == new Color(1, 1, 1, 1))
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            else
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            blinkingTimer.Start(blinkingSpeed);
        }
        private void PlaySound()
        {
            _audio.PlayDelayed(0);
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
