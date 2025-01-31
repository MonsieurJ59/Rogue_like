using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _gameManager;
    public GameObject _player;
    public PlayerStats _playerStats;
    public PlayerHealthSystem _playerHealthSystem;
    public CurseSystem _curseSystem;

    void Awake()
    {
        if(!GameManager._gameManager)
        {
            GameManager._gameManager = this;
        }
        Destroy(this);
    }

}
