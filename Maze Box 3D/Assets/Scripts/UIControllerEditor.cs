using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControllerEditor : MonoBehaviour
{
    #region VARIABLES

    public GameObject GuideMenu;

    #endregion

    #region METHODS

    public void OnGuideClicked()
    {
        GuideMenu.SetActive(true);
    }

    public void OnGuideExetClicked()
    {
        GuideMenu.SetActive(false);
    }

    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }

    #endregion
}
