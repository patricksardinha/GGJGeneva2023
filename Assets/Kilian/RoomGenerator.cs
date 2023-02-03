using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public int xRoom = 10;
    public int zRoom = 5;
    public GameObject floorTile;
    public Transform floorParent;
    private ArrayList floorArr = new ArrayList();
    private (int tileID, Vector3 tilePosition) tileObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GenerateFloor(xRoom, zRoom);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClearTiles();
        }
    }

   

    private void GenerateFloor(int xRoom, int zRoom)
    {
        Debug.Log("GenerateFloor");

        for (int x = 0; x < xRoom; x++)
        {
            for (int z = 0; z < zRoom; z++)
            {
                int tileID = 1;
                Vector3 tilePosition = new Vector3(x, 0, z);
                tileObj = (tileID, tilePosition);

                floorArr.Add(Instantiate(floorTile, tileObj.tilePosition, Quaternion.identity, floorParent));
            }
        }        
    }

    private void ClearTiles()
    {
        foreach (GameObject tile in floorArr)
        {
            Destroy(tile);
        }
        floorArr.Clear();
    }
}
