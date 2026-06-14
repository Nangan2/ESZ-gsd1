using UnityEngine;

[CreateAssetMenu(menuName = "Augments/Augment")]
public class AugmentData : ScriptableObject
{
    public string augmentName;
    public string description;

    public AugmentType type;

    public float value;
}