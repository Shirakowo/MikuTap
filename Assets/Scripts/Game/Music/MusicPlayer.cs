using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] MusicTracks;
    public AudioSource AudioSource;
    public TMP_Text MusicLabel;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        PlayRandomTrack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayRandomTrack()
    {
        int RandomIndex = Random.Range(0, MusicTracks.Length);
        string AudioName = AudioSource.clip.name;

        AudioSource.clip = MusicTracks[RandomIndex];
        AudioSource.Play();

        Debug.Log($"Playing track: {AudioName}");
        MusicLabel.text = AudioName;
        Invoke(nameof(PlayRandomTrack), AudioSource.clip.length);
    }
}
