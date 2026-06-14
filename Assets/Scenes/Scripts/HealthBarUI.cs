using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Image fillImage;
    public PlayerStats playerStats;

    void Update()
    {
        fillImage.fillAmount =
            (float)playerStats.currentHealth /
            playerStats.maxHealth;
    }
}