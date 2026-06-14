using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    private PlayerStats stats;
    private Rigidbody2D rb;

    private bool isInvincible;
    public float invincibleTime = 0.5f;

    private Vector3 respawnPosition;
    public Transform respawnPoint;

    public bool IsKnockedBack { get; private set; }

    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();

        respawnPosition = transform.position;
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
        Respawn();
    }

    private void Respawn()
    {
        stats.currentHealth = stats.maxHealth;

        transform.position = respawnPoint.position;

        rb.linearVelocity = Vector2.zero;

        PlayerExperience xp = GetComponent<PlayerExperience>();

        FindFirstObjectByType<AugmentSelectionManager>().BeginSelection(xp.level);

        EnemyMovement[] enemies = FindObjectsByType<EnemyMovement>(
        FindObjectsSortMode.None);

        foreach (EnemyMovement enemy in enemies)
        {
            enemy.ResetEnemy();
        }
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
        Vector2 direction = ((Vector2)transform.position - sourcePosition).normalized;

        StartCoroutine(KnockbackCoroutine(direction));
    }
}