using UnityEngine;

public class PlasticItem : Item
{
    public override void PickUp()
    {
        base.PickUp();
        Debug.Log("This is plastic! Deliver to Plastic NPC.");
    }
}