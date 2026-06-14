using UnityEngine;

public class XPOrb : MonoBehaviour
{
    public float xpValue = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerExperience xp =
                other.GetComponent<PlayerExperience>();

            if (xp != null)
            {
                xp.AddXP(xpValue);
            }

            Destroy(gameObject);
        }
    }
}