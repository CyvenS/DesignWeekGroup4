using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class TugOfWar : MonoBehaviour
{
    public int team1Tug;
    public int team2Tug;


    public bool user1CoolDown;
    public bool user2CoolDown;
    public bool user3CoolDown;
    public bool user4CoolDown;

    public int SampScore;
    public float sampDif;

    public int gameCountDown;
    public bool gameOver = false;

    public GameObject Rope;
    public GameObject[] Users;
    public PlayerControllerScrip[] playerControllers;
    public GameObject scoreItem;
    // Start is called before the first frame update
    void Start()
    {
        scoreItem = GameObject.Find("ScoreItem");
        SampScore = 50;
        Rope = GameObject.Find("Rope");
        Users = GameObject.FindGameObjectsWithTag("Player");
        playerControllers = new PlayerControllerScrip[Users.Length];

        for (int i = 0; i < Users.Length; i++)
        {
            playerControllers[i] = Users[i].GetComponent<PlayerControllerScrip>();

        }

        Users[0].transform.position = new Vector3(-5, 0, 0);
        Users[1].transform.position = new Vector3(5, 0, 0);

        Array.Resize(ref scoreItem.GetComponent<ScoreItem>().gamesPlayed, scoreItem.GetComponent<ScoreItem>().gamesPlayed.Length + 1);
        scoreItem.GetComponent<ScoreItem>().gamesPlayed[scoreItem.GetComponent<ScoreItem>().gamesPlayed.Length - 1] = SceneManager.GetActiveScene().buildIndex;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false)
        {
            Users[0].transform.position = new Vector3(-5, 0, 0) + Rope.transform.position;
            Users[1].transform.position = new Vector3(5, 0, 0) + Rope.transform.position;
            Users[2].transform.position = new Vector3(-3, 0, 0) + Rope.transform.position;
            Users[3].transform.position = new Vector3(3, 0, 0) + Rope.transform.position;
        }
        if (playerControllers[0].aPress && user1CoolDown == true)
        {
            team1Tug++;
            user1CoolDown = false;
        }
        if (playerControllers[1].aPress && user2CoolDown == true)
        {
            team2Tug++;
            user2CoolDown = false;
        }

        if (!playerControllers[0].aPress)
        {
            user1CoolDown = true;
        }
        if (!playerControllers[1].aPress)
        {
            user2CoolDown = true;
        }


        if (playerControllers[2].aPress && user3CoolDown == true)
        {
            team1Tug++;
            user3CoolDown = false;
        }
        if (playerControllers[3].aPress && user4CoolDown == true)
        {
            team2Tug++;
            user4CoolDown = false;
        }

        if (!playerControllers[2].aPress)
        {
            user3CoolDown = true;
        }
        if (!playerControllers[3].aPress)
        {
            user4CoolDown = true;
        }


        sampDif = (team2Tug - team1Tug);
        Rope.transform.position = new Vector3(sampDif/10, 0, 0);

        if (sampDif < -20 || team1Tug >= SampScore)
        {
            RunWin(1);
        }
        if (sampDif > 20 || team2Tug >= SampScore)
        {
            RunWin(2);
        }

        if (gameCountDown > 1)
        {
            gameCountDown--;
        }
        else if (gameCountDown == 1)
        {
            SceneManager.LoadScene("BetweenGames");
        }
    }
    void RunWin(int winTeam)
    {
        Debug.Log("team " + winTeam + " wins");

        if (winTeam == 1 && !gameOver)
        {
            playerControllers[1].OnDeath();
            playerControllers[3].OnDeath();
            gameOver = true;
            scoreItem.GetComponent<ScoreItem>().team1Score++;
        }
        else if (winTeam == 2 && !gameOver)
        {
            playerControllers[0].OnDeath();
            playerControllers[2].OnDeath();
            gameOver = true;
            scoreItem.GetComponent<ScoreItem>().team2Score++;
        }
        if (gameCountDown == 0)
        {
            gameCountDown = 360;
        }
    }
}
