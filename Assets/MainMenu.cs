using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    public AudioClip clickSound;

    private Button button;
    private AudioSource audioSource;

    private void Start()
    {
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();

        button.onClick.AddListener(PlayClickSound);
    }

    private void PlayClickSound()
    {
        audioSource.enabled = true;
        audioSource.PlayOneShot(clickSound);
        audioSource.enabled = false;
    }
}
