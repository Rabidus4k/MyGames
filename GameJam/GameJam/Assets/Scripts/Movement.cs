using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(AnimatorController))]
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField]
    private Bar _manaBar;

    [SerializeField]
    private float _jumpSpeed;
    [SerializeField]
    private Transform _spriteTransform;
    [SerializeField]
    private float _moveSpeed;

    private Vector3 _lastPosition;
    private bool _isSecondJumpAllow;
    private AnimatorController _animatorController;
    public bool IsWalking { get; set; }
    public bool OnGround { get; set; }

    private Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        _lastPosition = transform.position;
        _animatorController = GetComponent<AnimatorController>();
        _isSecondJumpAllow = true;
        OnGround = true;
        IsWalking = false;

        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Тот самый поворот
        // вычисляем разницу между текущим положением и положением мыши
        Vector3 difference = mousePosition - transform.position;
        difference.Normalize();

        if (difference.x > 0)
        {
            _spriteTransform.localScale = new Vector3(10, 10, 10);
        }
        else
        {
            _spriteTransform.localScale = new Vector3(-10, 10, 10);
        }

        if (Input.GetKey(KeyCode.D))
        {           
            transform.Translate(_moveSpeed * Time.deltaTime * Vector3.right);
            IsWalking = true;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            IsWalking = false;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_moveSpeed * Time.deltaTime * Vector3.left);
            IsWalking = true; 
            
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            IsWalking = false;
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            IsWalking = false;
        }

        if (transform.position == _lastPosition)
            IsWalking = false;



        if (!OnGround)
            _animatorController.Jump();
        else if (!IsWalking)
            _animatorController.Idle();
        else 
            _animatorController.Walk();


        _lastPosition = transform.position;
    }
    // Update is called once per frame
    private void Update()
    {
 
        if (_rigidbody2D.velocity.y <= 0.01 && _rigidbody2D.velocity.y >= -0.01)
        {
            OnGround = true;
        }
        else
        {
            OnGround = false;
        }

        if (OnGround)
            _isSecondJumpAllow = true;

         

        if (OnGround && Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
        else if (_isSecondJumpAllow && Input.GetKeyDown(KeyCode.W) && _manaBar.currentValue > 15f)
        {
            _manaBar.DecreaseValue(15f);
            Jump();
            _isSecondJumpAllow = false;
        }
    }

    private void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0f);
        _rigidbody2D.AddForce(_jumpSpeed * Vector2.up);
        _animatorController.Jump();
    }
}
