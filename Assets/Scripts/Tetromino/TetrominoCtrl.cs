using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TetrominoCtrl : GameAbs
{

 [SerializeField] protected TetrominoMove tetrominoMove;
    public TetrominoMove TetrominoMove => tetrominoMove;

     [SerializeField] protected TetrominoSpawner tetrominoSpawner;
    public TetrominoSpawner TetrominoSpawner => tetrominoSpawner;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTetrominoMove();
        this.LoadTetrominoSpawner();
    }


     protected virtual void LoadTetrominoMove()
    {
       if(this.tetrominoMove!=null) return;
        this.tetrominoMove = GetComponentInChildren<TetrominoMove>();
        Debug.LogWarning(transform.name +" : Load TetrominoMove" ,gameObject);
    }


     protected virtual void LoadTetrominoSpawner()
    {
       if(this.tetrominoSpawner!=null) return;
        this.tetrominoSpawner = GetComponentInChildren<TetrominoSpawner>();
        Debug.LogWarning(transform.name +" : Load TetrominoSpawner" ,gameObject);
    }
}

