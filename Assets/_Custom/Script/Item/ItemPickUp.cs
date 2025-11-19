using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    //public GameObject pickUpSFX;
    public ItemType itemType;
    public int amount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.Instance.Collect(itemType,amount);
            //GameObject sfx = Instantiate(pickUpSFX, transform.position, Quaternion.identity);
            //Destroy(sfx, sfx.GetComponent<AudioSource>().clip.length);
            Destroy(gameObject);
        }
    }
}
