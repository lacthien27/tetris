using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using System;

public class TetrominoMove :TetrominoAbs
{
    [SerializeField] public  float passedTime ;

    [SerializeField] public  float movementFrequency =0.8f;

    [SerializeField] public Transform brickCurrent;
    
    public static Action OnTetrominoMove; //event
    public static Action OnTetrominoMoveRapid; //event

    public bool isMoveRapid =false;


     [SerializeField] public Transform anchor;


    protected override void Awake()
    {
        base.Awake();
        TetrominoSpawner.OnTetrominoSpawned+=this.LoadTetrominoData;
    }

    protected void Update()
    {
        this.LoadMovement();
        this.LoadUserInputMove();
    }

    protected void LoadTetrominoData()
    {
        this.brickCurrent=this.TetrominoCtrl.TetrominoSpawner.brickCurrent;
      
          this.anchor = this.brickCurrent.Find("Anchor");

      

    }

    protected virtual void LoadMovement()
    {
       this.brickCurrent=this.TetrominoCtrl.TetrominoSpawner.brickCurrent;


       this.passedTime+=Time.deltaTime;
       if(this.passedTime>=movementFrequency)
       {
        this.passedTime=0;
        this.LoadMoveBrick(Vector3.down);
        if(this.isMoveRapid)  // nếu là di chuyển nhanh thì sẽ gọi sự kiện
        {
            OnTetrominoMoveRapid?.Invoke();
        }
       }

    }
    protected virtual void LoadUserInputMove()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.LoadMoveBrick(Vector3.left);
        }
         if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.LoadMoveBrick(Vector3.right);
        }
         if(Input.GetKeyDown(KeyCode.UpArrow))  // rotate
        {
            this.brickCurrent.transform.RotateAround(this.anchor.position,Vector3.forward,90);
            if(!IsInvalidPos())   this.brickCurrent.transform.RotateAround(this.anchor.position,Vector3.forward,-90);           
       }

        if(Input.GetKey(KeyCode.DownArrow))  //move rapid
        {
                      //  OnTetrominoMoveRapid?.Invoke();
                        this.movementFrequency=0.05f;
                                    this.isMoveRapid=true;  

        }  
        
        else
        {
            this.movementFrequency=0.8f;
            this.isMoveRapid=false;
        }  
    }

    protected virtual void   LoadMoveBrick(Vector3 direction)
    {

         this.brickCurrent.transform.position+=direction;
        if(!IsInvalidPos()) //
        {
            this.brickCurrent.transform.position-=direction; //là true sẽ dừng lại nếu đụng  2 bên  chứ vẫn di chuyển xuống
            if(direction==Vector3.down)  // mõi lần id chuyển xuông sẽ cập nhật/
            {
            GameCtrl.Instance.GridSystem.UpdateGrip(this.brickCurrent.transform);
            GameCtrl.Instance.GridSystem.CheckRow();
            OnTetrominoMove?.Invoke();

            }
        } 

   
    }

    protected virtual bool  IsInvalidPos()
    {
    
    // Nếu tất cả đều không null, gọi IsInvalidPos
    return GameCtrl.Instance.GridSystem.IsInvalidPos(this.brickCurrent.transform);
    }

 
    
}
