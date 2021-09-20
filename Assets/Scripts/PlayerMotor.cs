using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        if (target != null)
        {
            // TODO - use a coroutine, so we're not doing this every frame
            agent.SetDestination(target.position);
			FaceTarget();
	    }
    }


    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }


    public void FollowTarget(Interactable newTarget)
    {
        // Stop a little inside the target's radius
        agent.stoppingDistance = newTarget.radius * 0.8f;

        target = newTarget.interactionTransform;

        // When focused, we'll handle rotation ourself
        agent.updateRotation = false;
    }


    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0;
        agent.updateRotation = true;
        target = null;
    }


    private void FaceTarget()
    {
        // Get the direction we should be facing
        Vector3 direction = (target.position - transform.position).normalized;

        // Convert it to a rotation
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));

        // Smoothly change the rotation to the desired rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        // transform.rotation = lookRotation;
    }
}
