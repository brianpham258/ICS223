using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField]
    private OptionsPopup optionsPopup;
    [SerializeField]
    private Slider difficultySlider;
    [SerializeField]
    private Text numEnemiesValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Open()
    {
        this.gameObject.SetActive(true);
        difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    public void OnDifficultyValue(float difficulty)
    {
        numEnemiesValue.text = difficulty.ToString();
    }

    public void OnOKButton()
    {
        PlayerPrefs.SetInt("difficulty", (int)difficultySlider.value);
        Close();
        optionsPopup.Open();
    }

    public void OnCancelButton()
    {
        Close();
        optionsPopup.Open();
    }

    public bool isActive()
    {
        return this.gameObject.activeSelf;
    }
}
