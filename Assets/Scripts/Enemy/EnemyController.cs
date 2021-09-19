using UnityEngine;
using UnityEngine.AI;

using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public float scanRadius = 5f;

    private Vector3 _origin;
    private Vector3 _target;
    private bool _foundEnemy = false;

    [SerializeField]
    private BehaviorTree _tree;

    private void Awake()
    {
        _origin = transform.position;

        _tree = new BehaviorTreeBuilder(gameObject)
            .Selector()
                .Sequence("Attack")
                    .Condition(() => _foundEnemy)
                    .Do("Moving To Player", () => {
                        agent.SetDestination(_target);
                        return TaskStatus.Success;
                    })
                    .Do("Attack To Player", () => {
                        return TaskStatus.Success;
                    })
                .End()
                .Do("Return To Origin", () => {
                    agent.SetDestination(_origin);
                    return TaskStatus.Success;
                })
            .End()
            .Build();
    }

    private void Update()
    {
        _tree.Tick();
    }

    private void FixedUpdate()
    {
        Collider2D collision = Physics2D.OverlapCircle(transform.position, scanRadius, LayerMask.GetMask("Player"));
        if (collision)
        {
            _foundEnemy = true;
            _target = collision.transform.position;
        }
        else
        {
            _foundEnemy = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }
}
