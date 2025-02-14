using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using TMPro;
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

    public int loadCount;
    public TextMeshProUGUI countdown;

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

        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if (Users.Length < 4)
        {
            Users = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < Users.Length; i++)
            {
                playerControllers[i] = Users[i].GetComponent<PlayerControllerScrip>();
                Users[0].transform.position = new Vector3(-7, Users[0].transform.position.y, Users[0].transform.position.z);
                Users[1].transform.position = new Vector3(7, Users[1].transform.position.y, Users[1].transform.position.z);

                Users[0].transform.GetChild(0).gameObject.SetActive(true);
                Users[1].transform.GetChild(1).gameObject.SetActive(true);

                Users[2].transform.position = new Vector3(-3, Users[3].transform.position.y, Users[3].transform.position.z);
                Users[3].transform.position = new Vector3(3, Users[4].transform.position.y, Users[4].transform.position.z);

                Users[2].transform.GetChild(2).gameObject.SetActive(true);
                Users[3].transform.GetChild(3).gameObject.SetActive(true);

            }

        }
        else
        {
            if (playerControllers[0].aPress && playerControllers[1].aPress && playerControllers[2].aPress && playerControllers[3].aPress)
            {
                //if both players hold action for 3 seconds, game starts.
                if (loadCount > 480)
                {
                    int Rng = Random.Range(3, SceneManager.sceneCountInBuildSettings);
                    SceneManager.LoadScene(Rng);
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
        }
        //all this is just a messy way to display a countdown while both players hold action
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



        // customization

    }
}
