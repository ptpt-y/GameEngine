using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;

    public bool isPickUp = false;
    public bool eatJump = false;
    public bool eatJump2 = false;
    public bool eatJump3 = false;

    public Vector3 predis;
    public Vector3 curdis;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(target != null)
        {
            agent.SetDestination(target.position);
            // arrive or not --> set bool for pick up animation 
            curdis = target.position - transform.position;
            float temp = curdis.x * curdis.x + curdis.z * curdis.z;
            float temp2 = agent.stoppingDistance * agent.stoppingDistance;
            if (curdis == predis && temp < temp2)
            {
                // Debug.Log("arrive!");
                isPickUp = true;
            }
            predis = curdis;

            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * .8f;
        agent.updateRotation = false;
        // isPickUp = true;
        
        target = newTarget.interactionTransform;
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        // isPickUp = false;

        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
