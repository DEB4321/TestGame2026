using UnityEngine;
using UnityEngine.InputSystem;

public class TextSpeedSettings : SettingsOption
{
    public float[] textSpeedOptions;
    public float currentTextSpeed;
    public int currentTextSpeedSetting;

    public override void Enter()
    {
        base.Enter();
        isSelected = true;

        ActiveSetting(currentTextSpeedSetting);
    }

    public void Select(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            currentTextSpeed = textSpeedOptions[currentTextSpeedSetting];
        }
    }

    public void ChangeSettingDown(InputAction.CallbackContext context)
    {
        if (context.started == true && isSelected == true)
        {
            currentTextSpeedSetting++;

            if (currentTextSpeedSetting >= settings.Length)
            {
                currentTextSpeedSetting = 0;
            }

            ActiveSetting(currentTextSpeedSetting);
        }
    }

    public void ChangeSettingUp(InputAction.CallbackContext context)
    {
        if (context.started == true && isSelected == true)
        {
            currentTextSpeedSetting--;

            if (currentTextSpeedSetting < 0)
            {
                currentTextSpeedSetting = settings.Length - 1;
            }

            ActiveSetting(currentTextSpeedSetting);
        }
    }
}
