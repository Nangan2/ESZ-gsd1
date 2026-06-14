using System.Collections.Generic;
using UnityEngine;

public class AugmentSelectionManager : MonoBehaviour
{
    public List<AugmentData> allAugments;

    private int selectionsRemaining;

    private PlayerAugmentManager augmentManager;

    public GameObject panel;

    public AugmentCardUI card1;
    public AugmentCardUI card2;
    public AugmentCardUI card3;

    private void Awake()
    {
        augmentManager =
            FindFirstObjectByType<PlayerAugmentManager>();
    }

    public void BeginSelection(int amount)
    {
        selectionsRemaining = amount;

        Time.timeScale = 0f;

        ShowChoices();
    }

    void ShowChoices()
    {
        panel.SetActive(true);

        List<AugmentData> choices =
            GetRandomChoices(3);

        card1.Setup(choices[0]);
        card2.Setup(choices[1]);
        card3.Setup(choices[2]);
    }

    public void SelectAugment(AugmentData augment)
    {
        augmentManager.ApplyAugment(augment);

        selectionsRemaining--;

        if (selectionsRemaining > 0)
        {
            ShowChoices();
        }
        else
        {
            FinishSelection();
        }
    }

    public void SelectCard1()
    {
        SelectAugment(card1.GetAugment());
    }

    public void SelectCard2()
    {
        SelectAugment(card2.GetAugment());
    }

    public void SelectCard3()
    {
        SelectAugment(card3.GetAugment());
    }

    void FinishSelection()
    {
        panel.SetActive(false);

        Time.timeScale = 1f;

        Debug.Log("선택 완료");
    }

    List<AugmentData> GetRandomChoices(int count)
    {
        List<AugmentData> pool =
            new List<AugmentData>(allAugments);

        List<AugmentData> result =
            new List<AugmentData>();

        for (int i = 0; i < count && pool.Count > 0; i++)
        {
            int randomIndex =
                Random.Range(0, pool.Count);

            result.Add(pool[randomIndex]);

            pool.RemoveAt(randomIndex);
        }

        return result;
    }
}