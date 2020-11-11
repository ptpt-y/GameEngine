using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/JumpMushroom")]
public class JumpMushroom : Item
{

    public override void Use()
    {
        base.Use();
        GameObject.Find("Player").GetComponent<PlayerMotor>().eatJump = true;

        RemoveFromInventory();

    }
}
