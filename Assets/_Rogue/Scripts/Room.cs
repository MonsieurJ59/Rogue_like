using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room : MonoBehaviour
{
    public bool clear = false;
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
    }

    public void InitRoom()
    {
        foreach (GameObject enemy in _enemies)
        {
            // Active l'ennemi et initialise ses données
            enemy.SetActive(true);
            enemy.GetComponent<EnemyData>().InitEnemy();
        }

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
        _clearEvent.Invoke();
    }

    public void SetDoors(bool up, bool down, bool right, bool left){
        if(up){
            _doorTop.SetActive(true);
            _doorTop.GetComponent<Door>()._isOpen = false;
        }
        if(down){
            _doorBot.SetActive(true);
            _doorBot.GetComponent<Door>()._isOpen = false;
        }
        if(right){
            _doorRight.SetActive(true);
            _doorRight.GetComponent<Door>()._isOpen = false;
        }
        if(left){
            _doorLeft.SetActive(true);
            _doorLeft.GetComponent<Door>()._isOpen = false;
        }
    }

    public void CheckClear()
    {
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
