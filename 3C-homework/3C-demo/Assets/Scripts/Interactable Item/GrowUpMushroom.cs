using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/GrowUpMushroom")]
public class GrowUpMushroom : Item
{
    public override void Use()
    {
        base.Use();
        GameObject player = GameObject.Find("Player");
        Vector3 curScale = player.GetComponent<Transform>().localScale;

        // player.GetComponentInChildren<Animation>().Play("jump-up");

        player.GetComponent<Transform>().localScale = 1.1f * curScale;
        RemoveFromInventory();

    }

}
