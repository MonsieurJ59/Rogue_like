using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _gameManager;
    public GameObject _player;
    public PlayerStats _playerStats;
    public PlayerHealthSystem _playerHealthSystem;
    public CurseSystem _curseSystem;
    public GameObject _ancreCamera;
    public DungeonGenerator _dungeonGenerator;

    void Awake()
    {
        if(!GameManager._gameManager)
        {
            GameManager._gameManager = this;
        }
        Destroy(this);
    }

}
