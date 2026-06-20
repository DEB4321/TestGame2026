using UnityEngine;
using UnityEngine.UI;


public class CharacterSettingsUI : MonoBehaviour
{
    public Image[] settings;
    public int currentUISetting;
    private bool selected;

    void Start()
    {
        gameObject.SetActive(false);

        Image[] gottenSettings = GetComponentsInChildren<Image>();

        settings = new Image[gottenSettings.Length - 1];

        for (int i = 1; i <= settings.Length; i++)
        {
            settings[i - 1] = gottenSettings[i];
        }
    }

    public void Select()
    {
        Activate(0);
        currentUISetting = 0;

        if (!selected)
        {
            selected = true;
        }
        gameObject.SetActive(true);
    }

    public void Unselect()
    {
        if (selected)
        {
            selected = false;
        }
        gameObject.SetActive(false);
    }

    public void SettingUp()
    {
        if (currentUISetting - 1 >= 0 && selected)
        {
            currentUISetting--;
            Activate(currentUISetting);
        }
    }

    public void SettingDown()
    {
        if (currentUISetting + 1 < settings.Length && selected)
        {
            currentUISetting++;
            Activate(currentUISetting);
        }
    }

    public void Activate(int charNo)
    {
        for (int i = 0; i < settings.Length; i++)
        {
            settings[i].color = Color.gray;
        }

        settings[currentUISetting].color = Color.white;
    }

    private void OpenEquipment()
    {
        print("No Equipment Yet!");
    }

    private void OpenSkills()
    {
        print("No Skills Yet!");
    }

    private void OpenAbility()
    {
        print("No Ability Yet!");
    }

    private void LeaveParty()
    {
        
    }
}
