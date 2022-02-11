using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    int enemyLife = 2;
    public Transform target;
    //追跡
    NavMeshAgent agent;
    Animator animator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.destination = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;
        animator.SetFloat("Distance", agent.remainingDistance);
    }
    private void OnTriggerEnter(Collider other)
    {
        Damage damage = other.GetComponent<Damage>();
        if (other.gameObject.tag == "Player" && damage != null)
        {
           // enemyLife--;
            Debug.Log("Playerからダメージを受けた");
        }
        if (enemyLife == 0)
        {
            Destroy(gameObject);
        }
    }
}
