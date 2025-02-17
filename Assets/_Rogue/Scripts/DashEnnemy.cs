using UnityEngine;
using System.Collections;

public class DashEnnemy : MonoBehaviour
{
    public float dashSpeed = 20f;       // Vitesse du dash
    public float dashDuration = 0.2f;   // Durée du dash
    private Rigidbody2D rb;
    private Vector2 dashDirection;
    public float interval = 5f;

    public EnemyAI _enemyAi;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(PerformDash());
    }

    IEnumerator PerformDash()
    {
        while (true) // Boucle infinie
        {
            yield return new WaitForSeconds(interval);

            dashDirection = GameManager._gameManager._player.transform.position - transform.position;
            float startTime = Time.time;
            _enemyAi.enabled = false;

            while (Time.time < startTime + dashDuration)
            {
                rb.linearVelocity = dashDirection * dashSpeed;
                yield return null;
            }

            rb.linearVelocity = Vector2.zero;
            _enemyAi.enabled = true;
        }
        
    }
}
