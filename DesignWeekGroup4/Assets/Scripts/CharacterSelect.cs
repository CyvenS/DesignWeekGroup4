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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Users.Length < 2)
        {
            Users = GameObject.FindGameObjectsWithTag("Player");
        }
        else
        {
            int Rng = Random.Range(1, 3);
            SceneManager.LoadScene(Rng);
        }
    }
}
