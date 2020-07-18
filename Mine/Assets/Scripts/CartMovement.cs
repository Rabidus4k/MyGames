using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartMovement : MonoBehaviour
{

    private Text m_distanceText;

    private int m_distance = 0;
    private float m_cartSpeed;
    private float m_progress;
    private Vector2 m_startPos;

    private LeaderBoard m_leaderBoard;

    private void Start()
    {
        m_leaderBoard = GameObject.FindGameObjectWithTag("LeaderBoard").GetComponent<LeaderBoard>();
        m_distanceText = GameObject.FindGameObjectWithTag("DistanceTextUI").GetComponent<Text>();
        ResetCartMovement();
    }

    private void FixedUpdate()
    {
        m_distanceText.text = $"DISTANCE: {m_distance / 10}";
    }

    public void ResetCartMovement()
    {
        m_leaderBoard = GameObject.FindGameObjectWithTag("LeaderBoard").GetComponent<LeaderBoard>();
        m_leaderBoard.AddNewHighscore(PhotonNetwork.NickName, m_distance / 10);
        m_progress = 0f;
        m_distance = 0;
        m_cartSpeed = 0;
        m_startPos = gameObject.transform.position;
    }

    public int GetDistance()
    {
        return m_distance / 10;
    }

    public bool CartMove(GameObject targetToMove)
    {
        gameObject.transform.position = Vector2.Lerp(m_startPos, targetToMove.transform.position, m_progress);
        m_progress += m_cartSpeed * Time.fixedDeltaTime;
        m_distance++;
        if (gameObject.transform.position == targetToMove.transform.position)
        {
            m_progress = 0;
            m_startPos = gameObject.transform.position;
            return true;
        }

        return false;
    }

    public void SetCartSpeed(float speed)
    {
        m_cartSpeed = speed;
    }

}
