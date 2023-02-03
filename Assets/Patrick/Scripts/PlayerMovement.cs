using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject player;
    private Rigidbody rb;

    [SerializeField]
    private float playerSpeed = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Player Movement Input System
        if (Input.GetKey(KeyCode.UpArrow))
            rb.velocity = transform.forward * playerSpeed;
        if (Input.GetKey(KeyCode.DownArrow))
            rb.velocity = -transform.forward * playerSpeed;
        if (Input.GetKey(KeyCode.RightArrow))
            rb.velocity = transform.right * playerSpeed;
        if (Input.GetKey(KeyCode.LeftArrow))
            rb.velocity = -transform.right * playerSpeed;

        // Player Attack Input System
        if (Input.GetKey(KeyCode.Q))
            PlayerAttackMelee();
        if (Input.GetKey(KeyCode.E)) 
            PlayerAttackRange();
    }

    private void PlayerAttackMelee()
    {
        Debug.Log("player is attacking melee");

    }

    private void PlayerAttackRange()
    {
        Debug.Log("player is attacking range");
    }

}
