using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool Traversed = false;
    

    
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("aa");
        if (other.gameObject.tag == "Player")
        {
            Traversed = true;
            Debug.Log("Door traversed: ");
        }
    }
    
    
}
