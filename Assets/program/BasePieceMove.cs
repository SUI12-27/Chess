using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseMove<T> : MonoBehaviour, IPointerClickHandler
where T : Component, IMoveable

{
    public T PieceMoveMarkType;

    //UnityEditorÇÃInspectorÇ©ÇÁê›íËÇ∑ÇÈÇ±Ç∆
    public int Initialpiecetype;
    public int Piecetype;
    // public int ptiecetype;
    protected virtual void Start()
    {
        PieceMoveMarkType = transform.parent.GetComponent<T>();
        //piecetype = pieceMoveMark.initialpiecetype;
    }

    protected virtual void ClickAction()
    {
        Board.board[(int)PieceMoveMarkType.NowPosition.x,(int)PieceMoveMarkType.NowPosition.y * -1] = 0;
        gameObject.transform.parent.transform.position = gameObject.transform.position;
        PieceMoveMarkType.NowPosition = gameObject.transform.parent.transform.position;
        Board.board[(int)PieceMoveMarkType.NowPosition.x,(int)PieceMoveMarkType.NowPosition.y * -1] = Piecetype;

        for(int i=0; i<pieceMoveMark.NowviewedMark.Count;i++)
        {
            Destroy(pieceMoveMark.NowviewedMark[i]);
        }
        pieceMoveMark.NowviewedMark.Clear();
            
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ClickAction();
    }
}
