using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelSystem : GameAbs
{
   [SerializeField] public int level;
   [SerializeField] private int exp ;
   [SerializeField] private int expToNextLevel ;
  // [SerializeField] private int maxLevel ; 

    [SerializeField] public List<TetrominoData> tetrominoDataList;
    [SerializeField] protected TetrominoData tetrominoData;

    [SerializeField] public Sprite spriteFollowLevel; // mintrCtrl lấy cái này để thay đổi

        public static Action OnChangeSprite; // event thông báo cho MinoCtrl

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
        expToNextLevel = 1;
        //maxLevel = 10;
   }

    public void GainExp()
    {
        exp ++;
        if (exp >= expToNextLevel)
        {
            level++;
            exp -= expToNextLevel;
            this.GetlevelData();
            
            this.GetSpriteFollowLevel();
            OnChangeSprite?.Invoke();

        }
    }

    protected virtual void GetlevelData()
    {
       foreach (var data in tetrominoDataList)
    {
       
        if (data.level == this.level)
        {
            this.tetrominoData = data;
            break;
        }
    }
    }



    protected virtual void GetSpriteFollowLevel()
    {   

        if (tetrominoData != null)
        {
            this.spriteFollowLevel = tetrominoData.tetrominoSprite;
                
        } 

    }


    public int GetLevel()
    {
        return level;
    }
}
