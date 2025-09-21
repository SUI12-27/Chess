using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PieceMove : BaseMove<PieceMoveMark>
{
    public PieceMoveMark pieceMoveMark;
    public int piecetype;
    // Start is called before the first frame update
    protected override void Start() 
    {
        base.Start();
        pieceMoveMark = transform.parent.GetComponent<PieceMoveMark>();
        piecetype = pieceMoveMark.initialpiecetype;
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void ClickAction()
    {
        Board.Boardinstans.board[(int)pieceMoveMark.NowPosition.x].Value[(int)pieceMoveMark.NowPosition.y * -1] = 0;
        gameObject.transform.parent.transform.position = gameObject.transform.position;
        pieceMoveMark.NowPosition = gameObject.transform.parent.transform.position;
        Board.Boardinstans.board[(int)pieceMoveMark.NowPosition.x].Value[(int)pieceMoveMark.NowPosition.y * -1] = piecetype;
        for (int i = 0; i < PieceMoveMark.NowviewedMark.Count; i++)
        {
            Destroy(PieceMoveMark.NowviewedMark[i]);
        }
        PieceMoveMark.NowviewedMark.Clear();
    }
}