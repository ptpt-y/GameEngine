using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/GrowDownMushroom")]
public class GrowDownMushroom : Item
{
    public override void Use()
    {
        base.Use();
        GameObject player = GameObject.Find("Player");
        Vector3 curScale = player.GetComponent<Transform>().localScale;

        // player.GetComponentInChildren<Animation>().Play("jump-up");

        player.GetComponent<Transform>().localScale = .8f * curScale;
        RemoveFromInventory();

    }

}
