using UnityEngine;

public class Buffs : MonoBehaviour
{
    private static int player1HP = 2;

    public static int Player1Health
    {
        get { return player1HP; }
        set
        {
            if (value >= 0)
            {
                player1HP = value;
            }
        }
    }

    public static void Reset()
    {
        player1HP = 2;
    }
    private void Start()
    {
        player1HP = 2;
    }
}
