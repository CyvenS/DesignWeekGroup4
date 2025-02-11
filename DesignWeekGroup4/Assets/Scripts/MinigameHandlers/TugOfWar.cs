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
    public int sampDif;

    public GameObject[] Users;
    public PlayerControllerScrip[] playerControllers;
    // Start is called before the first frame update
    void Start()
    {
        SampScore = 20;
        Users = GameObject.FindGameObjectsWithTag("Player");
        playerControllers = new PlayerControllerScrip[Users.Length];

        playerControllers[0] = Users[0].GetComponent<PlayerControllerScrip>();
        playerControllers[1] = Users[1].GetComponent<PlayerControllerScrip>();

    }

    // Update is called once per frame
    void Update()
    {
        playerControllers[0] = Users[0].GetComponent<PlayerControllerScrip>();
        playerControllers[1] = Users[1].GetComponent<PlayerControllerScrip>();

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


        sampDif = team2Tug - team1Tug;

        if (team1Tug >= SampScore)
        {
            //team1win
            Debug.Log("team1 win");
        }
        if (team2Tug >= SampScore)
        {
            //team2win
            Debug.Log("team2 win");
        }
    }
}
