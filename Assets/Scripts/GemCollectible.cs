using TMPro;
using UnityEngine;

public class GemCollectible : MonoBehaviour
{
    public int value = 1;
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.AddGem(value);
                anim.SetTrigger("collected");
            }
            
        //    Destroy(gameObject);
            Debug.Log("Gem Collected");
        }
    }

    public void DestroyGem()
    {
        Destroy(gameObject);
    }

}
