using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    [SerializeField] Transform target; // Asignar en el inspector el objetivo al que debe moverse
    private NavMeshAgent agent;
    [SerializeField] Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (target != null)
            agent.SetDestination(target.position);
        anim.SetFloat("Speed",agent.velocity.magnitude);
    }
}
