using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    public float HeroDetectRadius = 2f;
    public float StopDistance = 0.2f;
    public Transform Target;
    public float MoveSpeed = 2f;

    private Vector2 _destination;
    [SerializeField] private Rigidbody2D _rigidbody;

    private void OnValidate()
    {
        if (_rigidbody == null)
            _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(Target.position, _rigidbody.position);
        if (distance <= HeroDetectRadius && distance >= StopDistance)
        {
            Move();
        }
    }

    private void Move()
    {
        _destination.x = Target.position.x - _rigidbody.position.x;
        _destination.y = Target.position.y - _rigidbody.position.y;
        // _rigidbody.MovePosition(_rigidbody.position + _destination * MoveSpeed * Time.fixedDeltaTime);
        _rigidbody.MovePosition(new Vector2(10f, 10f));
        Debug.Log(_destination);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_rigidbody.position, HeroDetectRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_rigidbody.position, StopDistance);
    }
}
