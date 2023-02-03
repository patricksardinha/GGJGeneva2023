using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject player;
    private Rigidbody rb;

    [SerializeField]
    private float playerSpeed = 5.0f;

    // Player attacking state
    // [True] : disable attack
    // [False] : enable attack
    private bool isAttacking;

    // Centers points of attack
    [SerializeField]
    private float centerPointAttackMelee;

    [SerializeField]
    private float centerPointAttackRange;

    // Radius attack
    [SerializeField]

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Init attack
        isAttacking = false;
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
        // Player Animation attack melee

    }

    private void PlayerAttackRange()
    {
        Debug.Log("player is attacking range");
        // Player Animation attack range
    }

}
