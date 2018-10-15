using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using BattleCity.Miscellaneous;

namespace BattleCity
{
    public class MainMenu : MonoBehaviour
    {
        public  GameObject   selectObj;
        public  GameObject[] selectPositions;
        private Selections   currecentSelection;

		void Start()
		{
			Cursor.visible = false;
		}
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();

            if (Input.GetKeyDown(KeyCode.DownArrow))
                Next();
            else if (Input.GetKeyDown(KeyCode.UpArrow))
                Previous();
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                switch (currecentSelection)
                {
                    case Selections.Player1:
                    {
                        StartGame();
                        break;
                    }
                    case Selections.Player2:
                    {
                        throw new NotImplementedException();
                    }
                    case Selections.Construction:
                    {
                        throw new NotImplementedException();
                    }
                }
            }
        }
        private void StartGame()
        {
            SceneManager.LoadSceneAsync("Game");
        }
        private void Next()
        {
            if ( (int) (currecentSelection + 1) < selectPositions.Length)
                currecentSelection++;
            else
                currecentSelection = 0;
            selectObj.transform.position = selectPositions[ (int)currecentSelection ].transform.position;
        }
        private void Previous()
        {
            if (currecentSelection > 0)
                currecentSelection--;
            else
                currecentSelection = (Selections)selectPositions.Length - 1;
            selectObj.transform.position = selectPositions[ (int)currecentSelection ].transform.position;
        }

    }
}
