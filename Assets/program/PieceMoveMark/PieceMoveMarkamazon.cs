using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
public class pieceMoveMarkamazon : BasePieceMoveMark, IPointerClickHandler, IMoveable
{

    public Vector2[] canMove;
    public Vector2[] canMoveRider;
    public GameObject CanMoveMark;
    public static GameObject Lastpiececlicked;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (PieceMoveMark.NowviewedMark.Count != 0)
        {
            for (int i = 0; i < PieceMoveMark.NowviewedMark.Count; i++)
            {
                Destroy(PieceMoveMark.NowviewedMark[i]);
            }
            PieceMoveMark.NowviewedMark.Clear();
        }
        Lastpiececlicked = gameObject;

        for (int i = 0; i < canMoveRider.Length; i++)//動ける場所の数よりiが多くなるまで繰り返し。
        {
            Vector2 NewMarkPosition = NowPosition;//NewMarkPositionは今の場所
            while (true)
            {
                NewMarkPosition += canMoveRider[i];//NewMaekPostionにcanMoveRiderのi番目を足す
                if (TryPlaceMark(NewMarkPosition) == false)
                {
                    break;
                }
            }
        }

        for (int i = 0; i < canMove.Length; i++)//動ける場所の数よりiが多くなるまで繰り返し。
        {

            Vector2 NewMarkPosition = NowPosition + canMove[i];
            if (TryPlaceMark(NewMarkPosition) == false)
            {
                continue;
            }
        }
    }
    bool TryPlaceMark(Vector2 NewMarkPosition)
    {
        //↓もしNewMarkPositionが盤面外なら最初からやりなおす。
        if ((int)NewMarkPosition.x < 0 || (int)NewMarkPosition.x >= Board.Boardinstans.board.GetLength(0) || (int)NewMarkPosition.y * -1 < 0 || (int)NewMarkPosition.y * -1 >= Board.Boardinstans.board.GetLength(1))
        {

            return false;
        }
        if (Board.Boardinstans.board[(int)NewMarkPosition.x].Value[(int)NewMarkPosition.y * -1] > 0)//newmarkpostionの場所に味方の駒がいるなら。
        {
            return false;
        }
        GameObject MoveMark = Instantiate(CanMoveMark, gameObject.transform);//MoveMarkを作る。
        PieceMoveMark.NowviewedMark.Add(MoveMark);//今見えているmarkをmovemarkに追加する
        MoveMark.transform.SetParent(null);
        MoveMark.transform.localPosition = NewMarkPosition;//movemarkの場所をcanmoveのi番目にする。
        MoveMark.transform.SetParent(gameObject.transform);
        return true;
    }
}

