using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region VARIABLES

    //Считает кол-во закрашенных блоков, чтобы сравнить с кол-вом блоков на текущей карте
    //Если они одинаковы, то карта меняется на следующую
    public static int _CountOfSteps = 0;

    //Определяет, находится ли персонаж в режиме редактора карт,
    //Если да, то не нужно менять карту, когда все блоки закрашены
    public bool _InEditor = false;

    private float _StartSpeed = 50f;
    private float _MovementSpeed;

    //Определяет, можно ли сейчас поменять направление
    //Используется, чтобы нельзя было менять направление, пока движение не закончится
    private bool _CanCangeDirection = true;

    private Vector3 _MoveDirection = Vector3.zero;

    //Отслеживает свайпы по экрану
    //Используется, чтобы определить направление движения персонажа
    private SwipeManager _Sm;

    #endregion

    #region METHODS

    private void Start()
    {
        _Sm = GameObject.FindGameObjectWithTag("SwipeManager").GetComponent<SwipeManager>();
        _MovementSpeed = _StartSpeed;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        Ray ray1 = new Ray(transform.position, Vector3.forward);
        Ray ray2 = new Ray(transform.position, Vector3.back);
        Ray ray3 = new Ray(transform.position, Vector3.left);
        Ray ray4 = new Ray(transform.position, Vector3.right);

        if (_CanCangeDirection)
        {
            switch (_Sm.SwipeDirection)
            {
                case 1:
                    {
                        if (!Physics.Raycast(ray1, out hit, .6f))
                        {
                            PrepareToMove();
                            _MoveDirection = Vector3.forward;
                        }
                    }
                    break;
                case 2:
                    {
                        if (!Physics.Raycast(ray4, out hit, .6f))
                        {
                            PrepareToMove();
                            _MoveDirection = Vector3.right;
                        }
                    }
                    break;
                case 3:
                    {
                        if (!Physics.Raycast(ray2, out hit, .6f))
                        {
                            _MoveDirection = Vector3.back;
                            PrepareToMove();
                        }
                    }
                    break;
                case 4:
                    {
                        if (!Physics.Raycast(ray3, out hit, .6f))
                        {
                            _MoveDirection = Vector3.left;
                            PrepareToMove();
                        }
                    }
                    break;
            }
        }

        Ray ray = new Ray(transform.position, _MoveDirection);
        Debug.DrawRay(ray.origin, _MoveDirection);

        if (Physics.Raycast(ray, out hit, .55f))
        {
            _MovementSpeed = 0;
            _MoveDirection = Vector3.zero;
            _CanCangeDirection = true;
        }
        if (!_CanCangeDirection)
            transform.position += _MoveDirection * _MovementSpeed * Time.fixedDeltaTime;
        else
            RoundUp();
    }

    /// <summary>
    /// Подготовка персонажа к началу движения
    /// </summary>
    private void PrepareToMove()
    {
        _MovementSpeed = _StartSpeed;
        _Sm.SwipeDirection = 0;
        _CanCangeDirection = false;
    }

    /// <summary>
    /// Округление текущего положения персонажа до целых
    /// </summary>
    private void RoundUp()
    {
        Vector3 result = new Vector3();

        result.x = (float)System.Math.Round(transform.position.x);
        result.y = transform.position.y;
        result.z = (float)System.Math.Round(transform.position.z);

        transform.position = result;
    }

    #endregion

    #region COLLISSONS

    /// <summary>
    /// Обработка вхождения персонажа в какой-либо триггер
    /// </summary>
    /// <param name="other">Объект, которому принадлежит триггер</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CellTrigger") && !other.gameObject.transform.GetChild(0).gameObject.active)
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            if (_InEditor)
                return;
            Debug.Log(_CountOfSteps);
            _CountOfSteps++;
            if (_CountOfSteps == LevelGenetaror.Steps() )
            {
                _MoveDirection = Vector3.zero;
                _Sm.SwipeDirection = 0;
                _MovementSpeed = _StartSpeed;
                _CanCangeDirection = true;
                LevelGenetaror.ChangeMap();
            }
        }
    }

    #endregion
}
