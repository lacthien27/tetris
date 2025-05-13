using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : GameAbs
{
   [SerializeField] public int level;
   [SerializeField] private int exp ;
   [SerializeField] private int expToNextLevel ;
   [SerializeField] private int maxLevel ; 



 protected override void Awake()
    {
        base.Awake();
        this.Level();
        GridSystem.OnTetrominoDeleteRow += GainExp; // Subscribe to the event
    }
   protected virtual void Level()
   {
        level = 1;
        exp = 0;
        expToNextLevel = 3;
        maxLevel = 10;
   }

   




    public void GainExp()
    {
        exp ++;
        if (exp >= expToNextLevel)
        {
            level++;
            exp -= expToNextLevel;
            
        }
    }


    public int GetLevel()
    {
        return level;
    }
}
