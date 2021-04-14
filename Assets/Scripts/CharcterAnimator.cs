using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharcterAnimator : MonoBehaviour
{
    [SerializeField] float smoothAnimation = 0.1f;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedPercent = navMeshAgent.velocity.magnitude / navMeshAgent.speed;
        animator.SetFloat("Blend", speedPercent, smoothAnimation, Time.deltaTime);
    }
}
