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

    public GameObject Rope;
    public GameObject[] Users;
    public PlayerControllerScrip[] playerControllers;
    // Start is called before the first frame update
    void Start()
    {
        SampScore = 20;
        Rope = GameObject.Find("Rope");
        Users = GameObject.FindGameObjectsWithTag("Player");
        playerControllers = new PlayerControllerScrip[Users.Length];

        for (int i = 0; i < Users.Length; i++)
        {
            playerControllers[i] = Users[i].GetComponent<PlayerControllerScrip>();

            Users[i].transform.SetParent(Rope.transform, true);
        }

        Users[0].transform.position = new Vector3(-5, Users[0].transform.position.y, Users[0].transform.position.z);
        Users[1].transform.position = new Vector3(5, Users[1].transform.position.y, Users[1].transform.position.z);
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


        if (team1Tug >= SampScore)
        {
            RunWin(1);
        }
        if (team2Tug >= SampScore)
        {
            RunWin(2);
        }
    }
    void RunWin(int winTeam)
    {
        Debug.Log("team " + winTeam + " wins");
    }
}
