using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string voltage;
    public string tapVoltage;
    public int stage;
    public int mikuLevel;

    // Start is called before the first frame update
    void Start()
    {
        mikuLevel = PlayerPrefs.GetInt("MikuLv");
    }

    // Update is called once per frame
    void Update()
    {
        voltage = Voltage.voltage.ToString();
        tapVoltage = TapVoltage.tapVoltage.ToString();
        stage = Stage.stage;
        
        PlayerPrefs.SetInt("MikuLv", mikuLevel);
        PlayerPrefs.Save();
    }
}
