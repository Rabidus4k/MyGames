using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "Error Controlled")]
public class ErrorController : ScriptableObject
{
    public TextMeshPro _LogText;
    
    public void SetError(string error)
    {
        _LogText.SetText(error);
    }
}
