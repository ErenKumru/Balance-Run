using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Slider levelLengthSlider;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text starText;
    [SerializeField] private TMP_Text gemText;

    [Header("Menu Elements")]
    [SerializeField] private GameObject menuCanvas;


    #region GameplayUIControls


    public void ShowLevel(int level)
    {
        levelText.text = "Level " + level.ToString();
    }

    public void UpdateSlider(float levelCompleteRatio)
    {
        levelLengthSlider.value = levelCompleteRatio;
    }

    public void UpdateStarText(int starAmount)
    {
        starText.text = starAmount.ToString();
    }

    public void UpdateGemText(int gemAmount)
    {
        gemText.text = gemAmount.ToString();
    }

    #endregion

    #region MenuUIControls

    public void OpenMenu()
    {
        Time.timeScale = 0;
        menuCanvas.SetActive(true);
    }

    public void CloseMenu()
    {
        menuCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void DirectToPlayStorePage()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.morarosa.speario3d&hl=en&gl=US");
    }

    public void DirectToOfficialPage()
    {
        Application.OpenURL("https://udogames.com/");
    }

    public void DirectToFacebookPage()
    {
        Application.OpenURL("https://www.facebook.com/udogames/");
    }

    public void DirectToTwitterPage()
    {
        Application.OpenURL("https://twitter.com/udogames/");
    }

    #endregion
}
