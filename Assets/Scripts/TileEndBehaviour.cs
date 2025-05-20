using UnityEngine;

public class TileEndBehaviour : MonoBehaviour
{
    public float destroyTime = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerBehaviour>())
        {
            GameManager gameManager = FindAnyObjectByType<GameManager>();
            gameManager.SpawnNextTile();

            Destroy(transform.parent.gameObject, destroyTime);

            gameManager.currentScore++;

            Messenger.Broadcast(GameEvent.SCORE_UPDATED);
        }
    }
}
