using UnityEngine;

public class ShowCurse : MonoBehaviour
{
    public GameObject _curse;

    public bool isPaused = false;
    public OpenMaps _openMaps;

    void OnCurses()
    {
        if(_openMaps.isPaused){
            return;
        }
        
        ToggleCurse();
    }

    void ToggleCurse()
    {
        isPaused = !isPaused;
        _curse.SetActive(isPaused);

        Time.timeScale = isPaused ? 0f : 1f; // Met le jeu en pause ou le reprend
    }
}
