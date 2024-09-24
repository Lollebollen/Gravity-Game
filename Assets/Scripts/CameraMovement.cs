using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField, Range(2,25)] int decayConstant;
    public Vector3 targetPos = Vector3.zero;

    private float Lerp(float a, float b, int decay, float dt)
    {
        return b + (a - b) * Mathf.Exp(-decay * dt);
    }

    private void Update()
    {
        float dt = Time.deltaTime;
        transform.position = new Vector3(Lerp(transform.position.x, targetPos.x, decayConstant, dt), Lerp(transform.position.y, targetPos.y, decayConstant, dt), transform.position.z);
    }
}
