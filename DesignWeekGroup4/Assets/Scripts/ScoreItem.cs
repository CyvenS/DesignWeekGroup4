using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    public int[] gamesPlayed;

    public int team1Score;
    public int team2Score;



    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    public void ScoreUp(int teamToScore)
    {
        if (teamToScore == 1)
        {
            team1Score++;
        }
        if (teamToScore == 2)
        {
            team2Score++;
        }

        CheckWinner();
    }
    public void CheckWinner()
    {
        if (team1Score == 3)
        {
            //load victory scene
        }
        if (team2Score == 3)
        {
            //load victory scene
        }
    }
}
