using UnityEngine;
using UnityEngine.U2D;

public class MonsterMovementAlt : MonoBehaviour
{
    public float speed;

    private SpriteRenderer spriteRenderer;
    public Transform playerTransform;
    private Animator anim;

    public bool isChasing;
    public float chaseDistance;

    public bool isFainted;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        anim = spriteRenderer.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFainted || anim == null) return;
        if (playerTransform != null)
        {
            if (isChasing && Vector2.Distance(transform.position, playerTransform.position)
                < chaseDistance)
            {
                anim.SetBool("isChasing", true);
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
            else if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                anim.SetBool("isChasing", true);
                isChasing = true;
            }
            else if (Vector2.Distance(transform.position, playerTransform.position) > chaseDistance)
            {
                anim.SetBool("isChasing", false);
                isChasing = false;
            }
            //if (anim.GetBool("isChasing"))
            //    Debug.Log("Animator thinks enemy is chasing");
            //else
            //    Debug.Log("Animator thinks enemy is idle");

        }
    }

    public void Defeat()
    {
        isFainted = true;
        anim.SetTrigger("beaten");
        GetComponent<Collider2D>().enabled = false;
        Debug.Log("Enemy deafeated");
        GetComponent<MonsterDamage>().enabled = false;
    }

    public void Faint()
    {
        Destroy(gameObject);
    }
}
