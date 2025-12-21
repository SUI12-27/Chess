using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using JetBrains.Annotations;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.EventSystems;
public abstract class BasePieceMove : MonoBehaviour
{
    public bool ExistEnemyFlag;
}
public abstract class BaseMove<T> : BasePieceMove , IPointerClickHandler
where T : Component, IMoveable

{
    public T PieceMoveMarkType;
    //UnityEditor��Inspector����肷�邱��
    public int Piecetype;
    // public int ptiecetype;


    protected virtual void Start()
    {
        PieceMoveMarkType = transform.parent.GetComponent<T>();
        Piecetype = transform.parent.GetComponent<BasePieceMoveMark>().initialpiecetype;
    }

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

    protected abstract void ClickAction();
    // {
    // Board.Boardinstans.board[(int)PieceMoveMarkType.NowPosition.x].Value[(int)PieceMoveMarkType.NowPosition.y * -1] = 0;
    // gameObject.transform.parent.transform.position = gameObject.transform.position;
    // PieceMoveMarkType.NowPosition = gameObject.transform.parent.transform.position;
    // Board.Boardinstans.board[(int)PieceMoveMarkType.NowPosition.x].Value[(int)PieceMoveMarkType.NowPosition.y * -1] = Piecetype;

    // for(int i=0; i<PieceMoveMark.NowviewedMark.Count;i++)
    // {
    //     Destroy(PieceMoveMark.NowviewedMark[i]);
    // }
    // PieceMoveMark.NowviewedMark.Clear();
    // Debug.Log(Piecetype +":"+ (int)PieceMoveMarkType.NowPosition.x +":"+ (int)PieceMoveMarkType.NowPosition.y);
    // }

    public void OnPointerClick(PointerEventData eventData)
    {
        ClickAction();
        Board.Boardinstans.TurnChange();
    }
    public void take()
    {

    }
}
