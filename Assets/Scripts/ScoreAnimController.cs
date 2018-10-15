using UnityEngine;
using BattleCity.Miscellaneous;

namespace BattleCity
{
    public class ScoreAnimController : MonoBehaviour
    {
        private const float animTime = 1.5f;
        private Timer timer = new Timer();

        void Start()
        {
            timer.Start(animTime);
        }

        void Update()
        {
            timer.Update();
            if (timer.IsEnded())
            {
                Destroy(gameObject);
            }
            transform.Translate(Vector3.up * Time.deltaTime * 0.5f);
        }
    }
}
