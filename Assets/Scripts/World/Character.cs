using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character")]
public class Character : ScriptableObject
{
    public Sprite sprite;
    public string Name;
    public int hpStat;
    public int strengthStat;
    public int defenseStat;
    public int magicStat;
    public int magicDefenseStat;
    public int speedStat;

    public void LevelUp()
    {
        
    }
}
