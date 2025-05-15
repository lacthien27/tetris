using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TetrominoData", menuName = "SO/TetrominoData")]
public class TetrominoData : ScriptableObject
{
  public int level;
    public Sprite tetrominoSprite;
}