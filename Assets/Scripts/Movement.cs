using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform targetPosition;
    private NavMeshAgent navMeshAgent;
    public bool isWalking = false;
    public Text text;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        text.text = isWalking.ToString();
    }

    void Update()
    {
        if (isWalking)
        {
            navMeshAgent.destination = targetPosition.position;
            navMeshAgent.isStopped = false;
        } else
        {
            navMeshAgent.isStopped = true;
            //navMeshAgent.ResetPath();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isWalking = !isWalking;
            text.text = isWalking.ToString();
        }
    }
}
