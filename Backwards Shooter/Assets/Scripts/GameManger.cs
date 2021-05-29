using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : Singleton <GameManger>
{
    private bool playGameState; // stop and play game state
    public bool gameState { get { return playGameState; } set { playGameState = value; } }

    [SerializeField]
    private int countDownTime = 3;
    [SerializeField]
    private Text countTimeText ;


    void Awake()
    {
        base.RegisterSingleton();
    }

    void Start()
    {
        gameState = false;
        StartCoroutine(Timer());
    }

    // a counter before the game starts
    IEnumerator Timer()
    {
        while(countDownTime > 0)
        {
            countTimeText.text = countDownTime.ToString();
            yield return new WaitForSeconds(1);
            countDownTime--;
        }
        countTimeText.text = "GO!";
        yield return new WaitForSeconds(1);
        countTimeText.text = "";
        gameState = true;
    }
}
