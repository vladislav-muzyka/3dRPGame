using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerInteractor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] LivingCreature livingCreature;
    private NavMeshAgent navMeshAgent;
    private PlayerInteractor interactor;
    private Camera cam;
    private bool rightPointerClicked;
    private bool leftPointerClicked;
    public Interactible focus;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        navMeshAgent = GetComponent<NavMeshAgent>();
        interactor = GetComponent<PlayerInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        rightPointerClicked = Input.GetButton("Fire2");
        leftPointerClicked = Input.GetButton("Fire1");
    }


    RaycastHit raycastHit;
    void FixedUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (rightPointerClicked)
        {
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out raycastHit, 100))
            {
                navMeshAgent.destination = raycastHit.point;
                RemoveFocus();
            }
        }

        if (leftPointerClicked)
        {
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out raycastHit, 100))
            {
                navMeshAgent.destination = raycastHit.point;
                Interactible interactible = raycastHit.collider.GetComponent<Interactible>();
                if (interactible != null)
                {
                    SetFocus(interactible);
                }

            }
        }
    }

    private void SetFocus(Interactible newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
            interactor.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }
    private void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
        interactor.StopFollowingTarget();
    }
}
