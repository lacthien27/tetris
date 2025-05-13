using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreSystem : GameAbs
{

    [SerializeField] public int scoreCurrent =0;
    [SerializeField] public int scoreIncreate =0;
    protected override void Awake()
    {
        base.Awake();
        TetrominoMove.OnTetrominoMoveRapid+=this.IncreateScoreMoveRapid;
        GridSystem.OnTetrominoDeleteRow+=this.IncreateScoreDeleteRow;
    }


    protected virtual void IncreateScoreMoveRapid()
    {
        this.scoreIncreate+=1;
        this.scoreCurrent+=this.scoreIncreate;
        this.scoreIncreate=0;
      //  Debug.Log("Score: "+this.scoreCurrent);
 
    }

    protected virtual void IncreateScoreDeleteRow()
    {
         this.scoreIncreate+=100;
        this.scoreCurrent+=this.scoreIncreate;
        this.scoreIncreate=0;
       // Debug.Log("Score: "+this.scoreCurrent);
    }
}
