using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithEnemy : Interactible
{
   // LivingCreature livingCreature;
    public override void Interact()
    {
        base.Interact();
        Atack();
    }

    private void Atack()
    {
        Debug.Log("You interact with enemy");
       // livingCreature.LCActionController.ChangeAction(ActionType.Attack);
    }
}
