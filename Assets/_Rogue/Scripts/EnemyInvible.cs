using UnityEngine;
using System.Collections;

public class EnemyInvible : MonoBehaviour
{
    public float disappearTime = 5f;  // Temps pendant lequel l'ennemi disparaît
    public float interval = 2f;       // Intervalle entre les disparitions

    private Renderer enemyRenderer;   // Pour activer/désactiver l'affichage
    public GameObject myUI;

    void Start()
    {
        Init();
    }

    public void Init()
    {
        enemyRenderer = GetComponent<Renderer>();
        enemyRenderer.enabled = true;              // Réactiver l'ennemi
        myUI.SetActive(true);
        StartCoroutine(DisappearRoutine());
    }

    IEnumerator DisappearRoutine()
    {
        while (true) // Boucle infinie
        {
            yield return new WaitForSeconds(interval);  // Attendre 5 secondes
            enemyRenderer.enabled = false;             // Désactiver l'ennemi
            myUI.SetActive(false);
            yield return new WaitForSeconds(disappearTime); // Attendre 2 secondes
            enemyRenderer.enabled = true;              // Réactiver l'ennemi
            myUI.SetActive(true);
        }
    }

}
