using TMPro;
using UnityEngine;

public class AugmentCardUI : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text descriptionText;

    private AugmentData augment;

    public void Setup(AugmentData data)
    {
        augment = data;

        nameText.text = data.augmentName;
        descriptionText.text = data.description;
    }

    public AugmentData GetAugment()
    {
        return augment;
    }
}