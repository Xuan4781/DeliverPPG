using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private CharacterController controller;
    private ItemData currentItemData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Interact();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * moveSpeed * Time.deltaTime);
    }

    void Interact()
    {
        if (!string.IsNullOrEmpty(currentItemData.itemName)){
            Debug.Log("Holding: " + currentItemData.itemName);  
        }
            
        //let player pick up item using E
        if(Input.GetKeyDown(KeyCode.E))
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, 2f);
            foreach( var hit in hits)
            {
                Item item = hit.GetComponent<Item>();
                if(item != null)
                {
                    currentItemData = item.data;
                    item.PickUp();
                    Destroy(item.gameObject);
                    Debug.Log("Picked up: " + currentItemData.itemName);
                    break; // one item at once
                }
            }
        }
        // deliver 
        if (Input.GetKeyDown(KeyCode.Q) && !string.IsNullOrEmpty(currentItemData.itemType))
        {
            Debug.Log("Q pressed");
            Collider[] hits = Physics.OverlapSphere(transform.position, 2f);
            foreach (var hit in hits)
            {
                if (hit.CompareTag("NPC_Paper") && currentItemData.itemType == "Paper")
                {
                    GameManager.Instance.AddScore(currentItemData.pointValue);
                    Debug.Log("Delivered Paper! +1 point");
                    currentItemData = new ItemData();
                    break;
                }
                else if (hit.CompareTag("NPC_Plastic") && currentItemData.itemType == "Plastic")
                {
                    GameManager.Instance.AddScore(currentItemData.pointValue);
                    Debug.Log("Delivered Plastic! +1 point");
                    currentItemData = new ItemData(); // reset
                    break;
                }
                else if (hit.CompareTag("NPC_Glass") && currentItemData.itemType == "Glass")
                {
                    GameManager.Instance.AddScore(currentItemData.pointValue);
                    Debug.Log("Delivered Glass! +1 point");
                    currentItemData = new ItemData(); // reset
                    break;
                }
                else if (hit.CompareTag("NPC_Paper") || hit.CompareTag("NPC_Plastic") || hit.CompareTag("NPC_Glass"))
                {
                    // Delivered wrong -1 point
                    GameManager.Instance.AddScore(-1);
                    Debug.Log("Wrong delivery! -1 point");
                    currentItemData = new ItemData(); // reset
                    break;
                }
            }
        }
    }
}

