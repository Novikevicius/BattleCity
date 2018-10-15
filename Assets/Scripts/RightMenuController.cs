using UnityEngine;

namespace BattleCity
{
    public class RightMenuController : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] numbers;
        [SerializeField]
        private GameObject player1Health;
        [SerializeField]
        private GameObject player2Health;

        public void DisplayPlayer1Health(int health)
        {
            player1Health.GetComponent<SpriteRenderer>().sprite = numbers[health];
        }
        public void DisplayPlayer2Health(int health)
        {
            player2Health.GetComponent<SpriteRenderer>().sprite = numbers[health];
        }
    }
}
