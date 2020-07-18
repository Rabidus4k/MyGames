using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{
    public GameObject d1;
    public GameObject d2;
    public TextMeshProUGUI t1;
    public TextMeshProUGUI t2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Dialogue");
    }

    IEnumerator Dialogue()
    {
        d1.SetActive(false);
        d2.SetActive(false);

        yield return new WaitForSeconds(1f);

        d1.SetActive(true);
        t1.SetText("What is going on!?");

        yield return new WaitForSeconds(2f);

        d1.SetActive(false);
        d2.SetActive(true);
        t2.SetText("We are out of food");

        yield return new WaitForSeconds(2f);

        d1.SetActive(true);
        d2.SetActive(false);
        t1.SetText("so what?..");

        yield return new WaitForSeconds(2f);

        d1.SetActive(false);
        d2.SetActive(true);
        t2.SetText("You must DIE !!");

        yield return new WaitForSeconds(1f);
        FadeInOut.sceneEnd = true;
    }
}
