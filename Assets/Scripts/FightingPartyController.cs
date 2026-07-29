using UnityEngine;

public class FightingPartyController : MonoBehaviour
{
    public CharacterFightUI[] partyCharacters;
    private Party party;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        party = FindAnyObjectByType<Party>();
        partyCharacters = FindObjectsByType<CharacterFightUI>();

        for (int i=0; i < partyCharacters.Length; i++)
        {
            partyCharacters[i].ChangeCharacter(party.currentPartyMembers[i]);
        }
    }

    
}
