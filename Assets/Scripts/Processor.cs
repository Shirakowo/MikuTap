#pragma warning disable CS0108
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Processor : MonoBehaviour
{
    public double voltage;
    public AudioClip[] audioTracks;
    AudioSource audioSource;
    Text Tv;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRandomTrack();

        Tv = GameObject.Find("Rx 1").GetComponent<Text>();

        if (PlayerPrefs.HasKey("Voltage"))
        {
            voltage = PlayerPrefs.GetFloat("Voltage");
        }
        else
        {
            PlayerPrefs.SetFloat("Voltage", 0);
            voltage = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Tap();
        }

        Tv.text = voltage.ToString();
        PlayerPrefs.SetFloat("Voltage", (float)voltage);
    }

    void PlayRandomTrack()
    {
        int randomIndex;

        randomIndex = Random.Range(0, audioTracks.Length);

        audioSource.clip = audioTracks[randomIndex];
        audioSource.Play();

        Invoke(nameof(PlayRandomTrack), audioSource.clip.length);
    }

    void Tap()
    {
        voltage += 1;
    }
}
