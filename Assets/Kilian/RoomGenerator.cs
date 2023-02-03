using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public int xRoom = 10;
    public int zRoom = 5;
    public GameObject floorPrefab;
    public GameObject wallPrefab;
    public Transform roomParent;
    private ArrayList floorArr = new ArrayList();
    private ArrayList wallArr = new ArrayList();
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
            GenerateWalls(xRoom, zRoom);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClearTiles();
        }
    }

    private void GenerateFloor(int xRoom, int zRoom)
    {
        Debug.Log("Generate the Floor");

        for (int x = 0; x < xRoom; x++)
        {
            for (int z = 0; z < zRoom; z++)
            {
                int tileID = 1;
                Vector3 tilePosition = new Vector3(x, 0, z);
                tileObj = (tileID, tilePosition);

                floorArr.Add(Instantiate(floorPrefab, tileObj.tilePosition, Quaternion.identity, roomParent));
            }
        }        
    }

    private void GenerateWalls(int xRoom, int zRoom)
    {
        Debug.Log("Generate Walls");
        for (int x = 0; x < xRoom; x++)
        {
            int wallID = 1;
            Vector3 wallPosition = new Vector3(x, 0, zRoom);
            tileObj = (wallID, wallPosition);

            wallArr.Add(Instantiate(wallPrefab, tileObj.tilePosition, Quaternion.identity, roomParent));
        }

        for (int z = 0; z < zRoom; z++)
        {
            int wallID = 1;
            Vector3 wallPosition = new Vector3(xRoom, 0, z);
            tileObj = (wallID, wallPosition);

            wallArr.Add(Instantiate(wallPrefab, tileObj.tilePosition, Quaternion.identity, roomParent));
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
