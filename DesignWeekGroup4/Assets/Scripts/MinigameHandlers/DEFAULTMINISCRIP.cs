using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEFAULTMINISCRIP : MonoBehaviour
{
    public GameObject[] Users;
    public PlayerControllerScrip[] playerControllers;
    public GameObject scoreItem;
    // Start is called before the first frame update
    void Start()
    {
        scoreItem = GameObject.Find("ScoreItem");
        Users = GameObject.FindGameObjectsWithTag("Player");
        playerControllers = new PlayerControllerScrip[Users.Length];

        playerControllers[0] = Users[0].GetComponent<PlayerControllerScrip>();
        playerControllers[1] = Users[1].GetComponent<PlayerControllerScrip>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
