using UnityEngine;

public class OpenMaps : MonoBehaviour
{
    public GameObject _maps;
    public GameObject _position;
    private bool isPaused = false;

    void OnMaps()
    {
        ToggleMap();
    }

    void ToggleMap()
    {
        isPaused = !isPaused;

        foreach(GameObject room in GameManager._gameManager._dungeonGenerator.spawnedRooms){
            Room ScriptRoom = room.GetComponent<Room>();
            ScriptRoom.ShowMaps(isPaused);
        }
        _maps.SetActive(isPaused);
        _position.SetActive(isPaused);

        Time.timeScale = isPaused ? 0f : 1f; // Met le jeu en pause ou le reprend
    }
}
