using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player controls for platformer demo
/// Author: Indie Marc (Marc-Antoine Desbiens)
/// </summary>

namespace IndieMarc.Platformer
{

    public class PlayerControls : MonoBehaviour
    {
        public float LagTime = 0.01f;
        public int player_id;
        public KeyCode left_key;
        public KeyCode right_key;
        public KeyCode up_key;
        public KeyCode down_key;
        public KeyCode jump_key;
        public KeyCode action_key;

        [Header("Control Setups")]
        public bool classicSetup = true;
        public bool crappySetup1 = false;
        public bool crappySetup2 = false;
        public bool crappySetup3 = false;
        public bool crappySetup4 = false;

        private Vector2 move = Vector2.zero;
        private bool jump_press = false;
        private bool jump_hold = false;
        private bool action_press = false;
        private bool action_hold = false;

        private static Dictionary<int, PlayerControls> controls = new Dictionary<int, PlayerControls>();

        bool facingR = true;

        void Awake()
        {
            controls[player_id] = this;
        }

        private void Start()
        {
            ChangeControls();
        }

        void OnDestroy()
        {
            controls.Remove(player_id);
        }

        void Update()
        {
            move = Vector2.zero;
            jump_hold = false;
            jump_press = false;
            action_hold = false;
            action_press = false;

            if (Input.GetKey(left_key))
                StartCoroutine(LagInput("left"));
            if (Input.GetKey(right_key))
                StartCoroutine(LagInput("right"));
            if (Input.GetKey(down_key))
                StartCoroutine(LagInput("down"));
            if (Input.GetKey(up_key))
                StartCoroutine(LagInput("up"));
            /*
            if (Input.GetKeyDown(jump_key)) jump_press = true;
            if (Input.GetKey(jump_key)) jump_hold = true;
            if (Input.GetKey(action_key)) action_hold = true;
            if (Input.GetKeyDown(action_key)) action_press = true;
            */

            move += (facingR ? Vector2.right : Vector2.left);

            float move_length = Mathf.Min(move.magnitude, 1f);
            move = move.normalized * move_length;
        }


        //------ These functions should be called from the Update function, not FixedUpdate
        public Vector2 GetMove()
        {
            return move;
        }

        public bool GetJumpDown()
        {
            return jump_press;
        }

        public bool GetJumpHold()
        {
            return jump_hold;
        }

        public bool GetActionDown()
        {
            return action_press;
        }

        public bool GetActionHold()
        {
            return action_hold;
        }

        //-----------

        public static PlayerControls Get(int player_id)
        {
            foreach (PlayerControls control in GetAll())
            {
                if (control.player_id == player_id)
                {
                    return control;
                }
            }
            return null;
        }

        public static PlayerControls[] GetAll()
        {
            PlayerControls[] list = new PlayerControls[controls.Count];
            controls.Values.CopyTo(list, 0);
            return list;
        }

        public IEnumerator LagInput(string inputType)
        {
            yield return new WaitForSeconds(LagTime);

            switch (inputType)
            {
                case "left":
                    facingR = false;
                    break;

                case "right":
                    facingR = true;
                    break;

                case "up":
                    move += Vector2.up;
                    break;

                case "down":
                    move += -Vector2.up;
                    break;

                default:
                    break;
            }


        }

        public void ChangeControls()
        {
            if (classicSetup)
            {
                left_key = KeyCode.LeftArrow;
                right_key = KeyCode.RightArrow;
                up_key  = KeyCode.UpArrow;
                down_key = KeyCode.DownArrow;
            }

            else if (crappySetup1)  // inverse gauche/droite
            {
                left_key = KeyCode.RightArrow;
                right_key = KeyCode.LeftArrow;
                up_key = KeyCode.UpArrow;
                down_key = KeyCode.DownArrow;
            }

            else if(crappySetup2)  // inverse haut/bas
            {
                left_key = KeyCode.LeftArrow;
                right_key = KeyCode.RightArrow;
                up_key = KeyCode.DownArrow;
                down_key = KeyCode.UpArrow;
            }

            else if (crappySetup3)  // inverse haut/bas et gauche/droite
            {
                left_key = KeyCode.RightArrow;
                right_key = KeyCode.LeftArrow;
                up_key = KeyCode.DownArrow;
                down_key = KeyCode.UpArrow;
            }

            else if (crappySetup4)  // inverse gauche/haut et droite/bas
            {
                left_key = KeyCode.UpArrow;
                right_key = KeyCode.DownArrow;
                up_key = KeyCode.LeftArrow;
                down_key = KeyCode.RightArrow;
            }
        }
    }

}