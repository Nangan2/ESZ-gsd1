using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Combat")]
    public float attackSpeed = 4f;
    public float bulletSpeed = 10f;
    public int damage = 1;

    [Header("Projectile")]
    public int projectileCount = 1;
    public float projectileSpread = 15f;
    public float bulletLifeTime = 3f;

    [Header("Health")]
    public int maxHealth = 100;

    [HideInInspector]
    public int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
}