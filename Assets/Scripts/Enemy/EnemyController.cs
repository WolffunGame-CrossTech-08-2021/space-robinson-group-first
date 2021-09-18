using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    public float HeroDetectRadius = 2f;
    public float StopDistance = 0.2f;
    public Transform Target;
    public float MoveSpeed = 2f;

    private Vector2 _destination;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    private bool _facingRight = true;

    private void OnValidate()
    {
        if (_rigidbody == null)
            _rigidbody = GetComponent<Rigidbody2D>();
        if (_navMeshAgent == null)
            _navMeshAgent = GetComponent<NavMeshAgent>();
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
        _rigidbody.MovePosition(_rigidbody.position + _destination * MoveSpeed * Time.fixedDeltaTime);


        if (Target.position.x > transform.position.x && !_facingRight)
        {
            Flip();
        }
        else if (Target.position.x < transform.position.x && _facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        _facingRight = !_facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_rigidbody.position, HeroDetectRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_rigidbody.position, StopDistance);
    }
}
