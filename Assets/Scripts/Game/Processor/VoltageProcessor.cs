using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class VoltageProcessor : MonoBehaviour
{
    public TMP_Text VoltageShow;
    public int Voltage;
    public int TapVoltage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            Voltage += TapVoltage;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Voltage += TapVoltage;
            }
        }

        VoltageShow.text = Voltage.ToString();
    }
}
