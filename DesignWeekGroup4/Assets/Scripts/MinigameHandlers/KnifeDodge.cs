using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeDodge : MonoBehaviour
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

        Users[0].transform.position = new Vector3(-5, -3, 0);
        Users[1].transform.position = new Vector3(5, -3, 0);

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

        if (playerControllers[0].dead == true) //UPDATE FOR 4PLAYER
        {
            onEnd();
            Debug.Log("team 2 win");
        }
        if (playerControllers[1].dead == true)
        {
            onEnd();
            Debug.Log("team 1 win");
        }
    }
    void onEnd()
    {
        //loadnewlvl
    }
}
