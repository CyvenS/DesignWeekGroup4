using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerScrip : MonoBehaviour
{
    public float lookAxis;
    public bool aPress;

    public Rigidbody2D rb;
    public float playerSpeed = 5;

    public GameObject miniManager;
    public GameObject yolks;

    public bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LookAxisCall(InputAction.CallbackContext context)
    {
        lookAxis = context.ReadValue<float>();
    }
    public void APressCall(InputAction.CallbackContext context)
    {
        
        aPress = context.action.triggered;
    }


    public void OnDeath()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject newyolk = Instantiate(yolks);
            newyolk.name.EndsWith(i.ToString());
            newyolk.transform.position = transform.position;
            newyolk.GetComponent<Rigidbody2D>().velocity = new Vector3 (Random.Range(-5.0f, 5.0f), Random.Range(3.0f, 7.0f));
        }
        transform.position = new Vector3(transform.position.x, -100, transform.position.z);
        dead = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        OnDeath();
    }

}
