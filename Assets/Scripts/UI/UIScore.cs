using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScore : ThienMonoBehaviour
{
    public TextMeshProUGUI scoreText;
   
   protected override void LoadComponents()
  {
    base.LoadComponents();
    this.LoadText();
  } 

  protected virtual void LoadText()
  {
        if (this.scoreText != null) return; // Nếu đã có scoreText thì không cần tìm lại 
        Transform text = transform.Find("Text (TMP)"); // Đặt tên chính xác của Text (TMP)
        Debug.LogWarning(text);
        if (text != null)
        {
            this.scoreText = text.GetComponent<TextMeshProUGUI>();
            Debug.LogWarning(transform.name + ": Auto-loaded scoreText", gameObject);
        }


   

  }

    protected virtual  void Update() 
    {
      this.UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " +GameCtrl.Instance.ScoreSystem.scoreCurrent.ToString();
    }

  
    

   
}