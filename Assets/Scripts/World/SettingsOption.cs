using UnityEngine;
using UnityEngine.UI;

public class SettingsOption : MonoBehaviour
{
    public Image settingImage;
    public bool isSelected;
    public GameObject insideSettings;
    public Image[] settings;

    public virtual void Enter()
    {
        isSelected = true;

        ActiveSetting(0);
    }

    public void Exit()
    {
        isSelected = false;

        for (int i=0; i<settings.Length; i++) {
            settings[i].color = Color.grey;
        }
    }

    public void ActiveSetting(int settingNo)
    {
        for (int i = 0; i < settings.Length; i++)
        {
            settings[i].color = Color.grey;
        }

        settings[settingNo].color = Color.white;
    }
}
