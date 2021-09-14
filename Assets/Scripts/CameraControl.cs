using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float DampTime = 0.3f;
    public float MaxDistance = 7.5f;

    public Transform CurrsorTransform;
    public Transform PlayerTransform;

    private Vector3 _moveVelocity;
    private Vector3 _desiredPosition;


    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        FindAveragePosition();
        transform.position = Vector3.SmoothDamp(transform.position, _desiredPosition, ref _moveVelocity, DampTime);
    }

    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();

        averagePos += PlayerTransform.position + CurrsorTransform.position;
        averagePos /= 2;

        float distance = Vector3.Distance(PlayerTransform.position, CurrsorTransform.position);

        if (distance > MaxDistance)
        {
            Vector3 ab = CurrsorTransform.position - PlayerTransform.position;
            ab.Normalize();

            _desiredPosition = PlayerTransform.position + (MaxDistance / 2 * ab);
            _desiredPosition.z = transform.position.z;
            return;
        } 

        _desiredPosition = averagePos;
    }
}