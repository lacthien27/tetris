using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrl : GameAbs
{
     [SerializeField] protected UIScore uIScore;
    public UIScore UIScore => uIScore;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIScore();
    }


     protected virtual void LoadUIScore()
    {
       if(this.uIScore!=null) return;
        this.uIScore = GetComponentInChildren<UIScore>();
        Debug.LogWarning(transform.name +" : Load LoadUIScore" ,gameObject);
    }
}
