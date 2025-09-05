using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;
    public PlayerController playerController;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Check the parent WeakPoint's EnemyController instead of the child's
            EnemyController parentEC = transform.parent.GetComponent<EnemyController>();
            if (parentEC != null && parentEC.isFainted) return;
            //if (GetComponent<EnemyController>().isFainted) return;
            playerController.KBCounter = playerController.KBTotalTime;
            if(collision.transform.position.x <= transform.position.x)
            {
                playerController.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                playerController.KnockFromRight = false;
            }
            playerHealth.TakeDamage(damage);
        }
    }
}
