using UnityEngine;

public class CherryCollectible : MonoBehaviour
{
    public int heal;
    public PlayerHealth playerHealth;
    public PlayerController playerController;
    public Animator anim;


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && playerHealth.health < playerHealth.maxHealth)
        {
            Debug.Log("Cherry trigger entered");
            Heal(heal);
            Debug.Log("Collected Triggered");
            anim.SetTrigger("collect");
        //    Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Heal(int heal)
    {
        //playerHealth.health += heal;
        playerHealth.health = Mathf.Min(playerHealth.health + heal, playerHealth.maxHealth);
        playerHealth.UpdateDisplay();
        if(playerHealth.health >= playerHealth.maxHealth)
        {
            playerHealth.health = playerHealth.maxHealth;
            Debug.Log("Full Health");
        }
    }

    public void DestroyCherry()
    {
        Destroy(gameObject);
    }

}
