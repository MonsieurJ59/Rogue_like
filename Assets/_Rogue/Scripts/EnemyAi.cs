using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Transform player;
    public float speed = 3f;
    public float turnSpeed = 5f;
    public float raycastDistance = 1.5f;
    public float avoidanceTime = 0.5f;
    public LayerMask obstacleLayer;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isAvoiding = false;
    private Vector2 avoidanceDirection = Vector2.zero;

    // Bool pour savoir si l'ennemi est en collision avec le joueur
    public bool isCollidingWithPlayer = false;

    void Start()
    {
        player = GameManager._gameManager._player.transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isCollidingWithPlayer) // Ne pas bouger si en collision avec le joueur
        {
            Vector2 targetDirection = (player.position - transform.position).normalized;

            if (!isAvoiding)
            {
                DetectObstacles();
            }

            if (avoidanceDirection != Vector2.zero)
            {
                moveDirection = Vector2.Lerp(moveDirection, avoidanceDirection.normalized, Time.deltaTime * turnSpeed);
            }
            else
            {
                moveDirection = Vector2.Lerp(moveDirection, targetDirection.normalized, Time.deltaTime * turnSpeed);
            }
        }
    }

    void FixedUpdate()
    {
        if (!isCollidingWithPlayer) // Appliquer la vitesse uniquement si on n'est pas en collision
        {
            rb.linearVelocity = moveDirection * speed;
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            rb.rotation = Mathf.LerpAngle(rb.rotation, angle, Time.deltaTime * turnSpeed);
        }
    }

    private void DetectObstacles()
    {
        Vector2 forwardDirection = moveDirection;
        Vector2 leftParallel = Quaternion.Euler(0, 0, 90) * forwardDirection;
        Vector2 rightParallel = Quaternion.Euler(0, 0, -90) * forwardDirection;

        Vector2 offsetLeft = transform.position + (Vector3)(leftParallel * 0.5f);
        Vector2 offsetRight = transform.position + (Vector3)(rightParallel * 0.5f);

        RaycastHit2D hitForwardLeft = Physics2D.Raycast(offsetLeft, forwardDirection, raycastDistance, obstacleLayer);
        RaycastHit2D hitForwardRight = Physics2D.Raycast(offsetRight, forwardDirection, raycastDistance, obstacleLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, leftParallel, raycastDistance, obstacleLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, rightParallel, raycastDistance, obstacleLayer);

        Debug.DrawRay(offsetLeft, moveDirection * raycastDistance, Color.red);
        Debug.DrawRay(offsetRight, moveDirection * raycastDistance, Color.red);

        if (hitForwardLeft.collider != null || hitForwardRight.collider != null)
        {
            if (hitLeft.collider == null)
            {
                StartCoroutine(AvoidObstacle(leftParallel));
            }
            else if (hitRight.collider == null)
            {
                StartCoroutine(AvoidObstacle(rightParallel));
            }
            else
            {
                StartCoroutine(AvoidObstacle(-forwardDirection));
            }
        }
    }

    private IEnumerator AvoidObstacle(Vector2 avoidanceDir)
    {
        isAvoiding = true;
        avoidanceDirection = avoidanceDir;
        yield return new WaitForSeconds(avoidanceTime);
        isAvoiding = false;
        avoidanceDirection = Vector2.zero;
    }

    // Cette méthode est appelée lors de la collision avec un autre objet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Vérifie si l'objet avec lequel on entre en collision est le joueur
        if (collision.collider.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
        }
    }

    // Cette méthode est appelée lorsque la collision avec un objet prend fin
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Vérifie si on a quitté la collision avec le joueur
        if (collision.collider.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
        }
    }
}
