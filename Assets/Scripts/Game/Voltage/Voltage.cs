using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Voltage : MonoBehaviour
{
    public static BigInteger voltage;
    
    // Start is called before the first frame update
    void Start()
    {
        voltage = BigInteger.Parse(PlayerPrefs.GetString("Voltage"));
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetString("Voltage", voltage.ToString());
        PlayerPrefs.Save();
    }
}
