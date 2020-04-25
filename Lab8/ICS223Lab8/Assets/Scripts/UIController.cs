using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private int score;
    [SerializeField]
    private Text scoreValue;
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private OptionsPopup optionsPopup;
    [SerializeField]
    private SettingsPopup settingsPopup;
    [SerializeField]
    private Image crossHair;

    // Start is called before the first frame update
    void Start()
    {
        optionsPopup.Close();
        settingsPopup.Close();
        score = 0;
        scoreValue.text = score.ToString();
        healthBar.fillAmount = 1;
        healthBar.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !optionsPopup.isActive() && !settingsPopup.isActive())
        {
            PauseGame();
            optionsPopup.Open();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        crossHair.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        crossHair.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
