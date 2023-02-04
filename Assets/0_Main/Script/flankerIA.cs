using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flankerIA : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 2f;
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
        {
            transform.LookAt(target.transform);
            float DistanceToTarget = Vector3.Distance(transform.position, target.transform.position);

            transform.Translate((Vector3.forward + Vector3.right) * Time.deltaTime * speed);
            //need to use walking animation

        }
    }
}
