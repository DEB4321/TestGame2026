using System.Collections.Generic;
using UnityEngine;

public class PartyController : MonoBehaviour
{
    public CharacterUI[] characters = new CharacterUI[4];
    private int currentCharacter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void JoinParty(Character newCharacter)
    {
        for (int i = 1; i < characters.Length; i++)
        {
            if (characters[i].character == null)
            {
                characters[i].JoinParty(newCharacter);
                return;
            }
        }
    }

    public void LeaveParty()
    {
        characters[currentCharacter].LeaveParty();
    }

    public void ReorganizeParty()
    {
        List<Character> holdCharacters = GetCharacters();


        for (int i = 1; i < characters.Length; i++)
        {
            if (holdCharacters[i] == null)
            {
                characters[i].LeaveParty();
                return;
            }

            characters[i].JoinParty(holdCharacters[i]);
        }
    }

    public List<Character> GetCharacters() {
        List<Character> characterData = new List<Character>();

        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].character != null)
            {
                characterData.Add(characters[i].character);
            }
        }

        return characterData;
    }
}
