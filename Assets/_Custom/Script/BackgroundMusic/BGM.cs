using UnityEngine;
using UnityEngine.Audio;

public class BGM : MonoBehaviour
{

    public AudioSource bgMusic;
    private static BGM instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (bgMusic == null)
            bgMusic = GetComponent<AudioSource>();
    }

    public void ToggleMusic()
    {
        if (bgMusic == null) return;

        if (bgMusic.isPlaying)
            bgMusic.Pause();
        else
            bgMusic.Play();
    }

}
