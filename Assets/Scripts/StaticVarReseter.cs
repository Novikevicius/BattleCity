using UnityEngine;

namespace BattleCity.Miscellaneous
{
    public class StaticVarReseter : MonoBehaviour
    {
        private void Awake()
        {
            Reset();
        }
        public void Reset()
        {
            Buffs.Reset();
            PlayerShooting.ShootenBulletsCount = 0;
            EnemyCounter.EnemyCount            = 20;
            EnemySpawner.ActiveEnemiesCount    = 0;
            EnemySpawner.ShouldSpawnEnemies    = false;
        }
    }
}
