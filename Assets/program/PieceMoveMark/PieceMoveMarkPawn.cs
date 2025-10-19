using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PieceMoveMarkPawn : BasePieceMoveMark, IPointerClickHandler, IMoveable
{

    public Vector2[] canMove;
    public GameObject CanMoveMark;
    public static GameObject Lastpiececlicked;
    //public static List<GameObject> NowviewedMark = new List<GameObject>();




    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
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
        if ((int)NewMarkPosition.x < 0 || (int)NewMarkPosition.x >= Board.BOARD_HORIZONTAL || (int)NewMarkPosition.y * -1 < 0 || (int)NewMarkPosition.y * -1 >= Board.BOARD_VERTICAL)
        {
            return false;
        }
        if (base.CanMovePieceType(Board.Boardinstans.board[(int)NewMarkPosition.x].Value[(int)NewMarkPosition.y * -1]))//newmarkpostionの場所に味方の駒がいるなら。
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
