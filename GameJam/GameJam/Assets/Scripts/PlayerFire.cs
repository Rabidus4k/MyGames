using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public AudioSource audio;
    [SerializeField]
    private GameObject _fireBallPref;
    [SerializeField]
    private Bar _manaBar;
    [SerializeField]
    private GameObject _placeToFire;

    [SerializeField]
    private Transform _staffPosition;
    private Vector3 mousePosition;

    public static int Kills = 0;
    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (PlayerFire.Kills == 5)
            DoorTransition.canTeleport = true;
        // Тот самый поворот
        // вычисляем разницу между текущим положением и положением мыши
        Vector3 difference = mousePosition - _placeToFire.transform.position;
        difference.Normalize();
        // вычисляемый необходимый угол поворота
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // Применяем поворот вокруг оси Z
        Quaternion newRotation = Quaternion.Euler(0f, 0f, rotation_z);
        _placeToFire.transform.rotation = newRotation;

        if (difference.x < 0)
        {
            _placeToFire.transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            _placeToFire.transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetMouseButtonDown(0) && _manaBar.currentValue > 10)
        {
            audio.Play();
            GameObject newFireBall = Instantiate(_fireBallPref, _staffPosition.position, newRotation);
            newFireBall.GetComponent<FireBall>().SetMoveToPosition(mousePosition);
            _manaBar.DecreaseValue(10f);

        }
    }
}
