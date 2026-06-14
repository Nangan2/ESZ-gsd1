using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;

    private int currentHealth;

    public GameObject xpOrbPrefab;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        //Debug.Log(currentHealth);
    }

    void Die()
    {
        Instantiate(
            xpOrbPrefab,
            transform.position,
            Quaternion.identity);

        Destroy(gameObject);
    }
}