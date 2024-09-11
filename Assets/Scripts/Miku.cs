using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Miku : MonoBehaviour
{
    public static Miku miku;
    public int level;
    public double powerNeed;
    public bool canUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        miku = this;

        level = PlayerPrefs.GetInt("Miku", 1);
    }

    // Update is called once per frame
    void Update()
    {
        powerNeed = Mathf.Floor(5f + 1.2f * (level - 1f));
        if (Processor.instance.power >= powerNeed)
        {
            canUpgrade = true;
        }

        GameObject.Find("Rx Miku 1").GetComponent<Text>().text = powerNeed.ToString();
        GameObject.Find("Rx Miku 4").GetComponent<Text>().text = $"Lv. {level}";

        PlayerPrefs.SetInt("Miku", level);
    }

    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Processor.NewColor(128, 10, 64);
    }

    void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Processor.NewColor(255, 128, 200);
        if (canUpgrade)
        {
            Processor.instance.power -= powerNeed;
            level += 1;
            canUpgrade = false;
        }
    }
}
