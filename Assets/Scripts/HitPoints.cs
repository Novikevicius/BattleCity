using System;
using UnityEngine;

namespace BattleCity.Miscellaneous
{
    public class HitPoints : MonoBehaviour
    {
        public const int MaxHealth = 9;
        [SerializeField] private int hitPoints;

        private void Start()
        {
            if (name.Contains("Player1") && Buffs.Player1Health >= 0)
            {
                hitPoints = Buffs.Player1Health;
            }
            DisplayHealth();
        }
        private void OnDestroy()
        {
            if (name.Contains("Player1"))
            {
                Buffs.Player1Health = hitPoints;
            }
        }
        public int GetHealth()
        {
            return hitPoints;
        }
        public void AddPoint()
        {
            if(hitPoints >= MaxHealth)
                Debug.Log(gameObject.name + "Cannot have more than " + MaxHealth + " hp");
            hitPoints++;
            DisplayHealth();
        }
        public void RemovePoint()
        {
            hitPoints--;
            if(hitPoints >= 0)
                DisplayHealth();
        }
        private void DisplayHealth()
        {
            if( !(transform.name.Contains("Player1")) && !(transform.name.Contains("Player2")))
                return;

            var rightMenu = GameObject.Find("RightMenu").GetComponent<RightMenuController>();

            if (transform.name.Contains("Player1"))
                rightMenu.DisplayPlayer1Health(hitPoints);
            else if (transform.name.Contains("Player2"))
                rightMenu.DisplayPlayer2Health(hitPoints);
        }

    }
}

