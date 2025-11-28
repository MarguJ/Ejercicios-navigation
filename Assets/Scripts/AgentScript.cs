using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints; // puntos de patrulla
    [SerializeField] float pointReachedThreshold = 0.3f; // distancia minima para considerar que llego
    private int currentPointIndex = 0;
    private NavMeshAgent agent;
    private Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[currentPointIndex].position);
        }
    }

    void Update()
    {
        // Si hay puntos de patrulla
        if (patrolPoints.Length > 0)
        {
            // Ver si ya llegó al destino
            if (!agent.pathPending && agent.remainingDistance <= pointReachedThreshold)
            {
                // Cambiar al siguiente punto
                currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
                agent.SetDestination(patrolPoints[currentPointIndex].position);
            }
        }

        // Actualizar animación
        anim.SetFloat("Speed", agent.velocity.magnitude);
    }
}
