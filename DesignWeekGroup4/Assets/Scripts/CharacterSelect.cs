using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public int t1p1Colour;
    public int t1p1Hat;
    public int t1p2Colour;
    public int t1p2Hat;

    public int t2p1Colour;
    public int t2p1Hat;
    public int t2p2Colour;
    public int t2p2Hat;

    public string[] colourOpts;
    public bool[] colourOptsSelected;

    public GameObject[] Users;
    public PlayerControllerScrip[] playerControllers;

    // Start is called before the first frame update
    void Start()
    {
        Users = GameObject.FindGameObjectsWithTag("Player");
        playerControllers = new PlayerControllerScrip[2];

        for (int i = 0; i < Users.Length; i++)
        {
            playerControllers[i] = Users[i].GetComponent<PlayerControllerScrip>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Users.Length < 2)
        {
            Users = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < Users.Length; i++)
            {
                playerControllers[i] = Users[i].GetComponent<PlayerControllerScrip>();
            }
        }
        else
        {
            if (playerControllers[0].aPress && playerControllers[1].aPress)
            {
                int Rng = Random.Range(1, 3);
                SceneManager.LoadScene(Rng);
            }
        }

        Users[0].transform.position = new Vector3(-7, Users[0].transform.position.y, Users[0].transform.position.z);
        Users[1].transform.position = new Vector3(7, Users[1].transform.position.y, Users[1].transform.position.z);
    }
}
