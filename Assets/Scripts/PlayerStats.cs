using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{

    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;

        Rounds = 0;
    }

    private void Enable()
    {
        Rounds = 0;
    }

}
