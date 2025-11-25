using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemType itemType;
    public int amount = 1;
    private bool canTake = false;

    private void Update()
    {
        if (canTake && Input.GetKeyDown(KeyCode.E))
        {
            Inventory.Instance.Collect(itemType, amount);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canTake = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canTake = false;
        }
    }
}
