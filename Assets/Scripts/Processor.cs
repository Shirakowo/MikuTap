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
    public double voltageToNext = 20;
    public int stage;
    public int concert;
    public bool superConcert;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        PlayerPrefs.DeleteAll();

        power = PlayerPrefs.GetFloat("Power", 0);
        stage = PlayerPrefs.GetInt("Stage", 1);

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
        PlayerPrefs.SetInt("Stage", stage);

        /*
        SetActiveBlock(1);
        SetActiveBlock(2);
        SetActiveBlock(3);
        SetActiveBlock(4);
        SetActiveBlock(5);
        SetActiveBlock(6);
        SetActiveBlock(7);
        SetActiveBlock(8);
        SetActiveBlock(9);
        */
    }

    public void SetActiveBlock(int block)
    {
        GameObject blk = GameObject.Find($"Square {block}");

        if (voltage >= voltageToNext / 9 * block)
        {
            blk.SetActive(true);
        }
        else
        {
            blk.SetActive(false);
        }
    }

    public void PlayRandomTrack()
    {
        int randomIndex = Random.Range(0, audioTracks.Length);

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

        if (voltage >= voltageToNext)
        {
            voltageToNext = CalculateVoltageToNext(10);
            voltage = 0;
            power += 1;
        }
    }

    public double CalculateVoltageToNext(double baseVoltage)
    {
        return baseVoltage * (Random.value + 1);
    }

    
}
