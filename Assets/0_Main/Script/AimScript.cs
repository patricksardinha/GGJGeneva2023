using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimScript : MonoBehaviour
{
    private Quaternion PlayerDirection = Quaternion.identity;
    public MovingScript movingScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.rotation = PlayerDirection;
    }

    public void Aim(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        if (context.canceled)
        {
            return;
        }
        input = Quaternion.Euler(0, 0, -45) * input;

        if (!movingScript.isAttacking)
        {
            PlayerDirection = Quaternion.LookRotation(new Vector3(input.x, 0, input.y), Vector3.up);
        }
    }
}
