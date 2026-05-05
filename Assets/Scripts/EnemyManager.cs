using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] EnemyStatusSO enemyStatusSO;
    [SerializeField] PlayerStatusSO PlayerStatusSO;
    public Transform target;
    private float speed = 5f;//移動速度
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private float chaseDistance = 10f;//追跡開始距離
    private Animator animator;
    private int currentHP;
    private int damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMeshAgent.speed = speed;
        animator = GetComponent<Animator>();
        currentHP = enemyStatusSO.enemyStatusList[0].HP;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentHP);
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget <= chaseDistance)
        {
            navMeshAgent.SetDestination(target.position);
            animator.SetBool("Found", true);
        } else
        {
            animator.SetBool("Found", false);
        }

        //死亡判定
        if (currentHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Weapon")
        {
            Debug.Log("当たった");
            damage = (int)(PlayerStatusSO.ATTACK / 2 - enemyStatusSO.enemyStatusList[0].DEFENSE / 4);
            if (damage > 0)
            {
               currentHP = currentHP - damage;
            }
        }
        
    }
}

