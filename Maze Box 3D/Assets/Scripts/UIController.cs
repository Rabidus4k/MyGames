using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    #region VARIABLES

    public GameObject mainMenu;
    public GameObject settingMenu;
    public GameObject workShopMenu;
    public GameObject slideMenu;

    private Animator slideMenuAnimator;

    #endregion

    #region METHODS

    private void Start()
    {
        slideMenuAnimator = slideMenu.GetComponent<Animator>();
    }

    public void OnStartGameClicked()
    {
        mainMenu.SetActive(false);
    }

    public void OnWorkshopClicked()
    {
        workShopMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OnWorkshopExitClicked()
    {
        workShopMenu.SetActive(false);
    }

    public void OnMainMenuClicked()
    {
        mainMenu.SetActive(true);
        OnSlideMenuClicked();
    }

    public void OnSettingClicked()
    {
        settingMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void OnSettingCloseClicked()
    {
        settingMenu.SetActive(false);
    }

    public void OnEditorEnter()
    {
        SceneManager.LoadScene(1);
    }

    public void OnSlideMenuClicked()
    {
        if (slideMenuAnimator.GetBool("showMenu"))
        {
            slideMenuAnimator.SetBool("showMenu", false);
        }
        else
        {
            StopCoroutine("CloseMenu");
            slideMenuAnimator.SetBool("showMenu", true);
            StartCoroutine("CloseMenu");
        }
    }

    public void GoToColorScene()
    {
        SceneManager.LoadScene(2);
    }

    #endregion

    #region IENUMERATORS

    IEnumerator CloseMenu()
    {
        yield return new WaitForSeconds(4f);
        if (slideMenuAnimator.GetBool("showMenu"))
        {
            slideMenuAnimator.SetBool("showMenu", false);
        }
    }

    #endregion
}
