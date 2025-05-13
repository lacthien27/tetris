using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;
using System;

public class GridSystem : GameAbs
{
    public Transform[,] grid;
    
    public int width =10;
    public int height =20;
    
    public static Action OnTetrominoDeleteRow; //event

    protected override void Awake()
    {
        grid=  new Transform[width,height];


    }

    public virtual void UpdateGrip(Transform tetromino)
    {
        for(int y =0;y<this.height;y++)
        {
            for(int x=0;x<this.width;x++)
            {
                if(grid[x,y]!=null)
                {
                    if(grid[x,y].parent==tetromino)  grid[x,y]=null; //
                  
                }
            }
        }

        foreach(Transform mino in tetromino)
        {
            Vector2 pos = Round(mino.position);
            if(pos.y<this.height)
            {
                grid[(int)pos.x,(int)pos.y]=mino;
            }
                
        }
    }
    
    public static Vector2 Round(Vector2 v)
   {
        return new Vector2(Mathf.Round(v.x),Mathf.Round(v.y));

   }

    protected virtual Transform GetTransformAtGridPos(Vector2 pos)
    {
        if(pos.y>this.height-1)
        {
            return null;
        }
        return grid[(int)pos.x ,(int)pos.y];
    }


    public virtual bool IsInvalidPos(Transform tetromino)  // nếu pos valid will to "true"
    {
        foreach(Transform mino in tetromino)
        {   
            Vector2 pos= Round(mino.position);
            if(!InsideBoder(pos)) return false; // nếu ko có trong đó sẽ ra false

            if(GetTransformAtGridPos(pos)!=null&& GetTransformAtGridPos(pos).parent!=tetromino) // check ghi đè lên tetromino khác/
            {
                return false;
            } 
        } return true;
    }

    protected virtual bool  InsideBoder(Vector2 pos)
    {
      return (int)pos.x>=0 && (int)pos.x<this.width && (int)pos.y>=0 && (int)pos.y<this.height;
            
    }


    public virtual void CheckRow()
    {
        for(int y =0;y<this.height;y++)
        {
            if(CheckLineEnough(y))
            {
                this.DeleteRow(y);
                this.DecreaseRowAbove(y+1);//y-1
                y--; 
                //check lại hàng đó vì đã bị xóa đi rồi
                GameCtrl.Instance.GridSystem.DebugGrid();
            }
            

        }

    }



    public virtual bool CheckLineEnough(int y)
    {
        for(int x =0;x<this.width;x++)
        {
           if(grid[x,y]==null) return false;
            
        }
        
        return true;

    }   

    public virtual void DeleteRow(int y)
    {
         // gọi event để xóa hàng
        for(int x=0;x<this.width;x++)
        {
            GameCtrl.Instance.TetrominoCtrl.TetrominoSpawner.Despawn(grid[x,y].gameObject.transform); //xóa đi

                grid[x,y]=null; //reset lại vị trí đó

        }
        OnTetrominoDeleteRow?.Invoke(); // gọi event để xóa hàng
    }

    public virtual void DecreaseRowAbove(int StartRow)
    {
        for(int y =StartRow;y<this.height;y++)
        {  
            for(int x=0;x<this.width;x++)
            {
                if(grid[x,y]!=null) 
                {
                    grid[x,y-1]=grid[x,y];
                    grid[x,y]=null; //reset lại vị hàng trên vừa kéo xuống
                    grid[x,y-1].position+=Vector3.down;

                }

            }
            
        }
    }
    public virtual void CheckTest()
{
    DebugGrid(); // Hiển thị ma trận trong Debug Console

    for (int y = 0; y < this.height; y++)
    {
        for (int x = 0; x < this.width; x++)
        {
            if (grid[x, y] != null)
            {
                Debug.Log("grid[" + x + "," + y + "] = " + grid[x, y].name);
            }
        }
    }
}

    public virtual void DebugGrid()
{
    string gridRepresentation = "";

    for (int y = this.height - 1; y >= 0; y--) // Duyệt từ hàng trên xuống dưới
    {
        for (int x = 0; x < this.width; x++)
        {
            if (grid[x, y] != null)
            {
                gridRepresentation += "X"; // Ô không null
            }
            else
            {
                gridRepresentation += "O"; // Ô null
            }
        }
        gridRepresentation += "\n"; // Xuống dòng sau mỗi hàng
    }

    Debug.Log(gridRepresentation);
}

}
