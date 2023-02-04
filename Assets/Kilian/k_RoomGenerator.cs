using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class k_RoomGenerator : MonoBehaviour
{
    public Animator anim;
    public int minRoomSize = 15;
    public int maxRoomSize = 50;


    public List<float> anglesForTiles = new List<float> { 0.0f, 90.0f, 180.0f, 270.0f };

    private List<int> rouletTen = new List<int>() { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1};


    [SerializeField] private int xRoom;
    [SerializeField] private int zRoom;

    public GameObject[] floorPrefab;
    public GameObject frontWallPrefab;
    public GameObject wallPrefab;
    public GameObject[] enemiesPrefabs;

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

        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            anim.Play("Fade_In");
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            anim.Play("Fade_Out");
        }
    }

    private void GenerateRoomSize(int min, int max)
    {
        xRoom = UnityEngine.Random.Range(min, max);
        zRoom = UnityEngine.Random.Range(min, max);
    }


    private void GenerateRoom(int xRoom, int zRoom)
    {
        GenerateFloor(xRoom, zRoom);
        GenerateBackWalls(xRoom, zRoom);
        GenerateFrontWalls(xRoom, zRoom);

        GenerateEnemies(xRoom, zRoom);
    }



    private void GenerateFloor(int xRoom, int zRoom)
    {
        Debug.Log("Generate the Floor");
        

        for (int x = 0; x < xRoom; x += 2)//(int)Mathf.Floor(floorPrefab[0].transform.localScale.x))
        {
            for (int z = 0; z < zRoom; z += 2)//(int)Mathf.Floor(floorPrefab[0].transform.localScale.z))
            { 
                int tileID = 1;
                Vector3 tilePosition = new Vector3(x, 0, z);
                tileObj = (tileID, tilePosition);
                
                floorArr.Add(Instantiate(floorPrefab[rouletTen[UnityEngine.Random.Range(0,rouletTen.Count)]], tileObj.tilePosition, Quaternion.Euler(0, anglesForTiles[UnityEngine.Random.Range(0, anglesForTiles.Count)], 0), roomParent));
            }
        }
    }

    private void GenerateBackWalls(int xRoom, int zRoom)
    {
        Debug.Log("Generate Walls");
        for (int x = 0; x < xRoom; x++)
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
        for (int x = 0; x < xRoom; x++)
        {
            int frontWallID = 1;
            Vector3 frontWallPosition = new Vector3(x, frontWallPrefab.transform.localScale.y / 2, -1);
            tileObj = (frontWallID, frontWallPosition);
            wallArr.Add(Instantiate(frontWallPrefab, tileObj.tilePosition, Quaternion.identity, roomParent));
        }

        for (int z = 0; z < zRoom; z++)
        {
            int frontWallID = 1;
            Vector3 frontWallPosition = new Vector3(-1, frontWallPrefab.transform.localScale.y / 2, z);
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

        // Instanciate nb of enemy according difficulty & nb of tiles
        // replace spawnPosition

        for (int i = 0; i < spawnPosition.Count; i++)
        {
            enemiesArr.Add(Instantiate(enemiesPrefabs[UnityEngine.Random.Range(0, enemiesPrefabs.Length-1)], spawnPosition[0], Quaternion.identity, roomParent));
        }
    }

    private List<Vector3> GenerateSpawn()
    {
        List<Vector3> posSpawner = new List<Vector3>();

        int randX = UnityEngine.Random.Range(8, xRoom);
        int randZ = UnityEngine.Random.Range(8, zRoom);
        posSpawner.Add(new Vector3(randX, 0.5f, randZ));

        return posSpawner;
    }


    private void ClearRoom()
    {
        ClearTiles();
        ClearDoors();
        ClearEnemies();
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
