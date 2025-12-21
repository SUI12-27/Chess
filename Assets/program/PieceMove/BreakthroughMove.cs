using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class BreakthroughMove : MonoBehaviour
{
    public List<Vector2> AroundList
    {
        get
        {
            var list = new List<Vector2>();
            int myX = (int)transform.position.x;
            int myY = (int)transform.position.y;

            list.Add(new Vector2(myX-1,myY+1)); //左上
            list.Add(new Vector2(myX,myY+1));   //上
            list.Add(new Vector2(myX+1,myY+1)); //右上
            list.Add(new Vector2(myX+1,myY));   //右
            list.Add(new Vector2(myX+1,myY-1)); //右下
            list.Add(new Vector2(myX,myY-1));   //下
            list.Add(new Vector2(myX-1,myY-1)); //左下
            list.Add(new Vector2(myX-1,myY));   //左

            return list;
        }
    }
    public List<BasePieceMove>AroundBasePieceMoveList
    {
        get
        {
            var list = new List<BasePieceMove>();
            foreach (var item in AroundList)
            {
                BasePieceMove pieceMove = Board.Boardinstans.GetPieceMove((int)item.x,(int)item.y);
                if(pieceMove != null)
                {
                    list.Add(pieceMove);
                }
            }
            return list;
        }
    }

    public bool ExistEnemy
    {
        get
        {
            BasePieceMoveMark pieceMove = Board.Boardinstans.GetPieceMoveMark((int)transform.position.x,(int)transform.position.y);
            if(pieceMove != null)
            {
                if(pieceMove.affiliation != Board.Turn)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}