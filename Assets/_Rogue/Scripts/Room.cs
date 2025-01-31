using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room : MonoBehaviour
{
    public bool clear;
    public List<GameObject> _enemies;
    public UnityEvent _initEvent;
    public UnityEvent _clearEvent;

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

        _initEvent.Invoke();
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
