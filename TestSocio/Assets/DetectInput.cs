using IndieMarc.Platformer;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DetectInput : MonoBehaviour
{
  // Start is called before the first frame update
  //public GameObject player;
  public PlayerControls PC;
  //public StopWatchManager SM;
  int up = 0;
  int down = 0;
  int left = 0;
  int right = 0;
  static string path = "Assets/log.txt";
  StreamWriter writer;

  void Start()
  {
    up = 0;
    down = 0;
    left = 0;
    right = 0;
  }

  // Update is called once per frame
  void Update()
    {
        
    }
   void OnTriggerStay2D(Collider2D collision)
  {
    writer = new StreamWriter(path, true);
    if (Input.GetKeyDown(PC.left_key)) {
      //Debug.Log("Collision : " + PC.left_key);
      writer.WriteLine(PC.left_key);
      left++;
    }

    if (Input.GetKeyDown(PC.up_key)) {
      //Debug.Log("Collision : " + PC.up_key);
      writer.WriteLine(PC.up_key);
      up++;
    }
    if (Input.GetKeyDown(PC.right_key)) {
      //Debug.Log("Collision : " + PC.right_key);
      writer.WriteLine(PC.right_key);
      right++;
    }
    if (Input.GetKeyDown(PC.down_key)) {
      //Debug.Log("Collision : " + PC.down_key);
      writer.WriteLine(PC.down_key);
      down++;
    }
    writer.Close();
  }
  public void DisplayResults()
  {
    writer = new StreamWriter(path, true);

    writer.WriteLine("Number of up : " + up + " Number of Right : "+right + " Number of Left : " + left + " Number of Down : "+down);
    writer.Close();



  }
}
