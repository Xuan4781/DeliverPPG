using UnityEngine;

public class GlassItem : Item
{
    public override void PickUp()
    {
        base.PickUp();
        Debug.Log("This is glass! Deliver to Glass NPC.");
    }
}