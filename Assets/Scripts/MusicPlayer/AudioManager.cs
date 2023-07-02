using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip[] musicClips;
    private AudioSource source;
    private int currentTrack;

    public Text clipTitleText;
    public Text clipTimeText;

    private int fullLength;
    private int playTime;
    private int seconds;
    private int minutes;

    // Start is called before the first frame update
    void Start() {
        source = GetComponent<AudioSource>();

        // Play music
        PlayMusic();
    }

    IEnumerator WaitForMusicEnd() {
        while (source.isPlaying) {

            playTime = (int)source.time;
            showPlayTime();
            yield return null;
        }
        NextTrack();
    }

    public void PlayMusic() {
        if (source.isPlaying)
        {
            return;
        }

        currentTrack--;

        if (currentTrack < 0)
        {
            currentTrack = musicClips.Length - 1;
        }

        StartCoroutine("WaitForMusicEnd");
    }

    public void NextTrack() {
        source.Stop();
        currentTrack++;
        if (currentTrack > musicClips.Length - 1) {
            currentTrack = 0;
        }
        source.clip = musicClips[currentTrack];
        source.Play();

        // Show Title
        ShowCurrentTitle();

        StartCoroutine("WaitForMusicEnd");
    }

    public void PreviousTrack() {
        source.Stop();
        currentTrack--;
        if (currentTrack < 0) {
            currentTrack = musicClips.Length - 1;
        }
        source.clip = musicClips[currentTrack];
        source.Play();

        // Show Title
        ShowCurrentTitle();

        StartCoroutine("WaitForMusicEnd");
    }

    public void PauseMusic() {
        source.Stop();
        StopCoroutine("WaitForMusicEnd");

    }

    public void MuteMusic() {
        source.mute = !source.mute;
    }

    void ShowCurrentTitle() {
        clipTitleText.text = source.clip.name;
        fullLength = (int)source.clip.length;
    }

    void showPlayTime(){
        seconds = playTime % 60;
        minutes = (playTime / 60) % 60;
        clipTimeText.text = minutes + ":" + seconds.ToString("D2") + "/" + ((fullLength / 60) % 60) + ":" + (fullLength % 60).ToString("D2"); 
    }

}

