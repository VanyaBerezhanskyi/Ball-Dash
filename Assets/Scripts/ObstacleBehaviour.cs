using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehaviour>())
        {
            GameManager gameManager = FindAnyObjectByType<GameManager>();
            AudioSource musicSource = FindAnyObjectByType<AudioSource>();

            Destroy(collision.gameObject);

            musicSource.Stop();

            StartCoroutine(gameManager.ResetGame());
        }
    }
}
