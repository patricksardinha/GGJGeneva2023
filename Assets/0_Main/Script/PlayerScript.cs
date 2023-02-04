using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] private float life = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {

    }

    public void TakeDamage(float damage)
    {
        life -= damage;
        Debug.Log("Player life: " + life);
        //need to use taking damage animation
        //and if life <= 0, need to use death animation
    }

    public void ResetPlayerToSpawnPoint()
    {
        //need to reset to spawn point
    }

}