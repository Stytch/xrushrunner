using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class StopWatchTrigger : MonoBehaviour
{
    public bool isStart;
    public Text swText;

    private void Start()
    {
        StopWatchManager.stopwatch = new Stopwatch();
        StopWatchManager.stopwatch.Start();
    }

    void Update()
    {
        if(swText!= null && StopWatchManager.stopwatch != null && StopWatchManager.stopwatch.IsRunning)
        {
            swText.text = StopWatchManager.stopwatch.Elapsed.Minutes.ToString().PadLeft(2, '0')
                + ":" + StopWatchManager.stopwatch.Elapsed.Seconds.ToString().PadLeft(2, '0')
                + ":" + StopWatchManager.stopwatch.Elapsed.Milliseconds.ToString().PadLeft(3, '0');

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isStart)
            {

            }
            else
            {
                StopWatchManager.stopwatch.Stop();
            }
        }
    }
}

public static class StopWatchManager
{
    public static Stopwatch stopwatch = new Stopwatch();
}

