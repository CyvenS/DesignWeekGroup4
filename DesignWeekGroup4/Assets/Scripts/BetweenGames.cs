using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        ScoreItemObj = GameObject.Find("ScoreItem");
        ScoreItemScrip = ScoreItemObj.GetComponent<ScoreItem>();
        Users = GameObject.FindGameObjectsWithTag("Player");
        playerControllers = new PlayerControllerScrip[Users.Length];

        Users[0].transform.position = new Vector3(-5, 0, 0);
        Users[1].transform.position = new Vector3(5, 0, 0);

        for (int i = 0; i < Users.Length; i++)
        {
            playerControllers[i] = Users[i].GetComponent<PlayerControllerScrip>();
            Rigidbody2D RigBod = Users[i].GetComponent<Rigidbody2D>();
            RigBod.gravityScale = 0;
            RigBod.velocity = new Vector3 (0, 0, 0);

            playerControllers[i].dead = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllers[0].aPress && playerControllers[1].aPress)
        {
            //if both players hold action for 3 seconds, game starts.
            if (loadCount > 480)
            {
                bool loop = true;
                while (loop)
                {
                    int Rng = Random.Range(2, 5);
                    validGame = true;

                    if (ScoreItemScrip.gamesPlayed.Length == SceneManager.sceneCountInBuildSettings + 2)
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
    }
}
