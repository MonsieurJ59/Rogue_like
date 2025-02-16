using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public GameObject[] roomPrefabs; // Liste des salles préfabriquées
    public GameObject startRoomPrefab; // Salle de départ
    public GameObject endRoomPrefab; // Salle de fin
    public int nbRoom = 12; // Nombre total de salles
    public float roomSizeX = 30f; // Taille d'une salle (distance entre les centres)
    public float roomSizeY = 20f; // Taille d'une salle (distance entre les centres)
    private List<GameObject> spawnedRooms = new List<GameObject>();

    void Start()
    {
        initDungeon();
    }

    public void initDungeon()
    {
        GenerateDungeon();
        startRoomPrefab.GetComponent<Room>().InitRoom();
        SetRoomDoors();
    }

    public void ResetDungeon()
    {
        foreach(GameObject room in spawnedRooms){
            Room thisRoom = room.GetComponent<Room>();
            thisRoom.ResetRoom();
        }

        GameManager._gameManager._ancreCamera.transform.position = Vector3.zero;
        GameManager._gameManager._player.transform.position = Vector3.zero;

        spawnedRooms[0].GetComponent<Room>().StartRoom();
    }

    void GenerateDungeon()
    {
        // 1. Générer la salle initiale
        Vector3 startPosition = Vector3.zero;
        GameObject startRoom = Instantiate(startRoomPrefab, startPosition, Quaternion.identity);
        startRoom.GetComponent<Room>().StartRoom();
        spawnedRooms.Add(startRoom);
        
        // 2. Générer les salles intermédiaires
        while (spawnedRooms.Count < nbRoom)
        {
            AddRandomRoom();
        }

        // 3. Trouver la salle la plus éloignée et la remplacer par la salle de fin
        ReplaceFurthestRoomWithEnd();

        // 4. Numéroté les salles & Stocker les curseRoom
        for (int i = 0; i < spawnedRooms.Count; i++)
        {
            Room thisRoom = spawnedRooms[i].GetComponent<Room>();
            if (thisRoom != null)
            {
                thisRoom.index = i;
            }

            GameManager._gameManager._curseSystem._cursedRooms.Add(spawnedRooms[i].GetComponent<CurseRoom>());
        }

    }

    void AddRandomRoom()
    {
        bool success = false;

        while (!success)
        {
            GameObject randomExistingRoom = spawnedRooms[Random.Range(0, spawnedRooms.Count)];
            Vector3 newPosition = GetRandomFreePosition(randomExistingRoom.transform.position);
            
            if (newPosition != Vector3.zero)
            {
                GameObject newRoom = Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Length)], newPosition, Quaternion.identity);
                spawnedRooms.Add(newRoom);
                success = true;
            }
        }
    }

    Vector3 GetRandomFreePosition(Vector3 roomPosition)
    {
        List<Vector2> directions = new List<Vector2>
        {
            new Vector2(0,1), new Vector2(1,0), new Vector2(0,-1), new Vector2(-1,0)
        };

        directions = ShuffleList(directions);

        foreach (Vector2 dir in directions)
        {
            Vector3 newPosition = roomPosition + new Vector3(dir.x * roomSizeX, dir.y * roomSizeY, 0);
            
            // Vérifier si la position est déjà occupée
            bool positionOccupied = false;
            foreach (GameObject room in spawnedRooms)
            {
                if (room.transform.position == newPosition)
                {
                    positionOccupied = true;
                    break;
                }
            }
            
            if (!positionOccupied)
            {
                return newPosition;
            }
        }
        return Vector3.zero; // Aucune position libre trouvée
    }

    void ReplaceFurthestRoomWithEnd()
    {
        GameObject furthestRoom = null;
        float maxDistance = 0f;
        
        foreach (GameObject room in spawnedRooms)
        {
            float distance = Vector3.Distance(room.transform.position, spawnedRooms[0].transform.position);
            if (distance > maxDistance)
            {
                maxDistance = distance;
                furthestRoom = room;
            }
        }

        if (furthestRoom != null)
        {
            Vector3 endRoomPosition = furthestRoom.transform.position;
            spawnedRooms.Remove(furthestRoom);
            Destroy(furthestRoom);
            GameObject endRoom = Instantiate(endRoomPrefab, endRoomPosition, Quaternion.identity);
            spawnedRooms.Add(endRoom);
        }
    }

    List<Vector2> ShuffleList(List<Vector2> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Vector2 temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
        return list;
    }

    void SetRoomDoors()
    {
        foreach (GameObject room in spawnedRooms)
        {
            Vector3 position = room.transform.position;
            Room upDoor = RoomExistsAt(position + new Vector3(0, roomSizeY, 0));
            Room downDoor = RoomExistsAt(position + new Vector3(0, -roomSizeY, 0));
            Room rightDoor = RoomExistsAt(position + new Vector3(roomSizeX, 0, 0));
            Room leftDoor = RoomExistsAt(position + new Vector3(-roomSizeX, 0, 0));
            bool up = RoomExistsAt(position + new Vector3(0, roomSizeY, 0));
            bool down = RoomExistsAt(position + new Vector3(0, -roomSizeY, 0));
            bool right = RoomExistsAt(position + new Vector3(roomSizeX, 0, 0));
            bool left = RoomExistsAt(position + new Vector3(-roomSizeX, 0, 0));
            
            Room roomScript = room.GetComponent<Room>();
            if (roomScript != null)
            {
                roomScript.SetDoors(up, down, right, left, upDoor, downDoor, rightDoor, leftDoor);
            }
        }
    }

    Room RoomExistsAt(Vector3 position)
    {
        foreach (GameObject room in spawnedRooms)
        {
            if (room.transform.position == position)
            {
                return room.GetComponent<Room>();
            }
        }
        return null;
    }
}
