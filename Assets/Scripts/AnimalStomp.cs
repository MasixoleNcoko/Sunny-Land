using UnityEngine;

public class AnimalStomp : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weak Point"))
        {
            
            collision.GetComponent<EnemyController>().Defeat();
            playerController.KBCounter = 0f;
        }
    }

}
