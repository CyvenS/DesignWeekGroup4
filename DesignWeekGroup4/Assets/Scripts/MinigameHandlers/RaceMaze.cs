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
            Users[i].transform.position = new Vector3(Users[i].transform.position.x, 15, Users[i].transform.position.y);
            Rigidbody2D RigBod = Users[i].GetComponent<Rigidbody2D>();
            RigBod.gravityScale = 1;
            Users[i].GetComponent<CapsuleCollider2D>().enabled = true;
        }



    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 2; i++)
        {
            playerControllers[i].rb.velocity = new Vector2(playerControllers[i].lookAxis * playerControllers[i].playerSpeed, playerControllers[i].rb.velocity.y);

        }

        for (int i = 0; i < Users.Length; i++)
        {
            if (Users[i].transform.position.y < -7)
            {
                Debug.Log("Team win" + i);

                for (int j = 0; j < Users.Length; j++)
                {
                    Users[j].GetComponent<CapsuleCollider2D>().enabled = false;
                }
            }
        }
    }
}
