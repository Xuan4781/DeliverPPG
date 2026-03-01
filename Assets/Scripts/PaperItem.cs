using UnityEngine;

public class PaperItem : Item
{
    public override void PickUp()
    {
        base.PickUp();
        Debug.Log("This is Paper. Deliver to the Paper NPC");
    }
    
}
