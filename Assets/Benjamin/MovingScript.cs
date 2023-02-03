using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovingScript : MonoBehaviour
{
    //speed in pixels per second
    [SerializeField] private float speed = 50f;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Move(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        transform.Translate(new Vector3(input.x * speed, 0, input.y * speed) * Time.deltaTime);
        
    }
}

