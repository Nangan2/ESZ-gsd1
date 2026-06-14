using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Transform firePoint;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        if (mousePos.x < transform.position.x)
        {
            spriteRenderer.flipX = true;

            Vector3 pos = firePoint.localPosition;
            pos.x = -Mathf.Abs(pos.x);
            firePoint.localPosition = pos;
        }
        else
        {
            spriteRenderer.flipX = false;

            Vector3 pos = firePoint.localPosition;
            pos.x = Mathf.Abs(pos.x);
            firePoint.localPosition = pos;
        }
    }
}