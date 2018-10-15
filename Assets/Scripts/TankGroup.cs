using BattleCity.Miscellaneous;
using UnityEngine;

namespace BattleCity
{
    public class TankGroup : MonoBehaviour
    {
        [SerializeField] private TankGroups group;
        public TankGroups Group { get { return group; } set { group = value; } }

        private void Start()
        {
            Group = group;
        }
    }
}
