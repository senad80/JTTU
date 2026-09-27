using UnityEngine;
using Pathfinding;

public class EnemyAI : Targeting
{
    public CharacterMotor motor;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float waypointDistance = 0.2f;

    private Seeker seeker;
    private Path path;
    private int waypointIndex;

    public float turnSpeed;

    public bool canMove;

    Vector2 direction;

    private void Awake()
    {
        seeker = GetComponent<Seeker>();
    }

    private void Start()
    {
        InvokeRepeating("UpdatePath", 0, 0.5f);
        FindPath();
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        FindPath();
    }

    private void Update()
    {
        if (target == null || path == null || path.error)
            return;

        if (waypointIndex >= path.vectorPath.Count)
            return;

        Vector2 position = transform.position;
        Vector2 waypoint = path.vectorPath[waypointIndex];

        direction = Vector2.Lerp(direction,(waypoint - position).normalized,turnSpeed*Time.deltaTime);

        Vector3 dir = (target.position - transform.position).normalized;

        float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (canMove)
        transform.localRotation = Quaternion.Euler(0f, 0f, z);

        if (canMove)
        motor.Move(direction, speed);

        if (Vector2.Distance(position, waypoint) < waypointDistance)
        {
            waypointIndex++;
        }
    }

    void OnDisable()
    {
        motor.Move(Vector3.zero, 0f);
    }

    private void FindPath()
    {
        if (!target)
            return;

        seeker.StartPath(
            transform.position,
            target.position,
            OnPathComplete
        );
    }

    private void OnPathComplete(Path newPath)
    {
        if (newPath.error)
            return;

        path = newPath;
        waypointIndex = 0;
    }
}
