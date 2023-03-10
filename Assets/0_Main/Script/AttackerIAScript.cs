using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerIAScript : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 5f;

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
            transform.LookAt(target.transform);
            float DistanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (DistanceToTarget > 8.0f)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                //need to use walking animation
            }
            else if (DistanceToTarget < 4.0f) 
            {
                transform.Translate(Vector3.back * Time.deltaTime * speed/2);
                //need to use walking animation
            }
            else 
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed/2);
                //need to use attack animation
            }
            transform.position.Set(transform.position.x, 1, transform.position.z);
        }
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
}
