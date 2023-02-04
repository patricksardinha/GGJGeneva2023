using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpells : MonoBehaviour
{
    // Player attacking state
    // [True] : enable attack
    // [False] : disable attack
    private bool isAttackReady;

    // Collider zone of attack player
    private MeshCollider colliderZoneMelee;
    private MeshCollider colliderZoneRange;

    private Animator playerAnimator;

    // TODO:SetFloat speedPlayer to enable running animation
    //      Stop player's movement when attacking
    // -> playerScript.cs

    private void Start()
    {
        // Zone collider : Child 0 & 1 of Character gameobject
        colliderZoneMelee = gameObject.transform.GetChild(0).GetComponent<MeshCollider>();
        colliderZoneRange = gameObject.transform.GetChild(1).GetComponent<MeshCollider>();

        playerAnimator = GetComponent<Animator>();

        // Player can directly attack at start
        isAttackReady = true;
        
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
    public void OnPlayerAttackMelee(InputAction.CallbackContext context)
    {
        Debug.Log("player is attacking melee");

        // The player can attack
        if (isAttackReady)
        {
            Debug.Log("(attackMelee)???");

            isAttackReady = false;

            // Stop movement when attacking
            playerAnimator.SetFloat("playerSpeed", 0);

            // Play animation clip calling PlayerAttackMeleeStart() / PlayerAttackMeleeEnd()
            playerAnimator.SetTrigger("attackMelee");
        }
    }

    /// <summary>
    /// Animation event start attack melee.
    /// </summary>
    public void PlayerAttackMeleeStart()
    {
        // Animation Event Keyframe on clip animation [Start]
        // Enable melee zone collider to detect melee collisions
        colliderZoneMelee.enabled = true;
    }

    /// <summary>
    /// Animation event end attack melee.
    /// </summary>
    public void PlayerAttackMeleeEnd()
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

    public void OnPlayerAttackRange(InputAction.CallbackContext context)
    {
        Debug.Log("player is attacking range");

        // The player can attack
        if (isAttackReady)
        {
            Debug.Log("(attackRange)");
            isAttackReady = false;

            // Stop movement when attacking
            playerAnimator.SetFloat("playerSpeed", 0);

            // Play animation clip calling PlayerAttackRangeStart() / PlayerAttackRangeEnd()
            playerAnimator.SetTrigger("attackRange");
        }

    }

    /// <summary>
    /// Animation event start attack range.
    /// </summary>
    public void PlayerAttackRangeStart()
    {
        // Animation Event Keyframe on clip animation [Start]
        // Enable range zone collider to detect range collisions
        colliderZoneRange.enabled = true;
    }

    /// <summary>
    /// Animation event end attack range.
    /// </summary>
    public void PlayerAttackRangeEnd()
    {
        // Animation Event Keyframe on clip animation [End]
        // Disable range zone collider
        colliderZoneRange.enabled = false;
        isAttackReady = true;
    }

}
