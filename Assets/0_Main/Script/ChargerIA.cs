using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerIA : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 5.0f;

    private bool detectTarget = false;
    
    
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
        if (target != null && detectTarget)
        {
            transform.LookAt(target.transform);
            float DistanceToTarget = Vector3.Distance(transform.position, target.transform.position);

            if (DistanceToTarget > 2.0f)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }

            

        }
        else if (target != null && !detectTarget)
        {
            transform.LookAt(target.transform);
            float DistanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (DistanceToTarget < 10f)
            {
                detectTarget = true;
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
}
