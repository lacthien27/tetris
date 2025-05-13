using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoAbs : ThienMonoBehaviour
{
    [SerializeField] protected TetrominoCtrl tetrominoCtrl;

  public TetrominoCtrl TetrominoCtrl => tetrominoCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTetrominoCtrl();
    }

    protected virtual void LoadTetrominoCtrl()
    {
        if(this.tetrominoCtrl!=null) return;
        this.tetrominoCtrl = transform.parent.GetComponent<TetrominoCtrl>();
        Debug.LogWarning(transform.name +" : Load TetrominoCtrl" ,gameObject);

    }
}
