using UnityEngine;
using UnityEngine.AI;

public class Enemie : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent navMeshAgent;

    [SerializeField] private int live = 2;

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

    public void Damage()
    {
        live -= 1;

        if (live <= 0)
        {
            Destroy(gameObject);
            BuildManager.instance.MetralhadoraIncrementReward();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("shoot"))
        {
            Damage();
        }
    }
}
