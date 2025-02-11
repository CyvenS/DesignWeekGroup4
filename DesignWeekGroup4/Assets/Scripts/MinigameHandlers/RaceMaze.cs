using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceMaze : MonoBehaviour
{
    public GameObject[] Users;
    public PlayerControllerScrip[] playerControllers;
    // Start is called before the first frame update
    void Start()
    {
        Users = GameObject.FindGameObjectsWithTag("Player");
        playerControllers = new PlayerControllerScrip[Users.Length];

        for (int i = 0; i < Users.Length; i++)
        {
            playerControllers[i] = Users[i].GetComponent<PlayerControllerScrip>();
        }

        for (int i = 0; i < Users.Length; i++)
        {
            Users[i].transform.position = new Vector3(Users[i].transform.position.x, 15, Users[i].transform.position.y);
            Rigidbody2D RigBod = Users[i].GetComponent<Rigidbody2D>();
            RigBod.gravityScale = 6;
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Users.Length; i++)
        {
            if (Users[i].transform.position.y < 10)
            {
                Debug.Log("Team win" + Users[i]);
            }
        }
    }
}
