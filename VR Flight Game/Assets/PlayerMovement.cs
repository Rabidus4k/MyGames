using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float _Speed = 2f;
    // Update is called once per frame
    private void FixedUpdate()
    {
        text.SetText($"X: {Input.acceleration.x}\nY: {Input.acceleration.x}\nZ: {Input.acceleration.z}");
        Vector3 dir = transform.GetChild(0).transform.forward;

        // we assume that device is held parallel to the ground
        // and Home button is in the right hand

        // remap device acceleration axis to game coordinates:
        //  1) XY plane of the device is mapped onto XZ plane
        //  2) rotated 90 degrees around Y axis

        transform.Translate(dir * _Speed * Time.fixedDeltaTime);
    }
}
