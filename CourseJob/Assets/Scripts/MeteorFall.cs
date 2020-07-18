using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFall : MonoBehaviour
{
    public float _Gravity;
    public GameObject _Marker;
    public ParticleSystem _Explosion;
    public ParticleSystem _Fire;
    private Vector3 _GravityDirection;
    private Rigidbody _PlayerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _PlayerRigidbody = gameObject.GetComponent<Rigidbody>();
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity))
        {
            if(hit.collider.gameObject.tag == "Planet")
            {
                GameObject newMarker = Instantiate(_Marker, hit.point, transform.rotation);
                newMarker.transform.parent = GameObject.FindGameObjectWithTag("Finish").transform;
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
            }

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _GravityDirection = (Vector3.zero - transform.position).normalized;
        _PlayerRigidbody.AddForce(_GravityDirection * _Gravity);
    }

    /// <summary>
    /// Функция проверяет столкновение данного игрового объекта с другими
    /// Если столкновение произошло с планетой, то следует воспроизвести анимацию взрыва и удадить объект
    /// Если столкновение произошло с игроком, то следует закончить игру
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            _Explosion.Play();
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            _Fire.Stop();
            Destroy(gameObject,2f);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            _Explosion.Play();
            GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>().GameOver();
            Destroy(gameObject);
        }
    }
}
