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

        PlayerPrefs.DeleteAll();

        level = PlayerPrefs.GetInt("Miku", 1);
    }

    // Update is called once per frame
    void Update()
    {
        powerNeed = 5 + 1.2 * (level - 1);
        if (Processor.instance.power >= powerNeed)
        {
            canUpgrade = true;
        }

        GameObject.Find("Rx Miku 1").GetComponent<Text>().text = Mathf.Round((float)powerNeed).ToString();
        GameObject.Find("Rx Miku 4").GetComponent<Text>().text = $"Lv. {level}";

        PlayerPrefs.SetInt("Miku", level);
    }

    void OnMouseDown()
    {

    }

    void OnMouseUp()
    {
        if (canUpgrade)
        {
            Processor.instance.power -= powerNeed;
            level += 1;
            canUpgrade = false;
        }
    }

    void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().color = Processor.NewColor(128, 10, 64);
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = Processor.NewColor(255, 128, 200);
    }
}
