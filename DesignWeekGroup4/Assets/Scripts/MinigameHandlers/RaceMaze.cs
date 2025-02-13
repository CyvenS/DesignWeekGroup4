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
            Rigidbody2D RigBod = Users[i].GetComponent<Rigidbody2D>();
            RigBod.gravityScale = 1;
            Users[i].GetComponent<CapsuleCollider2D>().enabled = true;
        }

        Users[0].transform.position = new Vector3(-5, 15, 0);
        Users[1].transform.position = new Vector3(5, 15, 0);



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
            if (Users[i].transform.position.y < -10)
            {
                Users[i].transform.position = new Vector3(0, -50, 0);
                Debug.Log("Team win" + i);
                onEnd();
            }
        }
    }
    void onEnd()
    {
        for (int j = 0; j < Users.Length; j++)
        {
            playerControllers[j].OnDeath();
            Users[j].GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
}
