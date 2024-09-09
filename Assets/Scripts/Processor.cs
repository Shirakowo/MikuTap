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
    public int concertToSuper = 10;
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
        GameObject.Find("Rx Concert").GetComponent<Text>().text = $"{concert}/{concertToSuper}";

        PlayerPrefs.SetFloat("Power", (float)power);
        PlayerPrefs.SetInt("Stage", stage);
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
            if (superConcert)
            {
                superConcert = false;
                concert = 0;
                stage++;
                CalculateVoltageToNext();
            }

            if (concert == concertToSuper - 1)
            {
                CalculateVoltageSuperCon();
                superConcert = true;
            }
            else
            {
                CalculateVoltageToNext();
                concert++;
            }
            
            voltage = 0;
            power += 1;
            
        }
    }

    public void CalculateVoltageToNext()
    {
        voltageToNext = 20 * Random.Range(0.5f, 2.5f) * stage;
    }

    public void CalculateVoltageSuperCon()
    {
        voltageToNext = 128 * Random.Range(0.75f, 3.5f) * (stage / 1.25);
    }
}
