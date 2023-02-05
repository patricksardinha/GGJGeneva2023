using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyScript : MonoBehaviour
{

    [SerializeField] private float speed = 20f;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float attackSpeed = 1f;
    [SerializeField] private float attackDamage = 1f;
    [SerializeField] private float life = 1f;
    [SerializeField] private GameObject IaBehavior;
    public bool isKill = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        
        currentPos.y = 1;
    
        transform.position = currentPos;
    }

    void FixedUpdate()
    {
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player touched");
            collision.gameObject.GetComponent<PlayerScript>().TakeDamage(attackDamage);
            //need to use attack animation
            
        }
    }

    public bool TakeDamage(float damage)
    {
        life -= damage;
        Debug.Log("Ennemy life: " + life);
        //need to use taking damage animation
        //and if life <= 0, need to use death animation
        if(life <= 0)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
            isKill = true;
            return true;
        }
        return false;
    }
}
