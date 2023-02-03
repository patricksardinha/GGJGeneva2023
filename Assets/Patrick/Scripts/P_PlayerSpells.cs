using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class P_PlayerSpells : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float playerSpeed = 5.0f;

    // Player attacking state
    // [True] : disable attack
    // [False] : enable attack
    private bool isAttacking;

    // Collider zone of attack player
    private BoxCollider colliderZoneMelee;
    private BoxCollider colliderZoneRange;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        colliderZoneMelee = gameObject.transform.GetChild(0).GetComponent<BoxCollider>();
        colliderZoneRange = gameObject.transform.GetChild(1).GetComponent<BoxCollider>();

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
        /*
        if (Input.GetKey(KeyCode.Q))
            PlayerAttackMeleeStart();
        if (Input.GetKey(KeyCode.E)) 
            PlayerAttackRangeStart();
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collision with enemy");
        }
    }

    private void OnPlayerAttackMeleeStart(InputAction.CallbackContext context)
    {
        Debug.Log("player is attacking melee");
        // Player Animation attack melee

    }

    private void PlayerAttackMeleeEnd()
    {

    }

    private void OnPlayerAttackRangeStart(InputAction.CallbackContext context)
    {
        Debug.Log("player is attacking range");
        // Player Animation attack range
    }

    private void PlayerAttackRangeEnd()
    {

    }

}
