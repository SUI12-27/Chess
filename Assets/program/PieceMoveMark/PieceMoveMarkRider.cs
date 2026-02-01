using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
public class PieceMoveMarkRider : BasePieceMoveMark, IPointerClickHandler, IMoveable
{
    public GameObject CanMoveMark;
    public GameObject BreakthorowMoveMark;
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
        Board.Boardinstans.AllClearCanMoveMark();
        GameObject NoColliderCanMove = Instantiate(CanMoveMark,this.transform);
        NoColliderCanMove.transform.position = this.transform.position;
        Collider2D col = NoColliderCanMove.GetComponent<Collider2D>();
        col.enabled = false;
        NoColliderCanMove.gameObject.name="NoColliderCanMove";
        base.RegistPieceMoveMark();
            if (PieceMoveMark.NowviewedMark.Count != 0)
            {
                for (int i = 0; i < PieceMoveMark.NowviewedMark.Count; i++)
                {
                    Destroy(PieceMoveMark.NowviewedMark[i]);
                }
                PieceMoveMark.NowviewedMark.Clear();
            
                for (int i = 0; i < PieceMoveMark.NowviewedBreakthorowMark.Count; i++)
                {
                    Destroy(PieceMoveMark.NowviewedBreakthorowMark[i]);
                }
                PieceMoveMark.NowviewedBreakthorowMark.Clear();
            }
        CreatePieceMove(false);
        CreatePieceMove(true);
        Board.Boardinstans.CheckBoardthoroughly(CanMoveMark.GetComponent<BasePieceMove>(),transform);
        Board.Boardinstans.AllClearBreakthroughMove();
    }
    void CreatePieceMove(bool breakthrow)
    {
        if(affiliation == PieceAffiliation.White && Board.Turn == PieceAffiliation.black)
            {
                return;
            }
            if(affiliation == PieceAffiliation.black && Board.Turn == PieceAffiliation.White)
            {
                return;
            }
            Lastpiececlicked = gameObject;

            for (int i = 0; i < canMove.Length; i++)//動ける場所の数繰り返し。
            {
                Vector2 NewMarkPosition = NowPosition;//NewMarkPositionは今の場所
                while (true)
                {
                    NewMarkPosition += canMove[i];//NewMaekPostionにcanMoveのi番目を足す
                    if(!breakthrow)
                    {
                        if(TryPlaceMark(NewMarkPosition,CanMoveMark,false) == false)
                        {
                            break;
                        }   
                    }
                    else
                    {
                        if(TryPlaceMark(NewMarkPosition,BreakthorowMoveMark,true) == false)
                        {
                            break;
                        }
                    }
                }
            }
    }
    bool TryPlaceMark(Vector2 NewMarkPosition,GameObject CanMove,bool BreakthorowMoveMark)
    {
        // ↓もしNewMarkPositionが盤面外なら最初からやりなおす。
        if ((int)NewMarkPosition.x < 0 || (int)NewMarkPosition.x >= Board.BOARD_HORIZONTAL || (int)NewMarkPosition.y * -1 < 0 || (int)NewMarkPosition.y * -1 >= Board.BOARD_VERTICAL)
        {
            return false;
        }
                // ↓ != 0  (駒がいる)
        if (!BreakthorowMoveMark && base.CanMovePieceType(Board.Boardinstans.board[(int)NewMarkPosition.x].Value[(int)NewMarkPosition.y * -1]))//newmarkpostionの場所に駒がいるなら。
        {
            return false;
        }
        GameObject MoveMark = Instantiate(CanMove,gameObject.transform);//MoveMarkを作る。
        if(BreakthorowMoveMark)
        {
            PieceMoveMark.NowviewedBreakthorowMark.Add(MoveMark);//今見えているBreakThrowmarkをmovemarkに追加する    
        }
        else
        {
            PieceMoveMark.NowviewedMark.Add(MoveMark);//今見えているmarkをmovemarkに追加する    
        }
        MoveMark.transform.SetParent(null);
        MoveMark.transform.localPosition = NewMarkPosition;//movemarkの場所をcanmoveのi番目にする。
        MoveMark.transform.SetParent(gameObject.transform);
        return true;
    }
}