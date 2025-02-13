using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class TugOfWar : MonoBehaviour
{
    public int team1Tug;
    public int team2Tug;


    public bool user1CoolDown;
    public bool user2CoolDown;

    public int SampScore;
    public float sampDif;

    public bool gameOver = false;

    public GameObject Rope;
    public GameObject[] Users;
    public PlayerControllerScrip[] playerControllers;
    // Start is called before the first frame update
    void Start()
    {
        SampScore = 50;
        Rope = GameObject.Find("Rope");
        Users = GameObject.FindGameObjectsWithTag("Player");
        playerControllers = new PlayerControllerScrip[Users.Length];

        for (int i = 0; i < Users.Length; i++)
        {
            playerControllers[i] = Users[i].GetComponent<PlayerControllerScrip>();

            Users[i].transform.SetParent(Rope.transform, true);
        }

        Users[0].transform.position = new Vector3(-5, 0, 0);
        Users[1].transform.position = new Vector3(5, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

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


        sampDif = (team2Tug - team1Tug);
        Rope.transform.position = new Vector3(sampDif/10, 0, 0);

        if (sampDif < -20 || team1Tug >= SampScore)
        {
            RunWin(1,2);
        }
        if (sampDif > 20 || team2Tug >= SampScore)
        {
            RunWin(2, 1);
        }
    }
    void RunWin(int winTeam, int loseTeam)
    {
        Debug.Log("team " + winTeam + " wins");

        if (winTeam == 1 && !gameOver)
        {
            playerControllers[1].OnDeath();
            gameOver = true;
        }
        else if (winTeam == 2 && !gameOver)
        {
            playerControllers[0].OnDeath();
            gameOver = true;
        }

    }
}
