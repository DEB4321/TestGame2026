using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    public Character character;
    public CharacterSettingsUI settingsUI;
    public int currentSetting;
    private Image image;
    private TextMeshProUGUI Name;
    private TextMeshProUGUI HPStat;
    private TextMeshProUGUI MPStat;
    private TextMeshProUGUI strengthStat;
    private TextMeshProUGUI defenseStat;
    private TextMeshProUGUI magicDefenseStat;
    private TextMeshProUGUI speedStat;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Image[] images = GetComponentsInChildren<Image>();
        image = images[1];
        TextMeshProUGUI[] text = GetComponentsInChildren<TextMeshProUGUI>();
        Name = text[0];
        HPStat = text[7];
        MPStat = text[8];
        strengthStat = text[9];
        defenseStat = text[10];
        magicDefenseStat = text[11];
        speedStat = text[12];

        if (character != null)
        {
            UpdateUI(character);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void UpdateUI(Character newCharacter)
    {
        image.sprite = newCharacter.sprite;
        Name.text = newCharacter.Name;
        HPStat.text = $"{newCharacter.currentHP}/{newCharacter.hpStat}";
        MPStat.text = $"{newCharacter.currentMP}/{newCharacter.MPStat}";
        strengthStat.text = newCharacter.strengthStat.ToString();
        defenseStat.text = newCharacter.defenseStat.ToString();
        magicDefenseStat.text = newCharacter.magicDefenseStat.ToString();
        speedStat.text = newCharacter.speedStat.ToString();

        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
    }

    public void JoinParty(Character newCharacter)
    {
        character = newCharacter;
        UpdateUI(newCharacter);
    }

    public void LeaveParty(Character blankCharater)
    {
        character = blankCharater;
        UpdateUI(blankCharater);
    }

    public void LeaveParty()
    {
        character = null;
    }

    public void SettingUp()
    {
        settingsUI.SettingUp();
    }

    public void SettingDown()
    {
        settingsUI.SettingDown();
    }

    public void Select()
    {
        settingsUI.Select();
    }

    public void Unselect()
    {
        settingsUI.Unselect();
    }

    public int ActivateCharacterSetting()
    {
        return settingsUI.currentUISetting;
    }
}
