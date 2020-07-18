using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public AudioSource audio;
    public float way;
    [SerializeField]
    private GameObject _monsterBallPref;
    Quaternion newRotation;
    private float nextActionTime = 1f;
    private float period = 1f;
    // Start is called before the first frame update
    void Start()
    {
        newRotation = Quaternion.Euler(0f, 0f, way);
    }

    private void Update()
    {
        if (Time.time > nextActionTime)
        {
            GameObject newFireBall = Instantiate(_monsterBallPref, this.transform.position, newRotation);
            audio.Play(); 
            nextActionTime += period;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FireBall" | other.tag == "Player")
        {
            PlayerFire.Kills++;
            Destroy(gameObject);
        }
    }
}
