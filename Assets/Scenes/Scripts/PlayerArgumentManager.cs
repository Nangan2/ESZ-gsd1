using UnityEngine;

public class PlayerAugmentManager : MonoBehaviour
{
    private PlayerStats stats;

    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
    }

    public void ApplyAugment(AugmentData augment)
    {
        switch (augment.type)
        {
            case AugmentType.Damage:
                stats.damage += (int)augment.value;
                break;

            case AugmentType.AttackSpeed:
                stats.attackSpeed += augment.value;
                break;

            case AugmentType.ProjectileCount:
                stats.projectileCount += (int)augment.value;
                break;

            case AugmentType.BulletSpeed:
                stats.bulletSpeed += augment.value;
                break;

            case AugmentType.BulletLifetime:
                stats.bulletLifeTime += augment.value;
                break;

            case AugmentType.MaxHealth:
                stats.maxHealth += (int)augment.value;
                stats.currentHealth += (int)augment.value;
                break;
        }
    }
}