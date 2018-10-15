using System;
using BattleCity;
using BattleCity.Miscellaneous;
using UnityEngine;

public class LevelLoadindScreenController : MonoBehaviour
{
    [SerializeField] private GameObject number1;
    [SerializeField] private GameObject number2;
    [SerializeField] private Sprite[]   numbers;
    [SerializeField] private Transform rightMenuStageDisplay;

    private bool isFirstLevel = true;
    
	void Awake ()
	{
	    if (number1 == null)
	        throw new NullReferenceException("Number1 object is not set in inspector");
        if (number2 == null)
            throw new NullReferenceException("Number2 object is not set in inspector");
        if (rightMenuStageDisplay == null)
            throw new NullReferenceException("RightMenuStageDisplay object is not set in inspector");

        var mapSpawnerScript = GameObject.Find("MapSpawner").GetComponent<MapSpawner>();
        mapSpawnerScript.OnLevelLoaded += OnLevelLoaded;
	    mapSpawnerScript.OnLevelLoadingStart += OnLevelLoadingStart;
    }
    void OnLevelLoaded(System.Object obj, EventArgs args)
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    void OnLevelLoadingStart(System.Object obj, EventArgs args)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        int level = MapSpawner.GetActiveLevel().Lv;
        if (level <= 0)
            level = 1;
        if (isFirstLevel)
            isFirstLevel = false;
        else level++;
        if(level > 0 && level < 71)
        {
            var firstNumber = (int)Math.Truncate(level / 10f);
            var secondNumber = level - firstNumber * 10;
            number1.GetComponent<SpriteRenderer>().sprite = numbers[firstNumber];
            number2.GetComponent<SpriteRenderer>().sprite = numbers[secondNumber];
            rightMenuStageDisplay.GetChild(0).GetComponent<SpriteRenderer>().sprite = numbers[firstNumber];
            rightMenuStageDisplay.GetChild(1).GetComponent<SpriteRenderer>().sprite = numbers[secondNumber];
        }
        else throw new ArgumentOutOfRangeException("level", "\"" + level + "\"" + " level must be between 1 and 70");
    }

}
