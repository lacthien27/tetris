using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UILevel : ThienMonoBehaviour
{
   public TextMeshProUGUI levelText;

    protected override void Awake()
    {
        base.Awake();
        
    }
   
   protected override void LoadComponents()
  {
    base.LoadComponents();
    this.LoadText();
  } 

  protected virtual void LoadText()
  {
        if (this.levelText != null) return; // Nếu đã có levelText thì không cần tìm lại 
        Transform text = transform.Find("Text (TMP)"); // Đặt tên chính xác của Text (TMP)
        Debug.LogWarning(text);
        if (text != null)
        {
            this.levelText = text.GetComponent<TextMeshProUGUI>();
            Debug.LogWarning(transform.name + ": Auto-loaded levelText", gameObject);
        }
  }
    protected virtual  void Update() 
    {
      this.UpdateScore();
    }

    public void UpdateScore()
    {
        levelText.text = "Level: " +GameCtrl.Instance.LevelSystem.level.ToString();
    }

  
}
