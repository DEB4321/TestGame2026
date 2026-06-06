using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    public Character character;
    private Image image;
    private TextMeshProUGUI Name;
    private TextMeshProUGUI HPStat;
    private TextMeshProUGUI strengthStat;
    private TextMeshProUGUI defenseStat;
    private TextMeshProUGUI magicStat;
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
        strengthStat = text[8];
        defenseStat = text[9];
        magicStat = text[10];
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
        HPStat.text = newCharacter.hpStat.ToString();
        strengthStat.text = newCharacter.strengthStat.ToString();
        defenseStat.text = newCharacter.defenseStat.ToString();
        magicStat.text = newCharacter.magicStat.ToString();
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

    public void LeaveParty()
    {
        character = null;
        gameObject.SetActive(false);
    }
}
