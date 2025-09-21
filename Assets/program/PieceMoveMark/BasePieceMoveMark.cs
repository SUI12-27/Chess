using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePieceMoveMark : MonoBehaviour
{
    public int initialpiecetype;
    public Vector2 NowPosition{get;set;}
    void Start()
    {
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        NowPosition = new Vector2(x, y);
        Board.Boardinstans.board[x].Value[y * -1] = initialpiecetype;
    }
}