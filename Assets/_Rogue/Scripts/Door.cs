using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum dir{
        top,
        bot,
        right,
        left,
    }
    public bool _isOpen = false;
    public dir _dir;
    public GameObject _openVisuel;
    public GameObject _closeVisuel;
    public Room _myRoom;
    public Room _nextRoom;

    public void Close()
    {
        _isOpen = false;
        _openVisuel.SetActive(false);
        _closeVisuel.SetActive(true);
    }

    public void Open()
    {
        _isOpen = true;
        _openVisuel.SetActive(true);
        _closeVisuel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _isOpen)
        {
            switch(_dir){
                case dir.top :
                    GameManager._gameManager._player.transform.position = _nextRoom._spawnBot.position;
                    GameManager._gameManager._ancreCamera.transform.position = GameManager._gameManager._ancreCamera.transform.position + new Vector3(0,GameManager._gameManager._dungeonGenerator.roomSizeY,0);
                    break;
                case dir.bot :
                    GameManager._gameManager._player.transform.position = _nextRoom._spawnTop.position;
                    GameManager._gameManager._ancreCamera.transform.position = GameManager._gameManager._ancreCamera.transform.position + new Vector3(0,-GameManager._gameManager._dungeonGenerator.roomSizeY,0);
                    break;
                case dir.right :
                    GameManager._gameManager._player.transform.position = _nextRoom._spawnLeft.position;
                    GameManager._gameManager._ancreCamera.transform.position = GameManager._gameManager._ancreCamera.transform.position + new Vector3(GameManager._gameManager._dungeonGenerator.roomSizeX,0,0);
                    break;
                case dir.left :
                    GameManager._gameManager._player.transform.position = _nextRoom._spawnRight.position;
                    GameManager._gameManager._ancreCamera.transform.position = GameManager._gameManager._ancreCamera.transform.position + new Vector3(-GameManager._gameManager._dungeonGenerator.roomSizeX,0,0);
                    break;
            }

            _myRoom.CloseRoom();
            _nextRoom.StartRoom();
           
        }
    }

}
