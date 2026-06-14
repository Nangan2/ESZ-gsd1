using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    private PlayerStats stats;
    private Rigidbody2D rb;

    private bool isInvincible;
    public float invincibleTime = 0.5f;

    public bool IsKnockedBack { get; private set; }

    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible)
            return;

        stats.currentHealth -= damage;

        if (stats.currentHealth <= 0)
        {
            Die();
        }

        StartCoroutine(Invincibility());
    }

    private IEnumerator Invincibility()
    {
        isInvincible = true;

        yield return new WaitForSeconds(invincibleTime);

        isInvincible = false;
    }

    private void Die()
    {
        Debug.Log("게임 오버");

        // 나중에 게임오버 UI 추가
        Destroy(gameObject);
    }

    private IEnumerator KnockbackCoroutine(Vector2 direction)
    {
        IsKnockedBack = true;

        rb.linearVelocity = Vector2.zero;

        rb.AddForce(
            direction * knockbackForce,
            ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.2f);

        IsKnockedBack = false;
    }


    [SerializeField]
    private float knockbackForce = 8f;

    public void ApplyKnockback(Vector2 sourcePosition)
    {
        Vector2 direction =
            ((Vector2)transform.position - sourcePosition).normalized;

        StartCoroutine(KnockbackCoroutine(direction));
    }


}