using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    private Transform goal;
    private NavMeshAgent agent;
    private Animator anim;

    public float attackRange;
    public float attackAnimationRange;

    // Use this for initialization
    void Awake() {
        goal = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void LateUpdate() {
        if (goal != null) {
            float dist = (transform.position - goal.position).magnitude;
            if (dist <= attackAnimationRange) {
                anim.SetBool("withinAttackRange", true);
            } else {
                anim.SetBool("withinAttackRange", false);
            }
            if (dist > attackRange ) {
                agent.SetDestination(goal.position);
            }
        }
    }
}