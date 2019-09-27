using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float MouseSpeed;

    float MouseX;
    float MouseY;
    float Xbuffer;
    float Ybuffer;

    public GameObject Player;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        Xbuffer += Input.GetAxisRaw("Mouse X");
        Ybuffer += Input.GetAxisRaw("Mouse Y");

        MouseX += Xbuffer / 2;
        MouseY += Ybuffer / 2;

        Xbuffer *= 0.75f;
        Ybuffer *= 0.75f;

        if (Ybuffer > 0)
        {
            if (MouseY < 90)
            {
                transform.rotation = Quaternion.Euler(-MouseY * MouseSpeed, MouseX * MouseSpeed, 0f);
            }
            else
            {
                MouseY = 90;
            }
        }
        else if (Ybuffer < 0)
        {
            if (MouseY > -90)
            {
                transform.rotation = Quaternion.Euler(-MouseY * MouseSpeed, MouseX * MouseSpeed, 0f);
            }
            else
            {
                MouseY = -90;
            }
        }

        Player.transform.rotation = Quaternion.Euler(0, MouseX * MouseSpeed, 0);
    }
}