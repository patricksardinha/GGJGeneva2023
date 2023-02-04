using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    public PlayerSpells s_playerSpells;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy in RANGE attack area");
            s_playerSpells.GetEnemyInRange(other.gameObject, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy in RANGE attack area");
            s_playerSpells.GetEnemyInRange(other.gameObject, false);
        }
    }
}
