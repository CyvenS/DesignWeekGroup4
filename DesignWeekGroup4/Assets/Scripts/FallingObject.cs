using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public GameObject self;
    public Rigidbody2D Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        self = gameObject;
        Rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < -20)
        {
            transform.position = new Vector3(Random.Range(-15.0f, 15.0f), Random.Range(20.0f, 30.0f), 0);

            if (GameObject.FindGameObjectsWithTag("Falling").Length < 20 && Random.Range(1,4) == 1)
            {
                GameObject clone = Instantiate(self);
                clone.transform.position = new Vector3(Random.Range(-10.0f, 10.0f), 20, 0);
            }
        }

        if (Rigidbody.velocity.y < -10)
        {
            Rigidbody.velocity = new Vector3(0,-10, 0);
        }
    }
}
