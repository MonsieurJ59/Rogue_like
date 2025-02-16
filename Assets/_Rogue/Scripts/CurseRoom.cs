using UnityEngine;

public class CurseRoom : MonoBehaviour
{
    public int _nbCurse = 0;
    public CurseSystem.Curse _curse;

    void Start()
    {
        float random = Random.Range(0 , 100);
         switch(random){
            case <=20 :
                _curse = CurseSystem.Curse.BulletSpeed;
                break;
            case >20 and <=40 :
                _curse = CurseSystem.Curse.Cooldown;
                break;
            case >40 and <=60 :
                _curse = CurseSystem.Curse.Damage;
                break;
            case >60 and <=80 :
                _curse = CurseSystem.Curse.Health;
                break;
            case >80 and <=100 :
                _curse = CurseSystem.Curse.Speed;
                break;
        }
    }

    public void AddCurse(){
        _nbCurse ++;
        GameManager._gameManager._curseSystem.UpdateCurse();
    }

    public void Uncurse(){
        _nbCurse = 0;
        GameManager._gameManager._curseSystem.UpdateCurse();
    }

}
