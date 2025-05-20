using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private Transform target;

    public Vector3 offset = new Vector3(0, 3, -6);

    private void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;

            transform.LookAt(target);
        }
    }
}
