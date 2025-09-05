using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public Animator anim;
    public float speed;
    public float input;
    public float jumpForce;
    public SpriteRenderer spriteRenderer;

    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;

    public float jumpTime = 0.3f;
    public float jumpTimeCounter;
    private bool isJumping;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;
    private bool isKnockedBack;

    public int gemCount = 0;
    public int gemCountMax = 5;
    public TextMeshProUGUI gemNumber;

    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isKnockedBack)
        {
            input = Input.GetAxisRaw("Horizontal");
            anim.SetFloat("horizontal", Mathf.Abs(input));

            // Flips player
            if (input < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (input > 0)
            {
                spriteRenderer.flipX = false;
            }

            isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

            if (isGrounded == true && Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                playerRb.linearVelocity = Vector2.up * jumpForce;
            }

            if (Input.GetButton("Jump") && isJumping == true)
            {
                if (jumpTimeCounter > 0)
                {
                    playerRb.linearVelocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }

            if (Input.GetButtonUp("Jump"))
            {
                isJumping = false;
            }

            if (isGrounded)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", false);
            }
            else
            {
                if (isGrounded == false & playerRb.linearVelocity.y > 0)
                {
                    anim.SetBool("jumping", true);
                    anim.SetBool("falling", false);
                //    Debug.Log("jumping up");
                }
                else if (isGrounded == false & playerRb.linearVelocity.y < 0)
                {
                    anim.SetBool("jumping", false);
                    anim.SetBool("falling", true);
                //    Debug.Log("falling down");
                }
            }

            if (isGrounded == true & Input.GetKeyDown(KeyCode.S))
            {
                anim.SetBool("crouch", true);
                Debug.Log("crouching");
            }
            if (isGrounded == true & Input.GetKeyUp(KeyCode.S))
            {
                anim.SetBool("crouch", false);
            }
        }
    }

    private void FixedUpdate()
    {
        if ( KBCounter <= 0)
        {
            playerRb.linearVelocity = new Vector2(input * speed, playerRb.linearVelocity.y);
            anim.SetBool("hurt", false);
        }
        else
        {
            if( KnockFromRight == true)
            {
                isKnockedBack = true;
                playerRb.linearVelocity = new Vector2(-KBForce, KBForce);
                anim.SetBool("hurt", true);
                anim.SetBool("jumping", false);
                anim.SetBool("falling", false);
                anim.SetBool("crouch", false);
                Debug.Log("hit");
            }
            if(KnockFromRight == false)
            {
                isKnockedBack = true;
                playerRb.linearVelocity = new Vector2(KBForce, KBForce);
                anim.SetBool("hurt", true);
                anim.SetBool("jumping", false);
                anim.SetBool("falling", false);
                anim.SetBool("crouch", false);
                Debug.Log("hit");
            }
            KBCounter -= Time.deltaTime;
            if( KBCounter <= 0 )
            {
                isKnockedBack = false;
            }
        } 
    }

    // Gem Collection
    private void UpdateDisplay()
    {
        if (gemNumber != null)
        {
            gemNumber.text = $"Gems: {gemCount}";
        }
    }

    private void UpdateWinDisplay()
    {
        if (gemNumber != null)
        {
            gemNumber.text = "You Win!";
        }
    }

    public void AddGem(int amount)
    {
        if (gemCount < gemCountMax)
        {
            gemCount += amount;
            UpdateDisplay();
            Debug.Log("Gem Collected");
        }
        else if (gemCount >= gemCountMax)
        {
            UpdateWinDisplay();
            Debug.Log("You Win!");
            gameManager.Victory();
        }
    }

}
