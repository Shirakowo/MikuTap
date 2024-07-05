using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] MusicTracks;
    public AudioSource AudioSource;
    public TMP_Text MusicLabel;
    public int RandomIndex;

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

    void PlayRandomTrack()
    {
        RandomIndex = Random.Range(0, MusicTracks.Length);

        AudioSource.clip = MusicTracks[RandomIndex];
        AudioSource.Play();

        Debug.Log($"Playing track: {AudioName()}");
        MusicLabel.text = AudioName();
        Invoke(nameof(PlayRandomTrack), AudioSource.clip.length);
    }

    string AudioName() {
        return (RandomIndex + 1) switch
        {
            1 => "Strawberry Life",
            2 => "Demi-Dialection!!",
            3 => "Happy Birthday",
            4 => "Happy Tuning!",
            5 => "SHAPE",
            6 => "Starmine",
            _ => null,
        };
    }
}
