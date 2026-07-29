using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Party : MonoBehaviour
{
    public Character[] currentPartyMembers;
    public List<Character> remainingCharacters;

    public void CharacterUIstoCharacters(CharacterUI[] characters)
    {
       for(int i=0; i<characters.Length; i++)
        {
            if (characters[i] != null)
            {
                currentPartyMembers[i] = characters[i].character;
            }
        }
    }
}
