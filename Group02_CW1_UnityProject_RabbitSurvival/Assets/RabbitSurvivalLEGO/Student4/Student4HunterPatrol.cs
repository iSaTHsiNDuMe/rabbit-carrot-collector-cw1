using UnityEngine;

public sealed class Student4HunterPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public Student3RabbitController rabbit;
    public Transform rabbitStart;
    public Student4CaveGoal caveGoal;
    public float speed = 1.65f;
    public float catchDistance = 1.15f;

    private int nextWaypoint;
    private CharacterController rabbitBody;

    private void Awake()
    {
        rabbitBody = rabbit.GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 target = waypoints[nextWaypoint].position;
        Vector3 heading = target - transform.position;
        heading.y = 0;
        if (heading.sqrMagnitude > 0.001f)
        {
            var facing = Quaternion.LookRotation(-heading);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, facing, 360f * Time.deltaTime);
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if ((transform.position - target).sqrMagnitude < 0.0025f)
            nextWaypoint = (nextWaypoint + 1) % waypoints.Length;
    }

    private void LateUpdate()
    {
        Vector3 eyes = transform.position + Vector3.up * 0.85f;
        Vector3 rabbitCenter = rabbitBody.bounds.center;
        if (rabbit.IsHidden || caveGoal.Won || (rabbitCenter - eyes).sqrMagnitude > catchDistance * catchDistance)
            return;

        if (Physics.Linecast(eyes, rabbitCenter, out RaycastHit hit, ~0, QueryTriggerInteraction.Ignore)
            && hit.collider != rabbitBody)
            return;

        rabbitBody.enabled = false;
        rabbit.transform.SetPositionAndRotation(rabbitStart.position, rabbitStart.rotation);
        rabbitBody.enabled = true;
        caveGoal.ShowCaught();
    }
}
