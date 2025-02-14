using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeDodge : MonoBehaviour
{
    public GameObject[] Users;
    public PlayerControllerScrip[] playerControllers;

    public bool gameOver = false;
    public int gameCountDown;
    public GameObject scoreItem;

    // Start is called before the first frame update
    void Start()
    {
        scoreItem = GameObject.Find("ScoreItem");
        Users = GameObject.FindGameObjectsWithTag("Player");
        playerControllers = new PlayerControllerScrip[Users.Length];

        for (int i = 0; i < Users.Length; i++)
        {
            playerControllers[i] = Users[i].GetComponent<PlayerControllerScrip>();
            Rigidbody2D RigBod = Users[i].GetComponent<Rigidbody2D>();
            RigBod.gravityScale = 1;
            Users[i].GetComponent<CapsuleCollider2D>().enabled = true;
        }

        Users[0].transform.position = new Vector3(-5, -3, 0);
        Users[1].transform.position = new Vector3(5, -3, 0);
        Users[2].transform.position = new Vector3(-3, -3, 0);
        Users[3].transform.position = new Vector3(3, -3, 0);

        Array.Resize(ref scoreItem.GetComponent<ScoreItem>().gamesPlayed, scoreItem.GetComponent<ScoreItem>().gamesPlayed.Length + 1);
        scoreItem.GetComponent<ScoreItem>().gamesPlayed[scoreItem.GetComponent<ScoreItem>().gamesPlayed.Length - 1] = SceneManager.GetActiveScene().buildIndex;

    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < Users.Length; i++)
        {
            playerControllers[i].rb.velocity = new Vector2(playerControllers[i].lookAxis * playerControllers[i].playerSpeed, playerControllers[i].rb.velocity.y);

            if (playerControllers[i].dead == true)
            {
                Users[i].GetComponent<CapsuleCollider2D>().enabled = false;
            }
        }

        if (playerControllers[0].dead == true && playerControllers[2].dead == true && gameOver == false) 
        {
            OnEnd();
            Debug.Log("team 2 win");
            scoreItem.GetComponent<ScoreItem>().team2Score++;
        }
        if (playerControllers[1].dead == true && playerControllers[3].dead == true && gameOver == false)
        {
            OnEnd();
            Debug.Log("team 1 win");
            scoreItem.GetComponent<ScoreItem>().team1Score++;
        }
        if (gameCountDown > 1)
        {
            gameCountDown--;
        }
        else if (gameCountDown == 1)
        {
            for (int i = 0; i < Users.Length; i++)
            {
                playerControllers[i].dead = false;
                Users[i].GetComponent<CapsuleCollider2D>().enabled = false;

            }
            SceneManager.LoadScene("BetweenGames");
        }
    }
    void OnEnd()
    {
        gameOver = true;
        if (gameCountDown == 0)
        {
            gameCountDown = 360;
        }
    }
}
