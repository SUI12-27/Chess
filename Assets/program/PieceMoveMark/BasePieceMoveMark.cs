using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePieceMoveMark : MonoBehaviour
{
    public Vector2[] canMove;
    public Vector2[] canMoveRider;
    public PieceAffiliation affiliation;
    public int initialpiecetype;
    public Vector2 NowPosition { get; set; }
    protected virtual void Start()
    {
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        NowPosition = new Vector2(x, y);
        Board.Boardinstans.board[x].Value[y * -1] = initialpiecetype;
    }
    protected bool CanMovePieceType(int piecetype)
    {
        //     if (affiliation == PieceAffiliation.White)
        //     {
        //         return piecetype == 0;
        //     }
        //     else if (affiliation == PieceAffiliation.black)
        //     {
        //         return piecetype < 0;
        //     }
        //     else
        //     {
        //         throw new System.Exception("未定義の値です");
        //     }
        return piecetype != 0;
    }
    public void CreateBrakethroughMove()
    {        
        // 次回(12/7)作る!!!!!!!!!!!!!!
    }
}

public enum PieceAffiliation{White,black}