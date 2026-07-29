using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterFightUI : MonoBehaviour
{
    public Character character;
    public Image charImage;
    public Image hpBar;
    public Image mpBar;
    public TextMeshProUGUI hpAmount;
    public TextMeshProUGUI mpAmount;
    public TextMeshProUGUI Name;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*charImage.sprite = character.dialogueSprite;
        hpAmount.text = $"{character.currentHP}/{character.hpStat}";
        mpAmount.text = $"{character.currentMP}/{character.mpStat}";
        Name.text = character.Name;*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCharacter(Character newCharacter)
    {
        character = newCharacter;
        UpdateCharacterUI();
    }

    public void UpdateCharacterUI()
    {
        charImage.sprite = character.dialogueSprite;
        hpAmount.text = $"{character.currentHP}/{character.hpStat}";
        mpAmount.text = $"{character.currentMP}/{character.mpStat}";
        Name.text = character.Name;
    }
}
