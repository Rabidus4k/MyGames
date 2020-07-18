using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshPro m_scoreText;
    public static int m_score;

    private PlayerController m_playerController;
    private PhotonView m_photonView;

    private void Start()
    {
        m_score = 0;
        m_photonView = GetComponent<PhotonView>();

        m_playerController = GetComponent<PlayerController>();
        StartCoroutine("ScoreAdder");
    }

    IEnumerator ScoreAdder()
    {
        yield return new WaitForSeconds(1f);

        m_score++;
        SetScore();
        StartCoroutine("ScoreAdder");
    }

    void SetScore()
    {
        m_scoreText.SetText($"SCORE: {m_score}");
    }
}
