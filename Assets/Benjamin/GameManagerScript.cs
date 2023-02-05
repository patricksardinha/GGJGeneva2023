using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject RoomGenerator;

    private ArrayList ennemyArrayList = new ArrayList();
    private bool doorCreated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     /*   if (ennemyArrayList.Count == 0 && !doorCreated)
        {
            createDoor();
        }
     */
    }
/*
    void CreateDoor()
    {
        doorCreated = true;
        //create door from pcg
    }

    void ChangeRoom()
    {
        Darkness();
        ClearRoom();
        CreateRoom();
        CreateEnemys();
    }
    void StartRoom()
    {
        CreateRoom();
        CreateEnemys();
        
    }

    void RespawnPlayer()
    {
        player.transform.position = new Vector3(4, 0, 4);
    }

    void ClearRoom()
    {
        RoomGenerator.clearRoom();
    }
    void CreateRoom()
    {
        RoomGenerator.GetComponent<RoomGenerator>().GenerateRoom();
    }

    void CreateEnemys()
    {
        RoomGenerator.GetComponent<RoomGenerator>().GenerateEnnemy();
    }

    void destroyEnemy()
    {
        RoomGenerator.GetComponent<RoomGenerator>().DestroyEnnemy();
    }

    void destroyRoom()
    {
        RoomGenerator.GetComponent<RoomGenerator>().DestroyRoom();
    }

    void createDoorRoom()
    {
        RoomGenerator.GetComponent<RoomGenerator>().CreateDoor();
    }

    void Darkness()
    {
        //darkness
    }
*/
}
