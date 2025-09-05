using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator anim;
    public bool isFainted;

    private void Awake()
    {
        //if (anim == null)
        //{
        //    anim = GetComponentInChildren<Animator>();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Defeat()
    {
        isFainted = true;
        if (anim != null)
        {
            anim.SetTrigger("beaten");
        }
        else
        {
            Debug.LogWarning("No Animator found on enemy!");
        }
            GetComponent<Collider2D>().enabled = false;
        Debug.Log("Enemy deafeated");
        GetComponent<MonsterDamage>().enabled = false;
    }

    public void Faint()
    {
        Destroy(gameObject);
    }

}
