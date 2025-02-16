using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room : MonoBehaviour
{
    public int index;
    public bool clear = false;
    public bool started = false;
    public CurseRoom _curseRoom;

    public bool canUp;
    public bool canDown;
    public bool canLeft;
    public bool canRight;

    public List<GameObject> _enemies;
    public UnityEvent _initEvent;
    public UnityEvent _clearEvent;

    [Header("Doors Settings")]
    public GameObject _doorTop;
    public GameObject _doorBot;
    public GameObject _doorLeft;
    public GameObject _doorRight;

    [Header("Spawn Setting")]
    public Transform _spawnTop;
    public Transform _spawnBot;
    public Transform _spawnRight;
    public Transform _spawnLeft;

    void Start()
    {
        foreach (GameObject enemy in _enemies)
        {
            // Désactive l'ennemi et réinitialise ses valeurs
            enemy.SetActive(false);
            enemy.GetComponent<EnemyData>().SetInitValues(this);
        }

        _curseRoom = GetComponent<CurseRoom>();
    }

    public void ResetRoom(){
        clear = false;
        started = false;
        foreach (GameObject enemy in _enemies)
        {
            // Désactive l'ennemi et réinitialise ses valeurs
            enemy.SetActive(false);
        }
        SetDoors();
    }

    public void StartRoom()
    {
        if(started){
            return;
        }
        foreach (GameObject enemy in _enemies)
        {
            // Active l'ennemi et initialise ses données
            enemy.SetActive(true);
            enemy.GetComponent<EnemyData>().InitEnemy();
        }
        started = true;
    }

    public void InitRoom()
    {
        _doorTop.SetActive(false);
        _doorBot.SetActive(false);
        _doorLeft.SetActive(false);
        _doorRight.SetActive(false);

        _doorTop.GetComponent<Door>()._isOpen = false;
        _doorBot.GetComponent<Door>()._isOpen = false;
        _doorLeft.GetComponent<Door>()._isOpen = false;
        _doorRight.GetComponent<Door>()._isOpen = false;

        _doorTop.GetComponent<Door>()._dir = Door.dir.top;
        _doorBot.GetComponent<Door>()._dir = Door.dir.bot;
        _doorLeft.GetComponent<Door>()._dir = Door.dir.left;
        _doorRight.GetComponent<Door>()._dir = Door.dir.right;

        _initEvent.Invoke();
    }

    void LateUpdate(){
        CheckClear();
    }

    public void CloseRoom(){
        foreach (GameObject enemy in _enemies)
        {
            enemy.SetActive(false);
        }
    }

    public void ClearEvent(){
        clear = true;
        this.gameObject.GetComponent<CurseRoom>().Uncurse();
        OpenDoors();
        _clearEvent.Invoke();
    }
    public void OpenDoors(){
        _doorTop.GetComponent<Door>().Open();
        _doorBot.GetComponent<Door>().Open();
        _doorRight.GetComponent<Door>().Open();
        _doorLeft.GetComponent<Door>().Open();
    }

    public void SetDoors(bool up, bool down, bool right, bool left, Room nextUp, Room nextDown, Room nextRight,Room nextLeft ){

        canDown = down;
        canUp = up;
        canLeft = left;
        canRight = right;

        if(up){
            _doorTop.SetActive(true);
            _doorTop.GetComponent<Door>().Close();
            _doorTop.GetComponent<Door>()._nextRoom = nextUp;
        }
        else{
            _doorTop.SetActive(false);
        }
        if(down){
            _doorBot.SetActive(true);
            _doorBot.GetComponent<Door>().Close();
            _doorBot.GetComponent<Door>()._nextRoom = nextDown;
        }
        else{
            _doorBot.SetActive(false);
        }
        if(right){
            _doorRight.SetActive(true);
            _doorRight.GetComponent<Door>().Close();
            _doorRight.GetComponent<Door>()._nextRoom = nextRight;
        }
        else{
            _doorRight.SetActive(false);
        }
        if(left){
            _doorLeft.SetActive(true);
            _doorLeft.GetComponent<Door>().Close();
            _doorLeft.GetComponent<Door>()._nextRoom = nextLeft;
        }
        else{
            _doorLeft.SetActive(false);
        }
    }

    public void SetDoors()
    {
        if(canUp){
            _doorTop.SetActive(true);
            _doorTop.GetComponent<Door>().Close();
        }
        else{
            _doorTop.SetActive(false);
        }
        if(canDown){
            _doorBot.SetActive(true);
            _doorBot.GetComponent<Door>().Close();
        }
        else{
            _doorBot.SetActive(false);
        }
        if(canRight){
            _doorRight.SetActive(true);
            _doorRight.GetComponent<Door>().Close();
        }
        else{
            _doorRight.SetActive(false);
        }
        if(canLeft){
            _doorLeft.SetActive(true);
            _doorLeft.GetComponent<Door>().Close();
        }
        else{
            _doorLeft.SetActive(false);
        }
    }

    public void CheckClear()
    {
        if(!started){
            return;
        }
        bool succes = true;

        foreach (GameObject enemy in _enemies)
        {
            if(enemy.GetComponent<HealthSystem>()._isAlive){
                succes = false;
                return;
            }
        }

        if(succes){
            ClearEvent();
        }
    }

    
}
