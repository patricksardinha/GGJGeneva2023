using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private RoomGenerator roomGeneratorScript;

    private ArrayList ennemyArrayList = new ArrayList();
    private bool doorCreated = false;
    // Start is called before the first frame update
    void Start()
    {
        ennemyArrayList = roomGeneratorScript.GetEnemies();
        CreateRoom();
    }

    // Update is called once per frame
    void Update()
    {
        bool allDead = true;
        foreach (GameObject ennemy in ennemyArrayList)
        {
            if (!ennemy.GetComponent<EnnemyScript>().isKill)
            {
                allDead = false;
                break;
            }
            
        }

        if (allDead && !doorCreated)
        {
            CreateDoor();
            doorCreated = true;
        }
    }

    void CreateDoor()
    {
        roomGeneratorScript.GenerateDoors();
        doorCreated = true;
    }

    void RespawnPlayer()
    {
        player.transform.position = new Vector3(4, 0, 4);
    }

    void ClearRoom()
    {
        roomGeneratorScript.ClearRoom();
    }
    void CreateRoom()
    {
        roomGeneratorScript.initiateRoom();
    }

    void ChangingRoom()
    {
        Darkness();
        ClearRoom();
        CreateRoom();
        RespawnPlayer();
        Lighten();
    }
    void Darkness()
    {
        //darkness
    }
    void Lighten()
    {
        //lighten
    }

}
