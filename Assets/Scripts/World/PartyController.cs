using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PartyController : MonoBehaviour
{
    public CharacterUI[] characters = new CharacterUI[4];
    public Character blankCharater;
    public int partySize;
    private int currentCharacter;
    private bool entered;
    public bool characterSelected;
    private int maxPartySize = 4;

    public void Activate(int charNo)
    {
        for (int i = 0; i <= characters.Length && i < maxPartySize; i++)
        {
            ChangePrefabColor(i, Color.gray);
        }

        ChangePrefabColor(currentCharacter, Color.white);
    }

    public void Enter()
    {
        if (!entered)
        {
            entered = true;
            Activate(0);
            currentCharacter = 0;
        }
        else if (entered && !characterSelected)
        {
            characterSelected = true;
            characters[currentCharacter].Select();
        }
        else if (entered && characterSelected)
        {
            ActivateCharacterSetting();
        }
    }

    public void Exit()
    {
        if (entered && characterSelected)
        {
            characterSelected = false;
            characters[currentCharacter].Unselect();
        }
        else if (entered && !characterSelected)
        {
            entered = false;

            for (int i = 0; i < characters.Length; i++)
            {
                ChangePrefabColor(i, Color.white);
            }

            currentCharacter = 0;
        }
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
        partySize++;
    }

    public void LeaveParty()
    {
        Exit();
        characters[currentCharacter].LeaveParty();
        ReorganizeParty();
        partySize--;

        if (partySize == currentCharacter)
        {
            currentCharacter--;
            Activate(currentCharacter);
        } else
        {
            Activate(currentCharacter);
        }
    }

    public void ReorganizeParty()
    {
        List<Character> holdCharacters = GetCharacters();

        for (int i = 1; i < characters.Length - 1; i++)
        {
            characters[i].JoinParty(holdCharacters[i]);
        }

        characters[characters.Length-1].LeaveParty(blankCharater);
    }

    public List<Character> GetCharacters()
    {
        List<Character> characterData = new List<Character>();

        foreach (CharacterUI character in characters)
        {
            if (character.character != null)
            {
                characterData.Add(character.character);
            }
        }

        return characterData;
    }

    public void ChangePrefabColor(int charNo, Color imageColor)
    {
        characters[charNo].ChangePrefabColor(imageColor);
    }

    public void CharacterMenuMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 input = context.ReadValue<Vector2>();

            if (entered && characterSelected)
            {
                if (input.y > 0)
                {
                    if(characters[currentCharacter].NoCharacterSelected())
                    {

                    } else
                    {
                        characters[currentCharacter].SettingUp();
                    }
                }

                if (input.y < 0)
                {
                    if(characters[currentCharacter].NoCharacterSelected())
                    {

                    }
                    else
                    {
                        characters[currentCharacter].SettingDown();
                    }
                }
            }
            else if (entered)
            {
                if (input.x > 0 && currentCharacter + 1 <= partySize && currentCharacter + 1 < maxPartySize)
                {
                    currentCharacter++;
                    Activate(currentCharacter);
                }

                if (input.x < 0 && currentCharacter > 0)
                {
                    currentCharacter--;
                    Activate(currentCharacter);
                }
            }
        }
    }

    public void ActivateCharacterSetting()
    {
        switch (characters[currentCharacter].ActivateCharacterSetting())
        {
            case 0:
                OpenEquipment();
                break;
            case 1:
                OpenSkills();
                break;
            case 2:
                OpenAbility();
                break;
            case 3:
                LeaveParty();
                break;
        }

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
}
