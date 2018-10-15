using System;
using UnityEngine;
using BattleCity.Miscellaneous;

namespace BattleCity
{
    public class PlayerScore : MonoBehaviour
    {
        [SerializeField]private GameObject ScorePrefab;
        [SerializeField]private Sprite[] scoresSprites;

        private Score player1 = new Score();
        private Score player2 = new Score();
        
        public void AddScore(GameObject destroyedObject, Vector3 bulletPos, GameObject player)
        {
            if( player.GetComponent<TankGroup>() == null )
                throw new ArgumentOutOfRangeException("player", player.name + " is not a player");

            Score      scoreToGiveForPlayer = new Score();
            Scores     scoreToGive          = Scores.None;
            TankGroups playerGroup          = player.GetComponent<TankGroup>().Group;

            switch (playerGroup)
            {
                case TankGroups.Player1:
                {
                    scoreToGiveForPlayer = player1;
                    break;
                }
                case TankGroups.Player2:
                {
                    scoreToGiveForPlayer = player2;
                    break;
                }
            }

            if (destroyedObject.GetComponent<TankGroup>() != null)
            {
                TankGroups group = destroyedObject.GetComponent<TankGroup>().Group;
                switch (group)
                {
                    case TankGroups.Basic:
                    {
                        scoreToGiveForPlayer.AddBasicTank();
                        scoreToGive = Scores._100;
                        break;
                    }
                    case TankGroups.Fast:
                    {
                        scoreToGiveForPlayer.AddFastTank();
                        scoreToGive = Scores._200;
                        break;
                    }
                    case TankGroups.Power:
                    {
                        scoreToGiveForPlayer.AddPowerTank();
                        scoreToGive = Scores._300;
                        break;
                    }
                    case TankGroups.Armor:
                    {
                        scoreToGiveForPlayer.AddArmorTank();
                        scoreToGive = Scores._400;
                        break;
                    }
                }
            }
            else if (destroyedObject.GetComponent(typeof(Bonus)))
            {
                scoreToGiveForPlayer.AddPowerUp();
                scoreToGive = Scores._500;
            }

            if (scoreToGive != Scores.None)
                PlayAnimation(bulletPos, scoreToGive);
        }

        private void PlayAnimation(Vector3 bulletPos, Scores _score)
        {
            if(_score == Scores.None)
                throw new ArgumentOutOfRangeException("_score", "Score cannot be none");

            Vector2 pos = bulletPos;
            GameObject scoreObj = Instantiate(ScorePrefab, pos, Quaternion.identity);
            scoreObj.GetComponent<SpriteRenderer>().sprite = scoresSprites[(int)_score];
        }
    }
}
