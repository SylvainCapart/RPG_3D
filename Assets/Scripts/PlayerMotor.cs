using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent m_Agent;
    Transform m_Target;

    // Start is called before the first frame update
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (m_Target != null)
        {
            m_Agent.SetDestination(m_Target.position);
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        m_Agent.SetDestination(point);
    }

    public void FollowTarget(Interactable _newTarget)
    {
        m_Agent.stoppingDistance = _newTarget.m_Radius * 0.8f;
        m_Agent.updateRotation = true;
        m_Target = _newTarget.transform;

    }

    public void StopFollowingTarget()
    {
        m_Agent.stoppingDistance = 0f;
        m_Agent.updateRotation = false;
        m_Target = null;
    }


    private void FaceTarget()
    {
        Vector3 direction = (m_Target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }
}
