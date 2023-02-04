using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class P_PlayerSpells : MonoBehaviour
{
    [SerializeField]
    private P_SpellsBehaviour spellBehaviourScript;

    private Rigidbody rb;

    [SerializeField]
    private float playerSpeed = 5.0f;

    // Player attacking state
    // [True] : enable attack
    // [False] : disable attack
    private bool isAttackReady;

    // Collider zone of attack player
    [SerializeField]
    private GameObject ZoneMelee;
    [SerializeField]
    private GameObject ZoneRange;

    private MeshCollider meshColliderZoneMelee;
    private MeshCollider meshColliderZoneRange;

    private Animator playerAnimator;

    [SerializeField]
    private GameObject meleeSpellPrefab;
    //[SerializeField]
    //private GameObject rangeSpellPrefab;

    public Transform spellParent;
    // Array to stock lauched spells
    private ArrayList spellsArray = new ArrayList();

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Zone collider to detect collisions
        meshColliderZoneMelee = ZoneMelee.GetComponent<MeshCollider>();
        meshColliderZoneRange = ZoneRange.GetComponent<MeshCollider>();
        meshColliderZoneMelee.enabled = false;
        meshColliderZoneRange.enabled = false;

        playerAnimator = GetComponent<Animator>();
        // Init attack
        isAttackReady = true;
    }

    private void Update()
    {

        if (((Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.LeftArrow))) && isAttackReady)
        {
            playerAnimator.SetFloat("playerSpeed", 1);

            // Player Movement Input System
            if (Input.GetKey(KeyCode.UpArrow))
                rb.velocity = transform.forward * playerSpeed;
            if (Input.GetKey(KeyCode.DownArrow))
                rb.velocity = -transform.forward * playerSpeed;
            if (Input.GetKey(KeyCode.RightArrow))
                rb.velocity = transform.right * playerSpeed;
            if (Input.GetKey(KeyCode.LeftArrow))
                rb.velocity = -transform.right * playerSpeed;
        } 
        else
        {
            playerAnimator.SetFloat("playerSpeed", 0);
        }

        // Player Attack Input System
        
        if (Input.GetKey(KeyCode.Q))
            OnPlayerAttackMelee();
        
        if (Input.GetKey(KeyCode.E)) 
            OnPlayerAttackRange();

        Debug.Log("?" + isAttackReady);
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
            if (meshColliderZoneMelee.enabled == true)
            {
                Debug.Log("Collision on melee zone");
            }
            else if (meshColliderZoneRange.enabled == true)
            {
                Debug.Log("Collision on range zone");
            }
            else {
                Debug.Log("Collision on player");
            } 
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

            isAttackReady = false;
            // Stop movement when attacking
            playerAnimator.SetFloat("playerSpeed", 0);

            // Play animation clip calling PlayerAttackMeleeStart() / PlayerAttackMeleeEnd()
            playerAnimator.SetTrigger("attackMelee");

            // Instanciate Go related to the melee spell
            spellsArray.Add(Instantiate(meleeSpellPrefab, new Vector3(0,0,0), Quaternion.identity, spellParent));
            // Play spell animation
            spellBehaviourScript.spellMelee();

        }
    }

    /// <summary>
    /// Animation event start attack melee.
    /// </summary>
    private void PlayerAttackMeleeStart()
    {
        // Animation Event Keyframe on clip animation [Start]
        // Enable melee zone collider to detect melee collisions
         meshColliderZoneMelee.enabled = true;
    }

    /// <summary>
    /// Animation event end attack melee.
    /// </summary>
    private void PlayerAttackMeleeEnd()
    {
        // Animation Event Keyframe on clip animation [End]
        // Disable melee zone collider
        meshColliderZoneMelee.enabled = false;
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
            playerAnimator.SetTrigger("attackRange");
            // Stop movement when attacking
            playerAnimator.SetFloat("playerSpeed", 0);
            isAttackReady = false;
        }

    }

    /// <summary>
    /// Animation event start attack range.
    /// </summary>
    private void PlayerAttackRangeStart()
    {
        // Animation Event Keyframe on clip animation [Start]
        // Enable range zone collider to detect range collisions
        meshColliderZoneRange.enabled = true;
    }

    /// <summary>
    /// Animation event end attack range.
    /// </summary>
    private void PlayerAttackRangeEnd()
    {
        // Animation Event Keyframe on clip animation [End]
        // Disable range zone collider
        meshColliderZoneRange.enabled = false;
        isAttackReady = true;
    }

}
