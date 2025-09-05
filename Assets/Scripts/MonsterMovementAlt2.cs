using UnityEngine;

public class MonsterMovementAlt2 : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    public int patrolDestination;
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
