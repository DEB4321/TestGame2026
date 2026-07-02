using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character")]
public class Character : ScriptableObject
{
    public Sprite sprite;
    public string Name;
    public int currentHP;
    public int hpStat;
    public int currentMP;
    public int MPStat;
    public int strengthStat;
    public int defenseStat;
    
    public int magicDefenseStat;
    public int speedStat;

    public void LevelUp()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
    }
}
