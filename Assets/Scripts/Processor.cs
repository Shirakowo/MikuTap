#pragma warning disable CS0108
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Processor : MonoBehaviour
{
    public static Processor instance;
    public AudioClip[] audioTracks;
    public double power;
    public double voltage;
    public double tapVoltage;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        PlayerPrefs.DeleteAll();

        power = PlayerPrefs.GetFloat("Power", 0);

        audioSource = GetComponent<AudioSource>();
        PlayRandomTrack();
    }

    // Update is called once per frame
    void Update()
    {
        tapVoltage = Miku.miku.level * 1.2f;

        GameObject.Find("Rx Power").GetComponent<Text>().text = Mathf.Round((float)power).ToString();
        GameObject.Find("Rx Volt").GetComponent<Text>().text = Mathf.Round((float)voltage).ToString();
        PlayerPrefs.SetFloat("Power", (float)power);
    }

    void PlayRandomTrack()
    {
        int randomIndex;

        randomIndex = Random.Range(0, audioTracks.Length);

        audioSource.clip = audioTracks[randomIndex];
        audioSource.Play();

        Invoke(nameof(PlayRandomTrack), audioSource.clip.length);
    }

    /// <summary>
    /// Return new Color components with RGB and A set to 255
    /// </summary>
    public static Color NewColor(int r, int g, int b)
    {
        return new Color(r/255f, g/255f, b/255f, 1f);
    }

    /// <summary>
    /// Return new Color components with RGBA
    /// </summary>
    public static Color NewColor(int r, int g, int b, int a)
    {
        return new Color(r/255f, g/255f, b/255f, a/255f);
    }

    public void Tap()
    {
        voltage += tapVoltage;
        if (voltage >= 20)
        {
            voltage = 0;
            power += 1;
        }
    }
}
