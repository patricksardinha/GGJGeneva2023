using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public int minRoomSize = 15;
    public int maxRoomSize = 50;


    public List<float> anglesForTiles = new List<float> { 0.0f, 90.0f, 180.0f, 270.0f };

    private List<int> rouletTen = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };

    public int roomLevel = 0;

    [SerializeField] private int xRoom;
    [SerializeField] private int zRoom;

    public GameObject[] floorPrefab;
    public GameObject frontWallPrefab;
    public GameObject wallPrefab;
    public GameObject[] enemiesPrefabs;
    public float enemySize = 3.0f;

    public GameObject RDoor;
    public GameObject LDoor;

    public Transform roomParent;
    private ArrayList floorArr = new ArrayList();
    private ArrayList wallArr = new ArrayList();
    private ArrayList doorArr = new ArrayList();
    private ArrayList enemiesArr = new ArrayList();

    private (int tileID, Vector3 tilePosition) tileObj;

    // Start is called before the first frame update
    void Start()
    {
        GenerateRoomSize(minRoomSize, maxRoomSize);

        GenerateRoom(xRoom, zRoom);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ClearRoom();
            GenerateRoomSize(minRoomSize, maxRoomSize);
            GenerateRoom(xRoom, zRoom);
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            ClearDoors();
            GenerateDoors(xRoom, zRoom);
        }
    }

    private void GenerateRoomSize(int min, int max)
    {
        xRoom = UnityEngine.Random.Range(min, max);
        zRoom = UnityEngine.Random.Range(min, max);

        if (xRoom % 2 == 0)
            xRoom++;
        if (zRoom % 2 == 0)
            zRoom++;
    }


    private void GenerateRoom(int xRoom, int zRoom)
    {
        roomLevel++;

        GenerateFloor(xRoom, zRoom);
        GenerateBackWalls(xRoom, zRoom);
        GenerateFrontWalls(xRoom, zRoom);

        GenerateEnemies(xRoom, zRoom);
    }

    private void GenerateFloor(int xRoom, int zRoom)
    {
        Debug.Log("Generate the Floor");

        for (int x = 0; x < xRoom; x += (int)Mathf.Floor(floorPrefab[1].gameObject.transform.GetComponent<BoxCollider>().size.x))
        {
            for (int z = 0; z < zRoom; z += (int)Mathf.Floor(floorPrefab[1].gameObject.transform.GetComponent<BoxCollider>().size.z))
            {
                int tileID = 1;
                Vector3 tilePosition = new Vector3(x, 0, z);
                tileObj = (tileID, tilePosition);

                floorArr.Add(Instantiate(floorPrefab[rouletTen[UnityEngine.Random.Range(0, rouletTen.Count)]], tileObj.tilePosition, Quaternion.Euler(0, anglesForTiles[UnityEngine.Random.Range(0, anglesForTiles.Count)], 0), roomParent));
            }
        }
    }

    private void GenerateBackWalls(int xRoom, int zRoom)
    {
        Debug.Log("Generate Walls");
        for (int x = 0; x < xRoom + 1; x++)
        {
            int wallID = 1;
            Vector3 wallPosition = new Vector3(x, wallPrefab.transform.localScale.y / 2, zRoom);
            tileObj = (wallID, wallPosition);
            wallArr.Add(Instantiate(wallPrefab, tileObj.tilePosition, Quaternion.identity, roomParent));
        }

        for (int z = 0; z < zRoom; z++)
        {
            int wallID = 1;
            Vector3 wallPosition = new Vector3(xRoom, wallPrefab.transform.localScale.y / 2, z);
            tileObj = (wallID, wallPosition);

            wallArr.Add(Instantiate(wallPrefab, tileObj.tilePosition, Quaternion.identity, roomParent));
        }
    }

    private void GenerateFrontWalls(int xRoom, int zRoom)
    {
        Debug.Log("Generate front Walls");
        for (int x = -1; x < xRoom + 1; x++)
        {
            int frontWallID = 1;
            Vector3 frontWallPosition = new Vector3(x, (-frontWallPrefab.transform.localScale.y/2)+1, -1);
            tileObj = (frontWallID, frontWallPosition);
            wallArr.Add(Instantiate(frontWallPrefab, tileObj.tilePosition, Quaternion.identity, roomParent));
        }

        for (int z = 0; z < zRoom + 1; z++)
        {
            int frontWallID = 1;
            Vector3 frontWallPosition = new Vector3(-1, (-frontWallPrefab.transform.localScale.y / 2) + 1, z);
            tileObj = (frontWallID, frontWallPosition);
            wallArr.Add(Instantiate(frontWallPrefab, tileObj.tilePosition, Quaternion.identity, roomParent));
        }
    }

    private void GenerateDoors(int xRoom, int zRoom)
    {
        //Right door positionning
        float widthDoor = RDoor.transform.localScale.z;
        Vector3 pos = new Vector3(xRoom, RDoor.transform.localScale.y / 2, UnityEngine.Random.Range(1 + widthDoor / 2, zRoom - 1 - widthDoor / 2));
        doorArr.Add(Instantiate(RDoor, pos, Quaternion.identity, roomParent));

        //Left door positionning
        widthDoor = LDoor.transform.localScale.x;
        pos = new Vector3(UnityEngine.Random.Range(1 + widthDoor / 2, xRoom - 1 - widthDoor / 2), LDoor.transform.localScale.y / 2, zRoom);
        doorArr.Add(Instantiate(LDoor, pos, Quaternion.identity, roomParent));
    }

    private void GenerateEnemies(int xRoom, int zRoom)
    {

        List<Vector3> spawnPosition = GenerateSpawn();

        for (int i = 0; i < spawnPosition.Count; i++)
        {
            enemiesArr.Add(Instantiate(enemiesPrefabs[UnityEngine.Random.Range(0, enemiesPrefabs.Length)], spawnPosition[i], Quaternion.identity, roomParent));
        }
    }

    private List<Vector3> GenerateSpawn()
    {
        List<Vector3> posSpawner = new List<Vector3>();

        int difficulty = ComputeDifficulty();

        int iteration = 0;

        for (int i = 0; i < difficulty; i++)
        {
            // Avoid spawn last layer
            int randX = UnityEngine.Random.Range(8, xRoom - 1);
            int randZ = UnityEngine.Random.Range(8, zRoom - 1);

            bool verifiedSpawn = CheckSpawn(randX, randZ, posSpawner);

            if (verifiedSpawn)
            {
                posSpawner.Add(new Vector3(randX, 0.5f, randZ));
            }
            else
            {
                i--;
                iteration++;
            }

            if (iteration > 10)
            {
                Debug.Log("Iteration Break");
                break;
            }
        }

        return posSpawner;
    }

    private bool CheckSpawn(int x, int z, List<Vector3> listSpawn)
    {
        Vector3 newSpawn = new Vector3(x, 0, z);

        foreach (Vector3 spawn in listSpawn)
        {
            if (Vector3.Distance(newSpawn, spawn) < enemySize)
                return false;
        }
        return true;
    }

    private int ComputeDifficulty()
    {
        int difficulty;
        // Compute difficulty according : [roomlevel] & [roomsize]
        // [ ( xRoom * zRoom ) / 500 ] + [ roomlevel / 10 ]
        // [Room Min size] : ceil[((15) * (15)) / 250] + ceil[] = 0.9 + [] = 1 + []
        // [Room Max size] : ceil[((50+1) * (50+1)) / 250] + ceil[] = 10.404 + [] = 11 + []
        difficulty = (int)Mathf.Ceil(((xRoom * zRoom) / 250)) + (int)Mathf.Ceil(roomLevel / 10);
        return difficulty;
    }

    private void ClearRoom()
    {
        ClearTiles();
        ClearDoors();
        //ClearEnemies();
    }

    private void ClearTiles()
    {
        foreach (GameObject tile in floorArr)
        {
            Destroy(tile);
        }
        floorArr.Clear();

        foreach (GameObject tile in wallArr)
        {
            Destroy(tile);
        }
        wallArr.Clear();
    }

    private void ClearDoors()
    {
        foreach (GameObject door in doorArr)
        {
            Destroy(door);
        }
        doorArr.Clear();
    }

    private void ClearEnemies()
    {
        foreach (GameObject enemy in enemiesArr)
        {
            Destroy(enemy);
        }
        enemiesArr.Clear();
    }
}