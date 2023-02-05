using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovingScript : MonoBehaviour
{
    private Animator playerAnimator;

    //speed in pixels per second
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 50f;
    private Vector2 PlayerMovement = Vector2.zero;

    public bool isAttacking = false;


    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("AttackRange") || playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("AttackMelee"))
        {
            isAttacking = true;
            rb.velocity = new Vector3(0, 0, 0);
        } 
        else
        {
            isAttacking = false;
            rb.velocity = new Vector3(PlayerMovement.x, 0, PlayerMovement.y) * speed * Time.deltaTime;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        if (input.x != 0 || input.y != 0)
        {
            playerAnimator.SetFloat("playerSpeed", 1);
            playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerAnimator.SetFloat("playerSpeed", 0);
            playerAnimator.SetBool("isRunning", false);
        }

        PlayerMovement = Quaternion.Euler(0, 0, -45) * input;
    }
}

