using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject losePanel;

    [Header("Knife Count")]
    [SerializeField]
    private GameObject knivesIconPanel;
    [SerializeField]
    private GameObject knifeIcon;
    [SerializeField]
    private Color usedKnifeIconColor;

    [Header("Level UP")]
    [SerializeField] private GameObject successPanel;

    private int knifeIconIndexToChange = 0;

    public void ShowLosePanel()
    {
        Time.timeScale = 0;
        losePanel.SetActive(true);
    }

    public void SetInitialDisplayedKnifeIconCount(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(knifeIcon, knivesIconPanel.transform);
        }
    }

    public void DecreaseDisplayedKnifeIcon()
    {
        knivesIconPanel.transform.GetChild(knifeIconIndexToChange++)
            .GetComponent<Image>().color = usedKnifeIconColor;
    }

    public void RestartGame()//This will be used from Restart Button
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public void ShowSuccessPanel()
    {
        Invoke("InvokeShowSuccesPanel", 0.3f);
    }
    private void InvokeShowSuccesPanel() => successPanel.SetActive(true);

    public void NextLevelButtonClicked()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        buildIndex++;
        SceneManager.LoadScene(buildIndex, LoadSceneMode.Single);
    }

}
