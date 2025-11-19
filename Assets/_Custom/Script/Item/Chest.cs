using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject DestroyFX;
    public GameObject KeyDrop;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject explosionFX = Instantiate(DestroyFX, transform.position, Quaternion.identity);
            Destroy(explosionFX, 0.5f);
            Destroy(this.gameObject);
            GameObject keyDrop = Instantiate(KeyDrop, transform.position, Quaternion.identity);
        }
    }
}
