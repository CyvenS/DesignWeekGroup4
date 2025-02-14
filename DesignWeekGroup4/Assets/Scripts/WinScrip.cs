using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScrip : MonoBehaviour
{
    public GameObject[] Users;
    public PlayerControllerScrip[] playerControllers;
    public GameObject scoreItem;
    public TextMeshProUGUI countdown;
    public TextMeshProUGUI winner;
    public ScoreItem scoreItemScrip;
    public int loadCount;
    // Start is called before the first frame update
    void Start()
    {
        scoreItem = GameObject.Find("ScoreItem");
        scoreItemScrip = scoreItem.GetComponent<ScoreItem>();
        Users = GameObject.FindGameObjectsWithTag("Player");
        playerControllers = new PlayerControllerScrip[Users.Length];

        playerControllers[0] = Users[0].GetComponent<PlayerControllerScrip>();
        playerControllers[1] = Users[1].GetComponent<PlayerControllerScrip>();


        if (scoreItemScrip.team1Score == 3)
        {
            winner.text = "Team 1 Wins!";
        }

        if (scoreItemScrip.team2Score == 3)
        {
            winner.text = "Team 2 Wins!";
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
                scoreItemScrip.gamesPlayed = new int[0];
                Destroy(scoreItem);
                Destroy(GameObject.FindGameObjectsWithTag("Player")[0]);
                Destroy(GameObject.FindGameObjectsWithTag("Player")[1]);
                Destroy(GameObject.Find("BGM"));
                Destroy(GameObject.Find("DeathSound"));
                SceneManager.LoadScene("SampleScene");

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
