using UnityEngine;
using UnityEngine.InputSystem;

public class SaveSettings : SettingsOption
{
    private int currentSaveSetting = 0;

    public void SaveOrLoad(InputAction.CallbackContext context)
    {
        if (context.started == true && isSelected)
        {
            if (currentSaveSetting == 0)
            {
                FindAnyObjectByType<SaveController>().SaveGame();
            }
            else if (currentSaveSetting == 1)
            {
                return;
            }
        }
    }
    
    public void ChangeSettingDown(InputAction.CallbackContext context)
    {
        if (context.started == true && isSelected)
        {
            currentSaveSetting++;

            if (currentSaveSetting >= settings.Length)
            {
                currentSaveSetting = 0;
            }

            ActiveSetting(currentSaveSetting);
        }
    }

    public void ChangeSettingUp(InputAction.CallbackContext context)
    {
        if (context.started == true && isSelected)
        {
            currentSaveSetting--;

            if (currentSaveSetting < 0)
            {
                currentSaveSetting = settings.Length - 1;
            }

            ActiveSetting(currentSaveSetting);
        }
    }
}
