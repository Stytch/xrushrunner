using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;

public class TrackerExporter : MonoBehaviour
{
    //PRIVATE
    private List<float[]> tracker;
    private float allTime = 0;

    //PUBLIC
    public Transform Player;

    private string GetPath()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/CSV/" + "Saved_data.csv";
#else
        return Application.dataPath +"/"+"Saved_data.csv";
#endif
    }

    bool ExportCsv()
    {
        string filePath = GetPath();
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("position x; position y; time");

        for (int index = 0; index < tracker.Count; index++)
            sb.AppendLine(string.Join(";", tracker[index]));

        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        tracker = new List<float[]>();
        
        allTime = 0;
        if (Player == null) Debug.Log("NO PLAYER IN TRACKEREXPORTER");
    }

    //
    private void FixedUpdate()
    {
        allTime += Time.fixedDeltaTime;
        if(Player != null)
        {
            Vector2 pos = new Vector2(Player.position.x, Player.position.y);
            tracker.Add(new float[] { pos.x, pos.y, allTime } );
        }
    }

    private void OnApplicationQuit()
    {
        ExportCsv();
    }




}
