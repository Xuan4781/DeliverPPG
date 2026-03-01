using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData data;
    public virtual void PickUp()
    {
        Debug.log("Picked up: " data.itemName);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
