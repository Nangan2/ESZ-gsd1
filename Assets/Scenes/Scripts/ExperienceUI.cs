using UnityEngine;
using UnityEngine.UI;

public class ExperienceUI : MonoBehaviour
{
    public PlayerExperience experience;
    public Image fillImage;

    void Update()
    {
        fillImage.fillAmount =
            experience.currentXP /
            experience.requiredXP;
    }
}