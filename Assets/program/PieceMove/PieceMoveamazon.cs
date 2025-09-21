using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PieceMoveamazon : BaseMove<pieceMoveMarkamazon>
{
    public BasePieceMoveMark PieceMoveMarkamazon;
    public int piecetype;
    // Start is called before the first frame update
    protected override void Start() 
    {
        base.Start();
        PieceMoveMarkamazon = transform.parent.GetComponent<BasePieceMoveMark>();
        piecetype = PieceMoveMarkamazon.initialpiecetype;
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void ClickAction()
    {
        Board.Boardinstans.board[(int)PieceMoveMarkamazon.NowPosition.x].Value[(int)PieceMoveMarkamazon.NowPosition.y * -1] = 0;
        gameObject.transform.parent.transform.position = gameObject.transform.position;
        PieceMoveMarkamazon.NowPosition = gameObject.transform.parent.transform.position;
        Board.Boardinstans.board[(int)PieceMoveMarkamazon.NowPosition.x].Value[(int)PieceMoveMarkamazon.NowPosition.y * -1] = piecetype;
        for (int i = 0; i < PieceMoveMark.NowviewedMark.Count; i++)
        {
            Destroy(PieceMoveMark.NowviewedMark[i]);
        }
        PieceMoveMark.NowviewedMark.Clear();

    }
}

