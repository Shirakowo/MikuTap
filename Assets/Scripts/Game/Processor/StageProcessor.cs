using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageProcessor : MonoBehaviour
{
    public TMP_Text PreStage;
    public TMP_Text NowStage;
    public TMP_Text NexStage;
    public int Stage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Stage == 0) {
            PreStage.text = "";
        } else {
            PreStage.text = (Stage - 1).ToString();
        }

        NowStage.text = Stage.ToString();
        NexStage.text = (Stage + 1).ToString();
    }
}
