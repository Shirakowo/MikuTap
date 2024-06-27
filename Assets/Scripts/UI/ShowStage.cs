using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowStage : MonoBehaviour
{
    public TMP_Text PreStage;
    public TMP_Text NowStage;
    public TMP_Text NexStage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Stage.stage == 0) {
            PreStage.text = "";
        } else {
            PreStage.text = (Stage.stage - 1).ToString();
        }

        NowStage.text = Stage.stage.ToString();
        NexStage.text = (Stage.stage + 1).ToString();
    }
}
