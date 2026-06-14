using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 15f;

    private Transform player;
    private Rigidbody2D rb;

    private bool isGrounded;

    public float jumpCooldown = 5f;

    private float nextJumpTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveToPlayer();
        TryJump();
    }

    void MoveToPlayer()
    {
        float direction =
            Mathf.Sign(player.position.x - transform.position.x);

        rb.linearVelocity =
            new Vector2(
                direction * moveSpeed,
                rb.linearVelocity.y);
    }

    void TryJump()
    {
        float heightDifference =
            player.position.y - transform.position.y;

        if (isGrounded &&
            heightDifference > 1f &&
            Time.time >= nextJumpTime)
        {
            rb.linearVelocity =
                new Vector2(
                    rb.linearVelocity.x,
                    jumpForce);

            nextJumpTime = Time.time + jumpCooldown;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}