using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerMovement : MonoBehaviour
{
    private PhotonView m_PhotonView;
    private Rigidbody m_rigidbody;

    private float m_speed = 10f;
    private float m_jumpSpeed = 10f;
    private float m_fallMultiplier = 5f;
    private float m_lowJumpMultiplier = 2f;

    public float Speed { set { m_speed = value; } }
    private void Start()
    {
        m_rigidbody = gameObject.GetComponent<Rigidbody>();
        m_PhotonView = gameObject.GetComponent<PhotonView>();
    }

    private void FixedUpdate()
    {
        if (m_PhotonView.IsMine)
        {
            ApplyGravity();
            float dirX = Input.GetAxis("Horizontal");
            float dirY = Input.GetAxis("Vertical");

            transform.Translate(new Vector3(dirX * m_speed * Time.deltaTime, 0, dirY * m_speed * Time.deltaTime));

        }
    }

    public void Jump()
    {
        m_rigidbody.velocity = m_jumpSpeed * Vector3.up;
    }

    private void ApplyGravity()
    {
        if (m_rigidbody.velocity.y < 0)
        {
            m_rigidbody.velocity += Vector3.up * Physics.gravity.y * (m_fallMultiplier - 1) * Time.deltaTime;
        }
        else
        {
            if (m_rigidbody.velocity.y > 0)
            {
                m_rigidbody.velocity += Vector3.up * Physics.gravity.y * (m_lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
    }
}
