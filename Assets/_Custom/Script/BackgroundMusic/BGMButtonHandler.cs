using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BGMButtonHandler : MonoBehaviour
{
    private Button btn;
    private BGM bgm;

    void Awake()
    {
        btn = GetComponent<Button>();
    }

    void Start()
    {
        bgm = FindObjectOfType<BGM>();
        if (bgm == null)
        {
            Debug.LogError("No BackgroundMusicController found in scene!");
            btn.interactable = false;
            return;
        }

        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(bgm.ToggleMusic);
    }
}
