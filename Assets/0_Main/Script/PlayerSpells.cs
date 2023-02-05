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
    private float timeBetweenAttacks;
    private float timeAttack;

    public PlayerScript playerScript;

    List<GameObject> EnnemiesInMelee = new List<GameObject>();
    List<GameObject> EnnemiesInRange = new List<GameObject>();





    private void Start()
    {
        playerAnimator = GetComponent<Animator>();

        timeAttack = timeBetweenAttacks;
    }

    private void Update()
    {
        timeAttack -= Time.deltaTime;
    }

    public void resetPlayerAttack()
    {
        EnnemiesInMelee.Clear();
        EnnemiesInRange.Clear();
    }

    public void OnPlayerAttackMelee(InputAction.CallbackContext context)
    {
        // The player can attack
        if (timeAttack <= 0)
        {
            Debug.Log("player is attacking melee");

            playerAnimator.Play("AttackMelee");

            //Deals damage to every ennemy in the area
            foreach (GameObject ennemy in EnnemiesInMelee)
            {
                if (!ennemy.GetComponent<EnnemyScript>().isKill)
                {
                    ennemy.GetComponent<EnnemyScript>().TakeDamage(playerScript.meleeDamage);
                }
            }

            //foreach (Transform spawn in MeleeRootSpawns)
            //{
            //    //Must instanciate the gameobject for melee attack
            //    Instantiate(rootAttackPrefab, spawn.position, Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0));
            //}


            IEnumerator cor = Wait(.1f, MeleeRootSpawns);
            StartCoroutine(cor);


            //Reset time between attacks
            timeAttack = timeBetweenAttacks;
        }
    }


    public void OnPlayerAttackRange(InputAction.CallbackContext context)
    {
        // The player can attack
        if (timeAttack <= 0)
        {
            Debug.Log("player is attacking range");

            playerAnimator.Play("AttackRange");

            //Deals damage to every ennemy in the area
            foreach (GameObject ennemy in EnnemiesInRange)
            {
                if (!ennemy.GetComponent<EnnemyScript>().isKill)
                {
                    ennemy.GetComponent<EnnemyScript>().TakeDamage(playerScript.rangeDamage);
                }
            }

            IEnumerator cor = Wait(.1f, RangeRootSpawns);
            StartCoroutine(cor);

            //Reset time between attacks
            timeAttack = timeBetweenAttacks;
        }
    }

    IEnumerator Wait(float sec, Transform[] spawn)
    {
        Instantiate(rootAttackPrefab, spawn[2].position, Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0));
        yield return new WaitForSeconds(sec);

        Instantiate(rootAttackPrefab, spawn[1].position, Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0));
        yield return new WaitForSeconds(sec);

        Instantiate(rootAttackPrefab, spawn[0].position, Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0));
        yield return new WaitForSeconds(sec);
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
