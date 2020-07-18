using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum Sides
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

public class Move : MonoBehaviour
{
    #region VARS

    public GameObject backGround;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private GameObject _bubble;
    [SerializeField]
    private TextMeshProUGUI _bubbleText;
    [SerializeField]
    private GameObject _waiter;
    [SerializeField]
    private GameObject _podnos;
    private int glitchCount = 0;
    private bool InTakeOffZone = false;
    private Sides _currentSide;
    private Vector3 _lastPosition;
    private bool IsCaringFood = false;

    private bool isTutorial = true;
    #endregion

    private void Start()
    {
        _lastPosition = transform.position;
        _currentSide = Sides.RIGHT;
        StartCoroutine(Cicle(25f));
    }

    private void Update()
    {

        if (InTakeOffZone && Input.GetKeyDown(KeyCode.E) )
        {
            if (Slot.Count == 0)
            {
                _bubbleText.text = string.Empty;
                StartCoroutine(PrintText("Food is not ready yet!"));
            }
            else if (!IsCaringFood)
            {
                IsCaringFood = true;
                _bubble.SetActive(false);
                _bubbleText.text = string.Empty;
                GameObject food = FoodController.TakeFood();
                Instantiate(food, _podnos.transform);
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            MoveSomewhere(Sides.UP);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveSomewhere(Sides.DOWN);
        }
        
        if (Input.GetKey(KeyCode.A))
        {

            MoveSomewhere(Sides.LEFT);
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            
            MoveSomewhere(Sides.RIGHT);
        }

        if (transform.position == _lastPosition)
            _animator.Play("Idle 0");

        _lastPosition = transform.position;
    }
    private IEnumerator Cicle(float time)
    {
        yield return new WaitForSecondsRealtime(time + 0.5f);
        switch (glitchCount)
        {
            case 0:
                StartCoroutine(PrintText("What was that???"));
                break;
            case 1:
                StartCoroutine(PrintText("Again!"));
                break;
            case 2:
                StartCoroutine(PrintText("I'm definitely sick!!"));
                break;
            case 3:
                StartCoroutine(PrintText("I went over with vodka yesterday"));
                break;
            case 4:
                StartCoroutine(PrintText("I'm afraid"));
                break;
            case 5:
                StartCoroutine(PrintText("..."));
                break;
            case 6:
                StartCoroutine(PrintText("Is it a joke, where is the camera???"));
                break;
            case 7:
                StartCoroutine(PrintText("..."));
                break;
        }
        glitchCount++;
        
        if (time > 0.5f)
            StartCoroutine(Cicle(time * 0.6f));
        else
        {
            _bubble.SetActive(false);
            StopAllCoroutines();
        }
    }
    private void MoveSomewhere(Sides side)
    {
        _animator.Play("Walk");

        switch (side) 
        {
            case (Sides.UP):
                transform.Translate(Vector3.up * Time.deltaTime * _speed);
                break;
            case (Sides.DOWN):
                transform.Translate(Vector3.down * Time.deltaTime * _speed);
                break;
            case (Sides.LEFT):
                Turn(Sides.LEFT);
                transform.Translate(Vector3.left * Time.deltaTime * _speed);
                break;
            case (Sides.RIGHT):
                Turn(Sides.RIGHT);
                transform.Translate(Vector3.right * Time.deltaTime * _speed);
                break;
        }
    }

    private void Turn(Sides side)
    {
        _animator.Play("Walk");

        if  (side == _currentSide)
            return;

        _currentSide = side;
        if (side == Sides.RIGHT)
        {
            _waiter.transform.localScale = new Vector3(100, 100, 100);
        }
        else
        {
            _waiter.transform.localScale = new Vector3(-100, 100, 100);
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TakeOff"))
            InTakeOffZone = false;

        _bubble.SetActive(false);
        _bubbleText.text = string.Empty;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("City0") || collision.CompareTag("City1") || collision.CompareTag("City2"))
        {
            if (!IsCaringFood)
                return;

            IsCaringFood = false;
            collision.gameObject.GetComponent<City>().Eat();
            Destroy(_podnos.transform.GetChild(0).gameObject);
        }

        if (collision.CompareTag("Closed"))
        {
            _bubble.SetActive(false);
            _bubbleText.text = string.Empty;
            StartCoroutine(PrintText("Closed!"));
        }

        if (collision.CompareTag("TakeOff"))
        {
            InTakeOffZone = true;
            if (!isTutorial)
                return;

            _bubble.SetActive(false);
            _bubbleText.text = string.Empty;
            StartCoroutine(PrintText("Press 'E' to take food!"));
            isTutorial = false; 
        }

        if (collision.CompareTag("Alco"))
        {
            float rand = Random.Range(0.0f, 1.0f);
            if (rand > 0.6f) 
            {
                StartCoroutine(PrintText("Too Expensive for me :("));
            }
        }

        if (collision.CompareTag("Door"))
        {
            FadeInOut.sceneEnd = true;
        }
    }

    private IEnumerator PrintText(string str)
    {
        _bubble.SetActive(true);
        _bubbleText.text = str;

        yield return null;
    }
}
