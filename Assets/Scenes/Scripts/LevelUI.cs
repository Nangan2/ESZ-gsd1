using UnityEngine;
using TMPro;

public class LevelUI : MonoBehaviour
{
    public PlayerExperience playerExperience;
    public TMP_Text levelText;

    void Update()
    {
        levelText.text =
            "Lv. " + playerExperience.level;
    }
}