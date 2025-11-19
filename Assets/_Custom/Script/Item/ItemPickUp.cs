using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemType itemType;
    public int amount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.Instance.Collect(itemType,amount);
            Destroy(gameObject);
        }
    }
}
