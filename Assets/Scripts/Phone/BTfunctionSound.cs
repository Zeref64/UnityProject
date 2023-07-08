using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTfunctionSound : MonoBehaviour
{
    public Button callButton;
    public AudioClip audioClip;
    public GameObject panelToClose1;
    public GameObject panelToClose2;
    public AudioSource soundSource;

    private bool panelActive = false;

    private void Start()
    {
        callButton.onClick.AddListener(OnCallButtonClick);
    }

    private void OnCallButtonClick()
    {
        if (panelActive)
        {
            // Panel is already active, do nothing
            return;
        }

        StartCoroutine(PlaySoundAndClosePanel());
    }

    private IEnumerator PlaySoundAndClosePanel()
    {
        panelActive = true;

        soundSource.clip = audioClip;
        soundSource.Play();

        yield return new WaitForSeconds(audioClip.length);

        panelToClose1.SetActive(false);
        panelToClose2.SetActive(false);
        panelActive = false;
    }
}

