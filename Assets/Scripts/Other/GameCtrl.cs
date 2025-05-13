using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : ThienMonoBehaviour
{
   [SerializeField]     private static GameCtrl instance;
     public static   GameCtrl Instance => instance;// thứ đc lấy ra sài
    
    [SerializeField] protected TetrominoCtrl tetrominoCtrl;
    public TetrominoCtrl TetrominoCtrl => tetrominoCtrl;

    [SerializeField] protected GridSystem gridSystem;
    public GridSystem GridSystem => gridSystem;

    [SerializeField] protected UICtrl uICtrl;
    public UICtrl UICtrl => uICtrl;

     [SerializeField] protected ScoreSystem scoreSystem;
    public ScoreSystem ScoreSystem => scoreSystem;

     [SerializeField] protected LevelSystem levelSystem;
    public LevelSystem LevelSystem => levelSystem;

    protected override void Awake()
    {
      base.Awake();
        if(GameCtrl.instance !=null)  Debug.LogError("Only 1 GameCtrl allow to exist");
        GameCtrl.instance=this;
    }


     protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTetromino();
        this.LoadGridSystem();
        this.LoadUICtrl();
        this.LoadScoreSystem();
        this.LoadLevelSystem();
    }


      protected virtual void LoadTetromino()
    {
       
    if(this.tetrominoCtrl !=null) return;
    this.tetrominoCtrl =GameCtrl.FindObjectOfType<TetrominoCtrl>();
    Debug.Log(transform.name+"LoadTetrominoCtrl",gameObject);
    

    }
    
     protected virtual void LoadGridSystem()
    {
      if(this.gridSystem !=null) return;
    this.gridSystem =GameCtrl.FindObjectOfType<GridSystem>();
    Debug.Log(transform.name+"LoadGridSystem",gameObject);
    }
 protected virtual void LoadUICtrl()
    {
      if(this.uICtrl !=null) return;
    this.uICtrl =GameCtrl.FindObjectOfType<UICtrl>();
    Debug.Log(transform.name+"LoadUICtrl",gameObject);
    }

  protected virtual void LoadScoreSystem()
    {
      if(this.scoreSystem !=null) return;
    this.scoreSystem =GameCtrl.FindObjectOfType<ScoreSystem>();
    Debug.Log(transform.name+"LoadScoreSystem",gameObject);
    }
      protected virtual void LoadLevelSystem()
    {
      if(this.levelSystem !=null) return;
    this.levelSystem =GameCtrl.FindObjectOfType<LevelSystem>();
    Debug.Log(transform.name+"LoadLevelSystem",gameObject);
    }
}
