using BattleCity.Miscellaneous;
using UnityEngine;

namespace BattleCity
{
    public class SpecialEnemy : MonoBehaviour
    {
        private Timer blinkTimer = new Timer();
        private float blinkSpeed = 0.5f;
        
        private void Update()
        {
            if(!name.Contains("Tank"))
                return;
            blinkTimer.Update();
            if (blinkTimer.IsEnded())
            {
                Blink();
                blinkTimer.Start(blinkSpeed);
            }
        }
        public void EnableBlinking()
        {
            blinkTimer.Start(blinkSpeed);
        }
        private void Blink()
        {
            if (gameObject.GetComponent<SpriteRenderer>().color == new Color(1, 1, 1))
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255/255, 51/255, 51/255);
            }
            else
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        }
    }
}
