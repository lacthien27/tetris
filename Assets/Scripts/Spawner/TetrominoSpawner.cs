using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TetrominoSpawner : Spawner

{
  
    public static Action OnTetrominoSpawned;
    [SerializeField] public Transform nextTetromino;
   [SerializeField] public Transform brickCurrent;
    protected override  void Awake() 
    {
     this.brickCurrent= this.Spawn(this.RandomPrefab(),new Vector3(5f,18f,0),Quaternion.identity );  
     this.brickCurrent.gameObject.SetActive(true);
     TetrominoMove.OnTetrominoMove+=this.SpawnTetromMino;
        OnTetrominoSpawned?.Invoke(); //event
        this.nextTetromino= this.RandomPrefab();
    }

    protected virtual void SpawnTetromMino()
    {
            this.brickCurrent=this.Spawn(this.nextTetromino,new Vector3(5f,18f,0),Quaternion.identity );
            this.brickCurrent.gameObject.SetActive(true);
            
            OnTetrominoSpawned?.Invoke();  //event
            this.nextTetromino= this.RandomPrefab(); 
              
    }




    /** code phía đưới là chưa tích hợp predict tretromino
      protected override  void Awake() 
    {
     this.brickCurrent= this.Spawn(this.RandomPrefab(),new Vector3(5f,18f,0),Quaternion.identity );
     this.brickCurrent.gameObject.SetActive(true);
     TetrominoMove.OnTetrominoMove+=this.SpawnTetromMino;
        OnTetrominoSpawned?.Invoke();
    }

    protected virtual void SpawnTetromMino()
    {
             this.brickCurrent= this.Spawn(this.RandomPrefab(),new Vector3(5f,18f,0),Quaternion.identity );
                  this.brickCurrent.gameObject.SetActive(true);
                   OnTetrominoSpawned?.Invoke();  //event
    }
   **/
}
