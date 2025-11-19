using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField]bool isOpen = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOpen)
        {
            isOpen = true;
        }
    }
}
