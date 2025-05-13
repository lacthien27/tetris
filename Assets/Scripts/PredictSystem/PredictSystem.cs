using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PredictSystem : GameAbs
{
    [SerializeField]public Transform tetrominoPredicted;
   [SerializeField] public List<Transform> holder;


    protected void Update()
    {
        this.tetrominoPredicted=GameCtrl.Instance.TetrominoCtrl.TetrominoSpawner.nextTetromino; 
        this.ActiveTetromino();
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHolder();
      ;
    }

    protected virtual void LoadHolder()
    {
       if(this.holder.Count>0)return;
        Transform holder  = transform.Find("Holder");
        foreach(Transform tetromino in holder)
        {
                this.holder.Add(tetromino);
        }
        this.HidePrefabs();

        Debug.LogWarning(transform.name+": LoadHolder" , gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach(Transform prefab in this.holder )
        {
            prefab.gameObject.SetActive(false);
        }
    }


 
    
    protected virtual void ActiveTetromino()
    {
             
        foreach(Transform tetromino in this.holder )
        {

            if(tetromino.name.Trim()==this.tetrominoPredicted.name.Trim())
            {
                tetromino.gameObject.SetActive(true);
                
               
            }
            else
            tetromino.gameObject.SetActive(false);


        }
    }

   

    
}

