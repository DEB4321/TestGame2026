using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    public Character character;
    public CharacterSettingsUI settingsUI;
    public int currentSetting;
    public GameObject noCharacter;

    private Image image;
    private TextMeshProUGUI Name;
    private TextMeshProUGUI HPStat;
    private TextMeshProUGUI MPStat;
    private TextMeshProUGUI strengthStat;
    private TextMeshProUGUI magicStat;
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
        magicStat = text[10];
        defenseStat = text[11];
        magicDefenseStat = text[12];
        speedStat = text[13];

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
        MPStat.text = $"{newCharacter.currentMP}/{newCharacter.mpStat}";
        strengthStat.text = newCharacter.strengthStat.ToString();
        magicStat.text = newCharacter.magicStat.ToString();
        defenseStat.text = newCharacter.defenseStat.ToString();
        magicDefenseStat.text = newCharacter.magicDefenseStat.ToString();
        speedStat.text = newCharacter.speedStat.ToString();

        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
    }

    public void ChangePrefabColor(Color imageColor)
    {
        if(noCharacter.activeSelf)
        {
            noCharacter.GetComponent<Image>().color = imageColor;
        } else
        {
            gameObject.GetComponent<Image>().color = imageColor;
        }
    }

    public void JoinParty(Character newCharacter)
    {
        character = newCharacter;
        UpdateUI(newCharacter);
        noCharacter.SetActive(false);
    }

    public void LeaveParty(Character blankCharater)
    {
        character = blankCharater;
        UpdateUI(blankCharater);
        noCharacter.SetActive(true);
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
        if(noCharacter.activeSelf)
        {

        }
        else
        {
            settingsUI.Select();
        }
    }

    public void Unselect()
    {
        if(noCharacter.activeSelf)
        {

        } 
        else
        {
            settingsUI.Unselect();
        }
    }

    public int ActivateCharacterSetting()
    {
        return settingsUI.currentUISetting;
    }

    public bool NoCharacterSelected()
    {
        return noCharacter.activeSelf;
    }
}
