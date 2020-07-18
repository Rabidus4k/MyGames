using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] m_Keys;
    [SerializeField] private GameObject m_Finger;
    [SerializeField] private TextMeshProUGUI text;

    private bool[] isPressedkey = new bool[75];
    private Renderer[] renderers = new Renderer[75];
    public static float Delta = 10f;
    private Color startColor;
    float stime = 3f;
    enum Keys
    {
        ESC,
        F1,
        F2,
        F3,
        F4,
        F5,
        F6,
        F7,
        F8,
        F9,
        F10,
        F11,
        F12,
        DEL,
        TILDE,
        K1,
        K2,
        K3,
        K4,
        K5,
        K6,
        K7,
        K8,
        K9,
        K0,
        KMINUSE,
        KPLUS,
        BACKSPACE,
        TAB,
        Q,
        W,
        E,
        R,
        T,
        Y,
        U,
        I,
        O,
        P,
        LBR,
        RBR,
        BACKSLASH,
        CAPS,
        A,
        S,
        D,
        F,
        G,
        H,
        J,
        K,
        L,
        DOUBLEPOINS,
        COV,
        ENTER,
        SHIFT,
        Z,
        X,
        C,
        V,
        B,
        N,
        M,
        KESS,
        MORE,
        QUEST,
        ARROWUP,
        LCTRL,
        LALT,
        SPACE,
        RALT,
        RCTRL,
        ARROWLEFT,
        ARROWDOWN,
        ARROWRIGHT
    }

    private void Start()
    {
        for(int i = 0; i < m_Keys.Length; i++)
        {
            renderers[i] = m_Keys[i].GetComponent<Renderer>();
        }
        startColor = renderers[0].material.color;

        StartCoroutine("Yield");
        StartCoroutine("StartGame");

    }

    IEnumerator Yield()
    {
        yield return new WaitForSeconds(1);
        text.SetText($"SPAWN RATE: {stime}");
        stime -= 0.1f;
        StartCoroutine("Yield");
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(stime);
        
        int randomKeyPicker = Random.Range(0, m_Keys.Length);
        renderers[randomKeyPicker].material.color = new Color(2, 1, 1);
        isPressedkey[randomKeyPicker] = true;
        StartCoroutine("StartGame");
    }

    private void CheckKey(int keyCode)
    {
        SpawnFingerOfDeath(m_Keys[keyCode]);
        isPressedkey[keyCode] = false;
        renderers[keyCode].material.color = startColor;
    }

    private void Update()
    {
        #region KEYS
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CheckKey((int)Keys.ESC);
        }
        else if (Input.GetKeyDown(KeyCode.F1))
        {
            CheckKey((int)Keys.F1);
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            CheckKey((int)Keys.F2);
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            CheckKey((int)Keys.F3);
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            CheckKey((int)Keys.F4);
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            CheckKey((int)Keys.F5);
        }
        else if (Input.GetKeyDown(KeyCode.F6))
        {
            CheckKey((int)Keys.F6);
        }
        else if (Input.GetKeyDown(KeyCode.F7))
        {
            CheckKey((int)Keys.F7);
        }
        else if (Input.GetKeyDown(KeyCode.F8))
        {
            CheckKey((int)Keys.F8);
        }
        else if (Input.GetKeyDown(KeyCode.F9))
        {
            CheckKey((int)Keys.F9);
        }
        else if (Input.GetKeyDown(KeyCode.F10))
        {
            CheckKey((int)Keys.F10);
        }
        else if (Input.GetKeyDown(KeyCode.F11))
        {
            CheckKey
                (
                    (int)Keys.F11
                );
        }
        else if (Input.GetKeyDown(KeyCode.F12))
        {
            CheckKey
                (
                    (int)Keys.F12
                );
        }
        else if (Input.GetKeyDown(KeyCode.Delete))
        {
            CheckKey
                (
                    (int)Keys.DEL
                );
        }
        else if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            CheckKey
                (
                    (int)Keys.TILDE
                );
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CheckKey
                (
                    (int)Keys.K1
                );
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CheckKey
                (
                    (int)Keys.K2
                );
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CheckKey
                (
                    (int)Keys.K3
                );
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CheckKey
                (
                    (int)Keys.K4
                );
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            CheckKey
                (
                    (int)Keys.K5
                );
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            CheckKey
                (
                    (int)Keys.K6
                );
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            CheckKey
                (
                    (int)Keys.K7
                );
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            CheckKey
                (
                    (int)Keys.K8
                );
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            CheckKey
                (
                    (int)Keys.K9
                );
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            CheckKey
                (
                    (int)Keys.K0
                );
        }
        else if (Input.GetKeyDown(KeyCode.Equals))
        {
            CheckKey
                (
                    (int)Keys.KPLUS
                );
        }
        else if (Input.GetKeyDown(KeyCode.Minus))
        {
            CheckKey
                (
                    (int)Keys.KMINUSE
                );
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            CheckKey
                (
                    (int)Keys.BACKSPACE
                );
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            CheckKey
                (
                    (int)Keys.TAB
                );
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            CheckKey
                (
                    (int)Keys.Q
                );
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            CheckKey
                (
                    (int)Keys.W
                );
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            CheckKey
                (
                    (int)Keys.E
                );
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            CheckKey
                (
                    (int)Keys.R
                );
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            CheckKey
                (
                    (int)Keys.T
                );
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            CheckKey
                (
                    (int)Keys.Y
                );
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            CheckKey
                (
                    (int)Keys.U
                );
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            CheckKey
                (
                    (int)Keys.I
                );
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            CheckKey
                (
                    (int)Keys.O
                );
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            CheckKey
                (
                    (int)Keys.P
                );
        }
        else if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            CheckKey
                (
                    (int)Keys.LBR
                );
        }
        else if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            CheckKey
                (
                    (int)Keys.RBR
                );
        }
        else if (Input.GetKeyDown(KeyCode.Backslash))
        {
            CheckKey
                (
                    (int)Keys.BACKSLASH
                );
        }
        else if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            CheckKey
                (
                    (int)Keys.CAPS
                );
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            CheckKey
                (
                    (int)Keys.A
                );
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            CheckKey
                (
                    (int)Keys.S
                );
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            CheckKey
                (
                    (int)Keys.D
                );
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            CheckKey
                (
                    (int)Keys.F
                );
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            CheckKey
                (
                    (int)Keys.G
                );
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            CheckKey
                (
                    (int)Keys.H
                );
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            CheckKey
                (
                    (int)Keys.J
                );
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            CheckKey
                (
                    (int)Keys.K
                );
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            CheckKey
                (
                    (int)Keys.S
                );
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            CheckKey
                (
                    (int)Keys.L
                );
        }
        else if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            CheckKey
                (
                    (int)Keys.DOUBLEPOINS
                );
        }
        else if (Input.GetKeyDown(KeyCode.Quote))
        {
            CheckKey
                (
                    (int)Keys.COV
                );
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckKey
                (
                    (int)Keys.ENTER
                );
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            CheckKey
                (
                    (int)Keys.SHIFT
                );
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            CheckKey
                (
                    (int)Keys.Z
                );
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            CheckKey
                (
                    (int)Keys.X
                );
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            CheckKey
                (
                    (int)Keys.C
                );
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            CheckKey
                (
                    (int)Keys.V
                );
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            CheckKey
                (
                    (int)Keys.B
                );
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            CheckKey
                (
                    (int)Keys.N
                );
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            CheckKey
                (
                    (int)Keys.M
                );
        }
        else if (Input.GetKeyDown(KeyCode.Comma))
        {
            CheckKey
                (
                    (int)Keys.KESS
                );
        }
        else if (Input.GetKeyDown(KeyCode.Period))
        {
            CheckKey
                (
                    (int)Keys.MORE
                );
        }
        else if (Input.GetKeyDown(KeyCode.Slash))
        {
            CheckKey
                (
                    (int)Keys.QUEST
                );
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CheckKey
                (
                    (int)Keys.ARROWUP
                );
        }
        else if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            CheckKey
                (
                    (int)Keys.RALT
                );
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            CheckKey
                (
                    (int)Keys.LCTRL
                );
        }
        
        else if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            CheckKey
                (
                    (int)Keys.LALT
                );
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckKey
                (
                    (int)Keys.SPACE
                );
        }   
        else if (Input.GetKeyDown(KeyCode.RightControl))
        {
            CheckKey
                (
                    (int)Keys.RCTRL
                );
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CheckKey
                (
                    (int)Keys.ARROWLEFT
                );
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CheckKey
                (
                    (int)Keys.ARROWDOWN
                );
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CheckKey
                (
                    (int)Keys.ARROWRIGHT
                );
        }
        #endregion
    }

    private void SpawnFingerOfDeath(GameObject target)
    {
        float x = target.transform.position.x;
        float y = target.transform.position.y;
        Instantiate(m_Finger, new Vector3(x, y + Delta), Quaternion.identity);
    }
}
