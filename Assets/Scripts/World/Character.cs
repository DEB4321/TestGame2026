using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character")]
public class Character : ScriptableObject
{
    public Sprite mainSprite;
    public Sprite dialogueSprite;
    public string Name;
    public int currentHP;
    public int hpStat;
    public int currentMP;
    public int mpStat;
    public int strengthStat;
    public int magicStat;
    public int defenseStat;
    public int magicDefenseStat;
    public int speedStat;

    public void LevelUp()
    {

    }

    public void LoseHP(int loss)
    {
        currentHP -= loss;
        
        if(currentHP <= 0) currentHP = 0;
    }

    public void GainHP(int gain)
    {       
        currentHP += gain;

        if(currentHP >= hpStat) currentHP = hpStat;
    }

    public void LoseMP(int loss)
    {
        currentMP -= loss;

        if (currentMP <= 0) currentMP = 0;
    }

    public void GainMP(int gain)
    {
        currentMP += gain;

        if (currentMP >= mpStat) currentMP = mpStat;
    }
}
