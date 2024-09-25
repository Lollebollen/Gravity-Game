using System.Collections;
using System.Collections.Generic;

using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraToRoom : MonoBehaviour
{
    CameraMovement cameraMovement;
    Vector3 pos;

    private void Awake()
    {
        pos = transform.position;
        cameraMovement= Camera.main.GetComponent<CameraMovement>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            cameraMovement.roomPos = pos;
        }
    }


}
