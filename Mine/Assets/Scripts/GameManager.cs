using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject m_lobby;
    [SerializeField] private GameObject m_game;
    [SerializeField] private GameObject m_lobbySpawn;
    [SerializeField] private GameObject m_gameSpawn;
    [SerializeField] private GameObject m_gameStart;

    [SerializeField] private Text m_bestScoreText;

    private GameObject m_cart;
    private CartMovement m_cm;
    private PathBuilder m_pb;
    static GameManager instance;

    private void Start()
    {
        instance = this;
        m_cart = GameObject.FindGameObjectWithTag("Cart");
        m_cm = m_cart.GetComponent<CartMovement>();
        m_pb = GameObject.FindGameObjectWithTag("Game").GetComponent<PathBuilder>();

        RestartGame();
    }

    public static void SetTime(float timeScalse)
    {
        Time.timeScale = timeScalse;
    }

    public void RestartGame()
    {
        m_cart.transform.position = m_gameStart.transform.position;
        
        m_cm.ResetCartMovement();
        m_pb.PreparePathBuilder();   
    }

    public void EnterLobby(GameObject player)
    {
        RestartGame();
        player.transform.position = m_lobbySpawn.transform.position;
    }

    public void ExitLobby(GameObject player)
    {
        player.transform.position = m_gameSpawn.transform.position;
    }
}
