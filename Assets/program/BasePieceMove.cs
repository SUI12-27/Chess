using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public abstract class BasePieceMoveMark<T> : MonoBehaviour
where T : Component
{
    public T pieceMoveMark;
    // public int ptiecetype;
    protected virtual void Start()
    {

        Getpiecemovemark();
    }
    protected void Getpiecemovemark()
    {
        pieceMoveMark = transform.parent.GetComponent<T>();
        //piecetype = pieceMoveMark.initialpiecetype;
    }
    protected void OnClick()
    {
        Board.board[(int)pieceMoveMarkRider.NowPosition.x,(int)pieceMoveMarkRider.NowPosition.y * -1] = 0;
        gameObject.transform.parent.transform.position = gameObject.transform.position;
        pieceMoveMarkRider.NowPosition = gameObject.transform.parent.transform.position;
        Board.board[(int)pieceMoveMarkRider.NowPosition.x,(int)pieceMoveMarkRider.NowPosition.y * -1] = piecetype;
            for(int i=0; i<pieceMoveMark.NowviewedMark.Count;i++)
            {
                Destroy(pieceMoveMark.NowviewedMark[i]);
            }
            pieceMoveMark.NowviewedMark.Clear();
            
    }
}
