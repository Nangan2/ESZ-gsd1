using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    public int level = 1;

    public float currentXP = 0;
    public float requiredXP = 10;

    public delegate void LevelUpAction();
    public event LevelUpAction OnLevelUp;

    public void AddXP(float amount)
    {
        currentXP += amount;

        while (currentXP >= requiredXP)
        {
            currentXP -= requiredXP;

            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;

        requiredXP *= 1.25f;

        Debug.Log("레벨업! 현재 레벨 : " + level);

        OnLevelUp?.Invoke();
    }
}