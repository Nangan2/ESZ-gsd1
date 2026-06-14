using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("something touched me!! : " + other.name);

        if (other.CompareTag("Player"))
        {
            //Debug.Log("player!");

            SceneManager.LoadScene("EndingScene");
        }
    }
}