using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float dodgeSpeed = 5;
    public float rollSpeed = 5;

    public enum MobileHorizMovement
    {
        Accelerometer,
        ScreenTouch
    }

    public MobileHorizMovement horizMovement = MobileHorizMovement.Accelerometer;

    private Rigidbody _rb;
    private float _horizontalSpeed = 0.0f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        switch (horizMovement)
        {
            case MobileHorizMovement.Accelerometer:
                _horizontalSpeed = Input.acceleration.x * dodgeSpeed;
                break;

            case MobileHorizMovement.ScreenTouch:
                if (Input.GetMouseButton(0))
                {
                    Camera cam = Camera.main;

                    Vector3 screenPos = Input.mousePosition;
                    Vector3 viewPos = cam.ScreenToViewportPoint(screenPos);
                    float xMove = 0;

                    if (viewPos.x < 0.5f)
                    {
                        xMove = -1;
                    }
                    else
                    {
                        xMove = 1;
                    }

                    _horizontalSpeed = xMove * dodgeSpeed;
                }
                else
                {
                    _horizontalSpeed = 0.0f;
                }
                break;
        }

        _rb.linearVelocity = new Vector3(_horizontalSpeed, 0, rollSpeed);
    }
}
