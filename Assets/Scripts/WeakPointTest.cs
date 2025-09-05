using UnityEngine;

public class WeakPointTest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("[WEAKPOINT] Triggered by: " + collision.name + " with tag: " + collision.tag);
    }
}
