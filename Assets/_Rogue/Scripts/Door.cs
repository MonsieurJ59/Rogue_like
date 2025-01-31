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
                    break;
                case dir.bot :
                    GameManager._gameManager._player.transform.position = _nextRoom._spawnTop.position;
                    break;
                case dir.right :
                    GameManager._gameManager._player.transform.position = _nextRoom._spawnLeft.position;
                    break;
                case dir.left :
                    GameManager._gameManager._player.transform.position = _nextRoom._spawnRight.position;
                    break;
            }

            _myRoom.CloseRoom();
            _nextRoom.InitRoom();
           
        }
    }

}
