using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PieceMoveRiders : BaseMove<PieceMoveMarkRider>
{
    public BasePieceMoveMark pieceMoveMarkRider;
    public int piecetype;
    // Start is called before the first frame update
    protected override void Start() 
    {
        base.Start();
        pieceMoveMarkRider = transform.parent.GetComponent<BasePieceMoveMark>();
        piecetype = pieceMoveMarkRider.initialpiecetype;
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void ClickAction()
    {
        Board.Boardinstans.board[(int)pieceMoveMarkRider.NowPosition.x].Value[(int)pieceMoveMarkRider.NowPosition.y * -1] = 0;
        gameObject.transform.parent.transform.position = gameObject.transform.position;
        pieceMoveMarkRider.NowPosition = gameObject.transform.parent.transform.position;
        Board.Boardinstans.board[(int)pieceMoveMarkRider.NowPosition.x].Value[(int)pieceMoveMarkRider.NowPosition.y * -1] = piecetype;
        for (int i = 0; i < PieceMoveMark.NowviewedMark.Count; i++)
        {
            Destroy(PieceMoveMark.NowviewedMark[i]);
        }
        PieceMoveMark.NowviewedMark.Clear();
    }
}
