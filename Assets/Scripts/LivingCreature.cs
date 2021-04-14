using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class LivingCreature : MonoBehaviour
{

    public Rigidbody CreatureRB { get; private set; }
    public NavMeshAgent CratureNavMeshAgent { get; private set; }
    public Collider CreatureCollider { get; private set; }
    public Animator CreatureAnimator { get; private set; }

    [SerializeField] private LivingCreatureActionController lcActionController;
    public LivingCreatureActionController LCActionController => lcActionController;


    void Start()
    {
        CreatureRB = GetComponent<Rigidbody>();
        CratureNavMeshAgent = GetComponent<NavMeshAgent>();
        CreatureCollider = GetComponent<Collider>();
        CreatureAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
