using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Video;

public class MinoCtrl : ThienMonoBehaviour
{

     [SerializeField] protected List<Transform> listTetromino = new List<Transform>();

    [SerializeField] protected SpriteRenderer spriteRenderer;

    [SerializeField]protected int levelMino=1;
    

    protected override void OnEnable()
    {
        LoadChildTransforms();
        LevelSystem.OnChangeSprite += ChangeTetrominoSprite; // Subscribe to the event

        int currentLevel= GameCtrl.Instance.LevelSystem.level;
        if (currentLevel != levelMino)
        {
            levelMino = currentLevel;
            ChangeTetrominoSprite();
        }
    }

    protected void LoadChildTransforms()
    {
        listTetromino.Clear();

        foreach (Transform child in this.transform)
        {
             listTetromino.Add(child);
        }
    }


    protected virtual void ChangeTetrominoSprite()
    {
       foreach (Transform mino in listTetromino)
        {
                 this.spriteRenderer = mino.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                        Debug.LogWarning(GameCtrl.Instance.LevelSystem);
                        spriteRenderer.sprite = GameCtrl.Instance.LevelSystem.spriteFollowLevel;
                }
                
        }
    
    }

    protected override void OnDisable()
    {
        LevelSystem.OnChangeSprite -= ChangeTetrominoSprite; // Unsubscribe from the event
    }


}