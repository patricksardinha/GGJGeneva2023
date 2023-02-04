using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpells : MonoBehaviour
{
    public GameObject meleeAttack;

    [SerializeField]
    private GameObject character;

    private Animator playerAnimator;

    [SerializeField]
    private float timeBetweenMeleeAttack;
    private float timeMeleeAttack;
    [SerializeField]
    private float timeBetweenRangeAttack;
    private float timeRangeAttack; 



    List<GameObject> EnnemiesInMelee = new List<GameObject>();
    List<GameObject> EnnemiesInRange = new List<GameObject>();





    private void Start()
    {
        playerAnimator = GetComponent<Animator>();

        timeMeleeAttack = timeBetweenMeleeAttack;
        timeRangeAttack = timeBetweenRangeAttack;
    }

    private void Update()
    {
        timeMeleeAttack -= Time.deltaTime;
        timeRangeAttack -= Time.deltaTime;
    }


    public void OnPlayerAttackMelee(InputAction.CallbackContext context)
    {
        // The player can attack
        if (timeMeleeAttack <= 0)
        {
            Debug.Log("player is attacking melee");

            playerAnimator.SetTrigger("attackMelee");

            //Deals damage to every ennemy in the area
            foreach (GameObject ennemy in EnnemiesInMelee)
            {
                ennemy.GetComponent<EnnemyScript>().TakeDamage(5f);
            }

            //Must instanciate the gameobject for melee attack

            //Reset time between attacks
            timeMeleeAttack = timeBetweenMeleeAttack;
        }
    }


    public void OnPlayerAttackRange(InputAction.CallbackContext context)
    {
        Debug.Log("player is attacking range");

        // The player can attack
        if (timeRangeAttack <= 0)
        {
            Debug.Log("(attackRange)");

            playerAnimator.SetTrigger("attackRange");

            //Deals damage to every ennemy in the area
            foreach (GameObject ennemy in EnnemiesInRange)
            {
                ennemy.GetComponent<EnnemyScript>().TakeDamage(2f);
            }

            //Must instanciate the gameobject for melee attack

            //Reset time between attacks
            timeRangeAttack = timeBetweenRangeAttack;
        }
    }

    internal void GetEnemyInMelee(GameObject gameObject, bool inArea)
    {
        if (inArea)
        {
            EnnemiesInMelee.Add(gameObject);
        }
        else
        {
            EnnemiesInMelee.Remove(gameObject);
        }
    }

    internal void GetEnemyInRange(GameObject gameObject, bool inArea)
    {
        if (inArea)
        {
            EnnemiesInRange.Add(gameObject);
        }
        else
        {
            EnnemiesInRange.Remove(gameObject);
        }
    }
}
