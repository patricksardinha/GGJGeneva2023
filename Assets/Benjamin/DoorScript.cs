using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool Traversed = false;
    void onTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Traversed = true;
        }
    }
    
    
}
