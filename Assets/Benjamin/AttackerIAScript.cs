using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerIAScript : MonoBehaviour
{
    [SerializeField] private GameObject EnnemyScript;
    [SerializeField] private GameObject target;
    
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
        if (target != null)
        {
            EnnemyScript.GetComponent<EnnemyScript>().TakeDamage(1);
        }
    }
}
