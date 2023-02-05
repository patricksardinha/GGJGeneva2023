using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private RoomGenerator roomGeneratorScript;
    [SerializeField] private Animator animatorFade;
    [SerializeField] private GameObject UI;

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
            foreach (GameObject ennemy in ennemyArrayList)
            {
                Destroy(ennemy);
            }
            ennemyArrayList.Clear();
            CreateDoor();
            doorCreated = true;
        }
    }

    public void triggerNextRoom()
    {
        ChangingRoom();
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
        foreach (GameObject ennemy in ennemyArrayList)
        {
            ennemy.GetComponent<EnnemyScript>().setTargetIA(player);
        }
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
        UI.SetActive(false);
        animatorFade.Play("Fade_In");
    }
    void Lighten()
    {
        
        animatorFade.Play("Fade_Out");
        UI.SetActive(true);
    }

}
