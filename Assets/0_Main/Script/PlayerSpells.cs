using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpells : MonoBehaviour
{
    [SerializeField]
    private GameObject character;

    public GameObject rootAttackPrefab;
    public Transform[] MeleeRootSpawns;
    public Transform[] RangeRootSpawns;

    private Animator playerAnimator;

    [SerializeField]
    private float timeBetweenMeleeAttack;
    private float timeMeleeAttack;
    [SerializeField]
    private float timeBetweenRangeAttack;
    private float timeRangeAttack;

    public PlayerScript playerScript;

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
                ennemy.GetComponent<EnnemyScript>().TakeDamage(playerScript.meleeDamage);
            }

            foreach (Transform spawn in MeleeRootSpawns)
            {
                //Must instanciate the gameobject for melee attack
                Instantiate(rootAttackPrefab, spawn.position, Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0));
            }

            

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
                ennemy.GetComponent<EnnemyScript>().TakeDamage(playerScript.rangeDamage);
            }

            foreach (Transform spawn in RangeRootSpawns)
            {
                //Must instanciate the gameobject for range attack
                Instantiate(rootAttackPrefab, spawn.position, Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0));
            }

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
