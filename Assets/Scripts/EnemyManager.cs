using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform target;
    private float speed = 5f;//移動速度
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private float chaseDistance = 10f;//追跡開始距離
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMeshAgent.speed = speed;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget <= chaseDistance)
        {
            navMeshAgent.SetDestination(target.position);
            animator.SetBool("Found", true);
        } else
        {
            animator.SetBool("Found", false);
        }
    }
}
