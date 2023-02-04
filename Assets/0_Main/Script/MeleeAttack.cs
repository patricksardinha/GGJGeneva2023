using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public PlayerSpells s_playerSpells;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy in MELEE attack area");
            s_playerSpells.GetEnemyInMelee(other.gameObject, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy in MELEE attack area");
            s_playerSpells.GetEnemyInMelee(other.gameObject, false);
        }
    }
}
