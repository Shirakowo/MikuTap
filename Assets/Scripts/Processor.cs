#pragma warning disable CS0108
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Processor : MonoBehaviour
{
    public AudioClip[] audioTracks;
    public double voltage;
    public double tapVoltage;
    public int mikuLevel = 1;
    AudioSource audioSource;
    Text Tv;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRandomTrack();

        Tv = GameObject.Find("Rx 1").GetComponent<Text>();

        voltage = PlayerPrefs.GetFloat("Voltage", 0);
        mikuLevel = PlayerPrefs.GetInt("Miku", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Tap();
        }

        tapVoltage = mikuLevel * 1.2;

        Tv.text = Mathf.Round((float)voltage).ToString();
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
        voltage += tapVoltage;
    }
}
