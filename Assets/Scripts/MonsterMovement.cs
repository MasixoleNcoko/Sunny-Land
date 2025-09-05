using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    public int patrolDestination;
    private SpriteRenderer spriteRenderer;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            if (isChasing)
            {
                if (transform.position.x > playerTransform.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    transform.position += Vector3.left * speed * Time.deltaTime;
                }
                if (transform.position.x < playerTransform.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    transform.position += Vector3.right * speed * Time.deltaTime;
                }
            }
            else
            {
                if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
                {
                    isChasing = true;
                }

                if (patrolDestination == 0)
                {
                    transform.position = Vector2.MoveTowards(transform.position,
                        patrolPoints[0].position, speed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                    {
                        spriteRenderer.flipX = false;
                        patrolDestination = 1;
                    }
                }

                if (patrolDestination == 1)
                {
                    transform.position = Vector2.MoveTowards(transform.position,
                        patrolPoints[1].position, speed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                    {
                        spriteRenderer.flipX = true;
                        patrolDestination = 0;
                    }
                }
            }
        }

    }
}
