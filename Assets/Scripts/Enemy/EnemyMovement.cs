using UnityEngine;
using UnityEngine.AI;

using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;

public class EnemyMovement : BaseMonoBehaviour
{
    public NavMeshAgent agent;
    public float scanRadius = 5f;
    public bool isRunning = true;

    public bool showPath;

    private Vector3 origin;
    private Vector3 target;
    private bool foundEnemy = false;

    [SerializeField]
    private BehaviorTree _tree;

    private void Awake()
    {
        origin = transform.position;

        _tree = new BehaviorTreeBuilder(gameObject)
            .Selector()
                .Sequence("Attack")
                    .Condition(() => foundEnemy)
                    .Do("Moving To Player", () => {
                        agent.SetDestination(target);
                        return TaskStatus.Success;
                    })
                    .Do("Attack To Player", () => {
                        return TaskStatus.Success;
                    })
                .End()
                .Do("Return To Origin", () => {
                    agent.SetDestination(origin);
                    return TaskStatus.Success;
                })
            .End()
            .Build();
    }

    private void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public override void DoUpdate()
    {
        if (!isRunning)
            return;
        _tree.Tick();
    }

    private void FixedUpdate()
    {
        if (!isRunning)
            return;

        Collider2D collision = Physics2D.OverlapCircle(transform.position, scanRadius, LayerMask.GetMask("Player"));
        if (collision)
        {
            foundEnemy = true;
            target = collision.transform.position;
        }
        else
        {
            foundEnemy = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }



    public static void DebugDrawPath(Vector3[] corners)
    {
        if (corners.Length < 2) { return; }
        int i = 0;
        for (; i < corners.Length - 1; i++)
        {
            Debug.DrawLine(corners[i], corners[i + 1], Color.blue);
        }
        Debug.DrawLine(corners[0], corners[1], Color.red);
    }

    private void OnDrawGizmos()
    {
        DrawGizmos(agent, showPath);
    }

    public static void DrawGizmos(NavMeshAgent agent, bool showPath)
    {
        if (Application.isPlaying)
        {
            if (showPath && agent.hasPath)
            {
                var corners = agent.path.corners;
                if (corners.Length < 2) { return; }
                int i = 0;
                for (; i < corners.Length - 1; i++)
                {
                    Debug.DrawLine(corners[i], corners[i + 1], Color.blue);
                    Gizmos.color = Color.blue;
                    Gizmos.DrawSphere(agent.path.corners[i + 1], 0.03f);
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(agent.path.corners[i], agent.path.corners[i + 1]);
                }
                Debug.DrawLine(corners[0], corners[1], Color.blue);
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(agent.path.corners[1], 0.03f);
                Gizmos.color = Color.red;
                Gizmos.DrawLine(agent.path.corners[0], agent.path.corners[1]);
            }
        }
    }
}
