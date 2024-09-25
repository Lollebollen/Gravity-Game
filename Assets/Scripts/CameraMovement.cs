using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField, Range(1, 25), Tooltip("Larger number = faster lerp")] int decayConstant;
    [SerializeField, Range(0, 1), Tooltip("Where the camra should be inbetween the room and the player")] float middlePosBetween; 
    [SerializeField] PlayerMovement playerMovement;
    public Vector3 roomPos = Vector3.zero;

    [Header("Parallax")]
    [SerializeField] Transform[] parallaxObjects;
    [SerializeField] float[] parallaxAmount;
    Vector3 posLastFrame;    

    private void LateUpdate()
    {
        Vector3 targetPos = (playerMovement.transform.position - roomPos) * middlePosBetween + roomPos;
        float dt = Time.deltaTime;
        Vector3 newPos = new Vector3(Lerp(transform.position.x, targetPos.x, decayConstant, dt), Lerp(transform.position.y, targetPos.y, decayConstant, dt), transform.position.z);
        transform.position = newPos;
        if (posLastFrame != null)
        {
            Vector3 movement = posLastFrame - newPos;
            for(int i = 0; i < parallaxObjects.Length; i++)
            {
                parallaxObjects[i].position += movement * parallaxAmount[i];
            }
        }
        posLastFrame = newPos;
    }

    private float Lerp(float a, float b, int decay, float dt)
    {
        return b + (a - b) * Mathf.Exp(-decay * dt);
    }
}
