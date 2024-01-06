using System;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    public float detectionRange = 10f;
    public LayerMask targetLayer;

    private Transform target;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private int damage = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        FindTarget();
        if (target != null)
        {
            MoveToTarget();
        }

        if (damage == 10)
        {
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 触碰到植物或玩家时切换到攻击姿态
            animator.SetBool("Isplayer",true);
        }
        else if(other.CompareTag("Plant"))
        {
            animator.SetBool("Isplant",true);

        }
        if (other.CompareTag("Bullet"))
        {
            // 触碰到植物或玩家时切换到攻击姿态
            damage++;
        }
        
    }

    

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Plant") || other.CompareTag("Player"))
        {
            
            animator.SetBool("Isplayer",false);
            animator.SetBool("Isplant",false); 
        }
    }
    void FindTarget()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, detectionRange, targetLayer);
        
        if (targets.Length > 0)
        {
            target = targets[0].transform;
        }
        else
        {
            target = null;
        }
    }

    void MoveToTarget()
    {
        navMeshAgent.SetDestination(target.position);
        Vector3 lookAttarget = new Vector3(target.position.x, transform.position.y, target.position.z);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation * Quaternion.Euler(0,90,0) , Time.deltaTime * 5f);
        
    }
    
}   