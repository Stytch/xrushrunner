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
    public string fileName = "Saved_Data";

    private string GetPath()
    {
        string path;

#if UNITY_EDITOR
        path = Application.dataPath + "/CSV/";
#else
        path =Application.dataPath +"/";
#endif

        int count = Directory.GetFiles(path, fileName + "*.csv").Length;

        return (path + fileName + "_" + (count-1).ToString() +".csv");
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
