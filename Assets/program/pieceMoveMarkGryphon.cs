using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
public class PieceMoveMarkGryphon : MonoBehaviour, IPointerClickHandler, IMoveable
{

    public Vector2[] canMove;
    public Vector2[] offset;
    public GameObject CanMoveMark;
    public static GameObject Lastpiececlicked;

    public Vector2 NowPosition {get;set;}
    public int initialpiecetype;


    // Start is called before the first frame update
    void Start()
    {

        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        NowPosition = new Vector2(x, y);
        Board.board[x, y * -1] = initialpiecetype;
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
        for (int offset_i = 0; offset_i < offset.Length; offset_i++)
        {

            for (int i = 0; i < canMove.Length; i++)//動ける場所の数よりiが多くなるまで繰り返し。
            {
                Vector2 NewMarkPosition = NowPosition + offset[offset_i];//NewMarkPositionは今の場所にオフセットを足したもの
                if (TryPlaceMark(NewMarkPosition) == false)
                {
                    continue;
                }
                while (true)
                {
                    NewMarkPosition += canMove[i] * offset[offset_i];//NewMaekPostionにcanMoveのi番目を足す。そして、offsetで掛ける
                    if (TryPlaceMark(NewMarkPosition) == false)
                    {
                        break;
                    }
                }
            }
        }


    }
    bool TryPlaceMark(Vector2 NewMarkPosition)
    {
        if ((int)NewMarkPosition.x < 0 || (int)NewMarkPosition.x >= Board.board.GetLength(0) || (int)NewMarkPosition.y * -1 < 0 || (int)NewMarkPosition.y * -1 >= Board.board.GetLength(1))
        {
            // ↑ もしNewMarkPositionが盤面外なら最初からやりなおす。
            Debug.Log("break");
            return false;
        }
        if (Board.board[(int)NewMarkPosition.x, (int)NewMarkPosition.y * -1] > 0)//newmarkpostionの場所に味方の駒がいるなら。
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

