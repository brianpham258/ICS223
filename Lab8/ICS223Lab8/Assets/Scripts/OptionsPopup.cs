using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Reflection;

public class OptionsPopup : MonoBehaviour
{
    [SerializeField]
    private UIController UIController;
    [SerializeField]
    private SettingsPopup settingsPopup;

    public void Open()
    {
        this.gameObject.SetActive(true);
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    public void OnSettingButton()
    {
        settingsPopup.Open();
        Close();
    }

    public void OnExitButton()
    {
        Type t = null;
        foreach(Assembly a in AppDomain.CurrentDomain.GetAssemblies())
        {
            t = a.GetType("UnityEditor.EditorApplication");
            if (t != null)
            {
                t.GetProperty("isPlaying").SetValue(null, false, null);
                break;
            }
        }
    }

    public void OnReturnToGameButton()
    {
        Close();
        UIController.ResumeGame();
    }

    public bool isActive()
    {
        return this.gameObject.activeSelf;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
