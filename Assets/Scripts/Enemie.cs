using UnityEngine;
using UnityEngine.AI;

public class Enemie : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target)
        {
            navMeshAgent.destination = target.position;
        }
    }
}
