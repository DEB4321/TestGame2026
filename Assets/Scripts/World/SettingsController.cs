using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    private bool entered = false;
    private int currentSetting = 0;
    public SettingsOption[] settings;

    void Start()
    {
        for (int i = 0; i < settings.Length; i++)
        {
            settings[i].settingImage.color = Color.grey;

            for (int j = 0; j < settings[i].settings.Length; j++)
            {
                settings[i].settings[j].color = Color.grey;
            }

            settings[i].insideSettings.SetActive(false);
        }
    }

    public void Enter(InputAction.CallbackContext context)
    {
        if (context.started == true && entered == false)
        {
            entered = true;

            ActiveSetting(0);
        }
        else if (context.started == true && settings[currentSetting].isSelected == false)
        {
            settings[currentSetting].Enter();
        }
    }

    public void Exit(InputAction.CallbackContext context)
    {
        if (context.started == true && entered == true && settings[currentSetting].isSelected == false)
        {
            entered = false;

            settings[currentSetting].settingImage.color = Color.grey;
        }
        else if (context.started == true && settings[currentSetting].isSelected == true)
        {
            settings[currentSetting].Exit();
        }
    }

    public void Exit()
    {
        entered = false;

        settings[currentSetting].settingImage.color = Color.grey;

        settings[currentSetting].Exit();
    }

    public void ActiveSetting(int settingNo)
    {
        for (int i = 0; i < settings.Length; i++)
        {
            settings[i].settingImage.color = Color.grey;
            settings[i].insideSettings.SetActive(false);
        }

        settings[settingNo].settingImage.color = Color.white;
        settings[settingNo].insideSettings.SetActive(true);
    }

    public void ChangeSettingDown(InputAction.CallbackContext context)
    {
        if (context.started == true && entered == true && settings[currentSetting].isSelected == false)
        {
            currentSetting++;

            if (currentSetting >= settings.Length)
            {
                currentSetting = 0;
            }

            ActiveSetting(currentSetting);
        }
    }

    public void ChangeSettingUp(InputAction.CallbackContext context)
    {
        if (context.started == true && entered == true && settings[currentSetting].isSelected == false)
        {
            currentSetting--;

            if (currentSetting < 0)
            {
                currentSetting = settings.Length - 1;
            }

            ActiveSetting(currentSetting);
        }
    }
}
