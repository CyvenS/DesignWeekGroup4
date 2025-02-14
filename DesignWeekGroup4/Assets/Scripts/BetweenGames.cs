using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BetweenGames : MonoBehaviour
{
    public GameObject ScoreItemObj;
    public ScoreItem ScoreItemScrip;
    public int loadCount;
    public bool validGame = false;
    public GameObject[] Users;
    public PlayerControllerScrip[] playerControllers;
    public TextMeshProUGUI countdown;

    public GameObject t1egg1;
    public GameObject t1egg2;
    public GameObject t1egg3;

    public GameObject t2egg1;
    public GameObject t2egg2;
    public GameObject t2egg3;

    // Start is called before the first frame update
    void Start()
    {

        ScoreItemObj = GameObject.Find("ScoreItem");
        ScoreItemScrip = ScoreItemObj.GetComponent<ScoreItem>();
        Users = GameObject.FindGameObjectsWithTag("Player");
        playerControllers = new PlayerControllerScrip[Users.Length];

        Users[0].transform.position = new Vector3(-5, 0, 0);
        Users[1].transform.position = new Vector3(5, 0, 0);
        Users[2].transform.position = new Vector3(-3, 0, 0);
        Users[3].transform.position = new Vector3(3, 0, 0);

        for (int i = 0; i < Users.Length; i++)
        {
            playerControllers[i] = Users[i].GetComponent<PlayerControllerScrip>();
            Rigidbody2D RigBod = Users[i].GetComponent<Rigidbody2D>();
            RigBod.gravityScale = 0;
            RigBod.velocity = new Vector3 (0, 0, 0);

            playerControllers[i].dead = false;
        }

        if (ScoreItemScrip.team1Score == 3 || ScoreItemScrip.team2Score == 3)
        {
            SceneManager.LoadScene("WinScreen");
        }


        if (ScoreItemScrip.team1Score > 0)
        {
            t1egg1.SetActive(true);
            if (ScoreItemScrip.team1Score > 1)
            {
                t1egg2.SetActive(true);
                if (ScoreItemScrip.team1Score > 2)
                {
                    t1egg3.SetActive(true);
                }

            }
        }
        if (ScoreItemScrip.team2Score > 0)
        {
            t2egg1.SetActive(true);
            if (ScoreItemScrip.team2Score > 1)
            {
                t2egg2.SetActive(true);
                if (ScoreItemScrip.team2Score > 2)
                {
                    t2egg3.SetActive(true);
                }

            }
        }
;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllers[0].aPress && playerControllers[1].aPress && playerControllers[2].aPress && playerControllers[3].aPress)
        {
            //if both players hold action for 3 seconds, game starts.
            if (loadCount > 480)
            {
                bool loop = true;
                while (loop)
                {
                    int Rng = Random.Range(3, SceneManager.sceneCountInBuildSettings);
                    validGame = true;

                    if (ScoreItemScrip.gamesPlayed.Length == SceneManager.sceneCountInBuildSettings - 3)
                    {
                        ScoreItemScrip.gamesPlayed = new int[0];
                    }
                    for (int i = 0; i < ScoreItemScrip.gamesPlayed.Length; i++)
                    {
                        if (ScoreItemScrip.gamesPlayed[i] == Rng)
                        {
                            validGame = false;
                        }
                    }
                    if (validGame == true)
                    {
                        loop = false;
                        SceneManager.LoadScene(Rng);
                    }
                }
            }
            else
            {
                loadCount++;
            }
        }
        else
        {
            loadCount = 0;
        }


        if (loadCount == 0)
        {

            countdown.text = " ";
        }
        if (loadCount == 120)
        {

            countdown.text = 3.ToString();
        }
        if (loadCount == 240)
        {

            countdown.text = 2.ToString();
        }
        if (loadCount == 360)
        {

            countdown.text = 1.ToString();
        }
    }
}
