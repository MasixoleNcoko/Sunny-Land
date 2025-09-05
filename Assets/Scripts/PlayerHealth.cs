using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;

    public TextMeshProUGUI healthCount;
    public GameManager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateDisplay();
        if (health <= 0)
        {
            manager.Fallen();
        //    Destroy(gameObject);
            Debug.Log("You are Die");
        }
    }

    public void UpdateDisplay()
    {
        if(healthCount != null)
        {
            healthCount.text = $"Health: {health}";
        }
    }

}
