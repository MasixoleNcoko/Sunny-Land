using System.Collections;
using UnityEngine;

public class PlatformDrop : MonoBehaviour
{
    public float fallTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(FallTimer());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player") && 
            collision.contacts[0].normal.y < transform.position.y)
        {
            StartCoroutine (FallTimer());
        }
    }

    // Coroutine
    IEnumerator FallTimer()
    {
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(fallTime);
        GetComponent<Collider2D>().enabled = true;
    }
}
