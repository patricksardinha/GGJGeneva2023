using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    [SerializeField] private GameManagerScript gameManager;

    DoorScript(GameManagerScript _gameManager)
    {
        gameManager = _gameManager;
    }

    void onTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.triggerNextRoom();
        }
    }
}
