using UnityEngine;
using UnityEngine.AI;


public class CharacterAnimator : MonoBehaviour
{
    Animator m_Animator;
    NavMeshAgent m_Agent;
    const float m_LocomotionAnimSmoothTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedPercent = m_Agent.velocity.magnitude / m_Agent.speed;
        m_Animator.SetFloat("SpeedPercent", speedPercent, m_LocomotionAnimSmoothTime, Time.deltaTime);
    }
}
