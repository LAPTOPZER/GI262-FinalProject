using UnityEngine;

public class ChestFake : MonoBehaviour
{
    public GameObject DestroyFX;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            GameObject explosionFX = Instantiate(DestroyFX, transform.position, Quaternion.identity);
            Destroy(explosionFX, 0.5f);
            Destroy(this.gameObject);
            player.TakeDamage(20);
        }
    }
}
