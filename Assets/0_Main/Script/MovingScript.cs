using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovingScript : MonoBehaviour
{
    //speed in pixels per second
    [SerializeField] private float speed = 50f;
    private Vector2 PlayerMovement = Vector2.zero;


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
        transform.Translate(new Vector3(PlayerMovement.x * speed, 0, PlayerMovement.y * speed) * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        PlayerMovement = Quaternion.Euler(0, 0, 45) * input;

    }
}

