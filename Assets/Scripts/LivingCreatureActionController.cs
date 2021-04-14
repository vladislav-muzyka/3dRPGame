using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingCreatureActionController : MonoBehaviour
{
    [SerializeField] private LivingCreature livingCreature;
    private ActionType currentAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAction(ActionType action)
    {
        ResetAction();
        currentAction = action;
        if (currentAction != ActionType.None)
            livingCreature.CreatureAnimator.SetBool(currentAction.ToString(), true);
    }

    private void ResetAction()
    {
        if (currentAction != ActionType.None)
            livingCreature.CreatureAnimator.SetBool(currentAction.ToString(), false);
        currentAction = ActionType.None;
    }


}

public enum ActionType
{ 
None,
Run, 
Walk,
Attack,
Hurt,
Death,
Sprint,
}