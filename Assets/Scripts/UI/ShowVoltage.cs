using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowVoltage : MonoBehaviour
{
    public TMP_Text VoltShow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VoltShow.text = Voltage.voltage.ToString();
    }
}
