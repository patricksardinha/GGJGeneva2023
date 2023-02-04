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
    // [True] : enable attack
    // [False] : disable attack
    private bool isAttackReady;

    // Collider zone of attack player
    private BoxCollider colliderZoneMelee;
    private BoxCollider colliderZoneRange;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        colliderZoneMelee = gameObject.transform.GetChild(0).GetComponent<BoxCollider>();
        colliderZoneRange = gameObject.transform.GetChild(1).GetComponent<BoxCollider>();

        // Init attack
        isAttackReady = true;
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
            OnPlayerAttackMelee();
        
        if (Input.GetKey(KeyCode.E)) 
            OnPlayerAttackRange();
        
    }

    /// <summary>
    /// Dections of collisions with enemies.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collision with enemy");
        }
    }

    /// <summary>
    /// Player using melee attack.
    /// </summary>
    /// <param name="context">From the input system.</param>

    //private void OnPlayerAttackMelee(InputAction.CallbackContext context)
    private void OnPlayerAttackMelee()
    {
        Debug.Log("player is attacking melee");

        // Player Animation attack melee
        if (isAttackReady)
        {
            Debug.Log("playerAnimator.SetTrigger(attackMelee)");

            // Play animation clip calling PlayerAttackMeleeStart() / PlayerAttackMeleeEnd()
            //playerAnimator.SetTrigger("attackMelee");
            isAttackReady = false;
        }
    }

    private void PlayerAttackMeleeStart()
    {
        // Animation Event Keyframe on clip animation [Start]
        // Enable melee zone collider to detect melee collisions
         colliderZoneMelee.enabled = true;
    }

    private void PlayerAttackMeleeEnd()
    {
        // Animation Event Keyframe on clip animation [End]
        // Disable melee zone collider
        colliderZoneMelee.enabled = false;
        isAttackReady = true;
    }

    /// <summary>
    /// Player using range attack.
    /// </summary>
    /// <param name="context">From the input system.</param>
    
    //private void OnPlayerAttackRange(InputAction.CallbackContext context)
    private void OnPlayerAttackRange()
    {
        Debug.Log("player is attacking range");

        // Player Animation attack range
        if (isAttackReady)
        {
            Debug.Log("playerAnimator.SetTrigger(attackRange)");

            // Play animation clip calling PlayerAttackRangeStart() / PlayerAttackRangeEnd()
            //playerAnimator.SetTrigger("attackRange");
            isAttackReady = false;
        }

    }

    private void PlayerAttackRangeStart()
    {
        // Animation Event Keyframe on clip animation [Start]
        // Enable range zone collider to detect range collisions
        colliderZoneRange.enabled = true;
    }

    private void PlayerAttackRangeEnd()
    {
        // Animation Event Keyframe on clip animation [End]
        // Disable range zone collider
        colliderZoneRange.enabled = false;
        isAttackReady = true;
    }

}
