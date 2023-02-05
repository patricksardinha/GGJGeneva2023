using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameOverManager GameOverManager_Script;
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private float life = 50f;
    public float meleeDamage = 5f;
    public float rangeDamage = 2f;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar.GetComponent<HealthBar>().SetMaxHealth(life);
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.GetComponent<HealthBar>().SetHealth(life);
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

        if (life <= 0)
        {
            Death();
        }
    }

    public void ResetPlayerToSpawnPoint()
    {
        //need to reset to spawn point
    }

    public void Death()
    {
        GameOverManager_Script.GameOver();
    }
}
