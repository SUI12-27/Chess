using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PieceMoveGryphon : BaseMove<PieceMoveMarkGryphon>
{
    public BasePieceMoveMark PieceMoveMarkGryphon;
    public int piecetype;
    // Start is called before the first frame update
    protected override void Start() 
    {
        base.Start();
        PieceMoveMarkGryphon = transform.parent.GetComponent<BasePieceMoveMark>();
        piecetype = PieceMoveMarkGryphon.initialpiecetype;
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void ClickAction()
    {
        Board.Boardinstans.board[(int)PieceMoveMarkGryphon.NowPosition.x].Value[(int)PieceMoveMarkGryphon.NowPosition.y * -1] = 0;
        gameObject.transform.parent.transform.position = gameObject.transform.position;
        PieceMoveMarkGryphon.NowPosition = gameObject.transform.parent.transform.position;
        var oldpiecetype = Board.Boardinstans.board[(int)PieceMoveMarkGryphon.NowPosition.x].Value[(int)PieceMoveMarkGryphon.NowPosition.y * -1];
        if(oldpiecetype < 0 && PieceMoveMarkGryphon.affiliation == PieceAffiliation.White)
        {
            Board.Boardinstans.RemovePieceFromBoard((int)PieceMoveMarkGryphon.NowPosition.x,(int)PieceMoveMarkGryphon.NowPosition.y);
        }
        if(oldpiecetype > 0 && PieceMoveMarkGryphon.affiliation == PieceAffiliation.black)
        {
            Board.Boardinstans.RemovePieceFromBoard((int)PieceMoveMarkGryphon.NowPosition.x,(int)PieceMoveMarkGryphon.NowPosition.y);
        }
        Board.Boardinstans.board[(int)PieceMoveMarkGryphon.NowPosition.x].Value[(int)PieceMoveMarkGryphon.NowPosition.y * -1] = piecetype;
        for (int i = 0; i < PieceMoveMark.NowviewedMark.Count; i++)
        {
            Destroy(PieceMoveMark.NowviewedMark[i]);
        }
        PieceMoveMark.NowviewedMark.Clear();
    }
}
