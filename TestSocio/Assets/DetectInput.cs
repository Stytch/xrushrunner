using IndieMarc.Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInput : MonoBehaviour
{
  // Start is called before the first frame update
  //public GameObject player;
  public PlayerControls PC;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (Input.GetKey(PC.left_key))
      Debug.Log("Collision : "+ PC.left_key);

    if (Input.GetKey(PC.up_key))
      Debug.Log("Collision : " + PC.up_key);

    if (Input.GetKey(PC.right_key))
      Debug.Log("Collision : " + PC.right_key);

    if (Input.GetKey(PC.down_key))
      Debug.Log("Collision : " + PC.down_key);

  }
}
