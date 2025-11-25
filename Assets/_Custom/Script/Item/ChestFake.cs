using UnityEngine;

public class ChestFake : MonoBehaviour
{
    public GameObject DestroyFX;
    private bool canOpen = false;

    public GameObject UnlockText;
    private PlayerController player;

    private void Update()
    {
        if (canOpen && Input.GetKeyDown(KeyCode.E))
        {
            player.TakeDamage(20);
            GameObject explosionFX = Instantiate(DestroyFX, transform.position, Quaternion.identity);
            Destroy(explosionFX, 0.5f);
            Destroy(this.gameObject);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

            UnlockText.SetActive(true);
            canOpen = true;

        player = other.GetComponent<PlayerController>();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        canOpen = false;
        UnlockText.SetActive(false);

    }
}
