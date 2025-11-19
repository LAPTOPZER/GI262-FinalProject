using UnityEngine;

public class Chest : MonoBehaviour
{
    public string requireKey;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        requireKey += 1;
    }
}
