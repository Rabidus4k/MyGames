using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Target = null;
    public bool Smoothing = true;
    public Transform LookObject = null;
    public bool KeepDistance = true;
    public float TimeMoving = 0.5f;

    //Update is called once per frame
    void FixedUpdate()
    {
        if (Target != null)
        {
            if (Smoothing)
            {
                float distance = 0f;

                if (LookObject != null)
                {
                    distance = (transform.position - LookObject.position).magnitude;
                }
                transform.position = Vector3.Slerp(transform.position, Target.position, Time.deltaTime / TimeMoving);
                transform.rotation = Quaternion.Slerp(transform.rotation, Target.rotation, Time.deltaTime / TimeMoving);
                if (LookObject != null && KeepDistance)
                {
                    Vector3 direction = transform.position - LookObject.position;
                    if (distance > direction.magnitude)
                        transform.position = LookObject.position + direction.normalized * distance;
                }
            }
            else
            {
                transform.position = Target.position;
                transform.rotation = Target.rotation;
            }
        }
    }
}
