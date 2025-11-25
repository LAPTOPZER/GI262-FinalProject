using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject DestroyFX;
    public GameObject KeyDrop;
    private bool canOpen = false;

    public GameObject UnlockText;

    private void Update()
    {
        if (canOpen && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E");
            GameObject explosionFX = Instantiate(DestroyFX, transform.position, Quaternion.identity);
            Destroy(explosionFX, 0.5f);
            Destroy(this.gameObject);
            GameObject keyDrop = Instantiate(KeyDrop, transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UnlockText.SetActive(true);
            canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = false;
            UnlockText.SetActive(false);
        }
    }
}
