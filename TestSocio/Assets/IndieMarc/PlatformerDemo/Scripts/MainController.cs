using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public int targetFrame = 30;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrame;
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.targetFrameRate != targetFrame)
            Application.targetFrameRate = targetFrame;
    }
}
