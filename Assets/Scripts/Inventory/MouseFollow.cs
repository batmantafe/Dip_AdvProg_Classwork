using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public Vector2 mousePos;
    public string direction;

    // reference to Inventory
    // reference to any moving Cameras

    public bool quickMenu;

    public float scrnW, scrnH;

    void Start()
    {
        Cursor.visible = false;

        scrnW = Screen.width / 16;
        scrnH = Screen.height / 9;
    }

    void Update()
    {
        // Edit > Project Settings > Input
        if (Input.GetButton("Quick Select Menu"))
        {
            quickMenu = true;
            Cursor.visible = true;
            mousePos = Input.mousePosition;
        }

        if (quickMenu)
        {
            #region Keyboard/Controller Menu Controls
            if (direction != "Left")
            {
                if (Input.GetAxis("Horizontal") < 0)
                {
                    Debug.Log("Left");
                    direction = "Left";
                }
            }

            if (direction != "Right")
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    Debug.Log("Right");
                    direction = "Right";
                }
            }

            if (direction != "Down")
            {
                if (Input.GetAxis("Vertical") < 0)
                {
                    Debug.Log("Down");
                    direction = "Down";
                }
            }

            if (direction != "Up")
            {
                if (Input.GetAxis("Vertical") > 0)
                {
                    Debug.Log("Up");
                    direction = "Up";
                }
            }
            #endregion

            #region Mouse Input Menu Controls
            // Mouse 0,0 starts at Bottom-Right, Screen 0,0 starts at Top-Right
            if (mousePos.y >= scrnH * 4 && mousePos.y <= scrnH * 5)
            {
                if (mousePos.x >= scrnW * 0 && mousePos.x <= scrnW * 7.5f)
                {
                    Debug.Log("Left");
                    direction = "Left";
                }
            }

            if (mousePos.y >= scrnH * 4 && mousePos.y <= scrnH * 5)
            {
                if (mousePos.x >= scrnW * 8.5f && mousePos.x <= scrnW * 16)
                {
                    Debug.Log("Right");
                    direction = "Right";
                }
            }

            if (-mousePos.y + Screen.height >= scrnH * 5 && -mousePos.y + Screen.height <= scrnH * 9)
            {
                if (mousePos.x >= scrnW * 7.5f && mousePos.x <= scrnW * 8.5f)
                {
                    Debug.Log("Down");
                    direction = "Down";
                }
            }

            if (-mousePos.y + Screen.height >= scrnH * 0 && -mousePos.y + Screen.height <= scrnH * 4)
            {
                if (mousePos.x >= scrnW * 7.5f && mousePos.x <= scrnW * 8.5f)
                {
                    Debug.Log("Up");
                    direction = "Up";
                }
            }
            #endregion

            #region Test Corners
            // Mouse 0,0 starts at Bottom-Right, Screen 0,0 starts at Top-Right
            if (mousePos.y >= scrnH * 0 && mousePos.y <= scrnH * 4)
            {
                if (mousePos.x >= scrnW * 0 && mousePos.x <= scrnW * 7.5f)
                {
                    Debug.Log("Down-Left");
                    direction = "Down-Left";
                }
            }

            if (mousePos.y >= scrnH * 5 && mousePos.y <= scrnH * 9)
            {
                if (mousePos.x >= scrnW * 0 && mousePos.x <= scrnW * 7.5f)
                {
                    Debug.Log("Up-Left");
                    direction = "Up-Left";
                }
            }

            if (mousePos.y >= scrnH * 0 && mousePos.y <= scrnH * 4)
            {
                if (mousePos.x >= scrnW * 8.5f && mousePos.x <= scrnW * 16)
                {
                    Debug.Log("Down-Right");
                    direction = "Down-Right";
                }
            }

            if (mousePos.y >= scrnH * 5 && mousePos.y <= scrnH * 9)
            {
                if (mousePos.x >= scrnW * 8.5f && mousePos.x <= scrnW * 16)
                {
                    Debug.Log("Up-Right");
                    direction = "Up-Right";
                }
            }

            // Keyboard
            if (direction != "Down-Left")
            {
                if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") < 0)
                {
                    Debug.Log("Down-Left");
                    direction = "Down-Left";
                }
            }

            if (direction != "Down-Right")
            {
                if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") < 0)
                {
                    Debug.Log("Down-Right");
                    direction = "Down-Right";
                }
            }

            if (direction != "Up-Right")
            {
                if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") > 0)
                {
                    Debug.Log("Up-Right");
                    direction = "Up-Right";
                }
            }

            if (direction != "Up-Left")
            {
                if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") > 0)
                {
                    Debug.Log("Up-Left");
                    direction = "Up-Left";
                }
            }
            #endregion
        }

        /*else
        {
            quickMenu = false;
            Cursor.visible = false;
        }*/
    }

    void OnGUI()
    {
        GUI.Box (new Rect(scrnW * 0, scrnH * 4, scrnW * 7.5f, scrnH), "Left");
        GUI.Box(new Rect(scrnW * 8.5f, scrnH * 4, scrnW * 7.5f, scrnH), "Right");
        GUI.Box(new Rect(scrnW * 7.5f, scrnH * 0, scrnW, scrnH * 4), "Up");
        GUI.Box(new Rect(scrnW * 7.5f, scrnH * 5, scrnW, scrnH * 4), "Down");
    }
}
