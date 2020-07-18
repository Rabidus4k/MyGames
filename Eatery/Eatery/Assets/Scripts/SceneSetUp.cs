using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSetUp : MonoBehaviour
{
    public GameObject car;
    public GameObject Dialogue;
    public GameObject Point;
    private void Start()
    {
        Dialogue.SetActive(false);
        LeanTween.move(car, Point.transform.position, 2f).setOnComplete(ShowDialogue);
    }
    private void ShowDialogue()
    {
        Dialogue.SetActive(true);
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(1);
    }

}
