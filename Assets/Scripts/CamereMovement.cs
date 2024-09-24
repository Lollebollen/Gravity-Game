using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereMovement : MonoBehaviour
{
    [SerializeField, Range(2,25)] int decayConstant;
    [SerializeField] Vector3 targetPos = Vector3.zero;

    public void CameraMoveTo(Vector3 targetPos)
    {
        this.targetPos = targetPos;
    }

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
