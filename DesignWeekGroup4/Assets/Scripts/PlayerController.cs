using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerScrip : MonoBehaviour
{
    public float lookAxis;
    public bool aPress;

    public Rigidbody2D rb;
    public float playerSpeed = 5;

    public GameObject miniManager;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(lookAxis * playerSpeed, 0);
    }
    public void LookAxisCall(InputAction.CallbackContext context)
    {
        lookAxis = context.ReadValue<float>();
    }
    public void APressCall(InputAction.CallbackContext context)
    {
        
        aPress = context.action.triggered;
    }

    
}
