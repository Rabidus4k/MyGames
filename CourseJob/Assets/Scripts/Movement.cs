using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _MovementSpeed;
    public GameObject _StaminaBar;
    private float _StartSpeed;
    private float _Stamina = 1f;
    public bool _inMenu = false;
    private void Start()
    {
        _StartSpeed = _MovementSpeed;
    }
    
    /// <summary>
    /// Вызывается каждый кадр
    /// Функция обрабатывает нажатие кнопок и соответственно реагирует на них
    /// </summary>
    void FixedUpdate()
    {
        if (_Stamina < 0)
        {
            _Stamina = 0;
        }
        if (_Stamina > 1)
        {
            _Stamina = 1;
        }
        if (!_inMenu)
            _StaminaBar.transform.localScale = new Vector3(_Stamina, 1, 1);

        _MovementSpeed = _StartSpeed;
        transform.Translate(Vector3.forward * _MovementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S) && _Stamina > 0)
        {
            if (!_inMenu)
                _Stamina -= 0.01f;
            _MovementSpeed = _MovementSpeed / 2;
            transform.Translate(Vector3.back * _MovementSpeed * Time.deltaTime);
        } 
        if (Input.GetKey(KeyCode.W) && _Stamina > 0)
        {
            if (!_inMenu)
                _Stamina -= 0.01f;
            _MovementSpeed = _MovementSpeed * 1.5f;
            transform.Translate(Vector3.forward * _MovementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -45, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
        }

    }
}
