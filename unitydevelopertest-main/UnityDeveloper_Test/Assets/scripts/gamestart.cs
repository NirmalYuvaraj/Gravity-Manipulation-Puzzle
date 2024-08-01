using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamestart : MonoBehaviour
{
    
    public float gameplstart;
    private float gameovertime =180f;
    private gamestarttoend gamestarttoends;
    GameObject maincharactor;
    public static gamestart gamestarts {  get; private set; }
    public enum gamestarttoend
    {
        waitingtostart,
        gamestart,
        gameover
    }
    private void Awake()
    {
        gamestarttoends = gamestarttoend.waitingtostart;
        gamestarts =this;
    }

    void Update()
    {
        switchthegame();
        if(GameObject.Find("Exo Gray") == null)
        {
            gameover();
        }
    }
    void switchthegame()
    {
        switch (gamestarttoends)
        {
            case gamestarttoend.waitingtostart:
               gameplstart = gameovertime;
                gamestarttoends = gamestarttoend.gamestart;
                break;
            case gamestarttoend.gamestart:
                gameplstart -= Time.deltaTime;
                if (gameplstart < 1)
                {
                   
                    gamestarttoends = gamestarttoend.gameover;
                }  
                break ;
            case gamestarttoend.gameover:
                break ;


        }
        Debug.Log(gamestarttoends);
    }
  
    public int minutes()
    {
        int minutes;
        return minutes = Mathf.FloorToInt(gameplstart / 60);
    }
    public int second()
    {
        int second;
        return second = Mathf.FloorToInt(gameplstart % 60);
    }
    public bool gameover()
    {
        return gamestarttoends == gamestarttoend.gameover;
    }
}