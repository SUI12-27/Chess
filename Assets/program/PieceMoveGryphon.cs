using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PieceMoveGryphon : MonoBehaviour, IPointerClickHandler
{
    public pieceMoveMarkGryphon pieceMoveMarkGryphon;
    public int piecetype;
    // Start is called before the first frame update
    void Start()
    {
        pieceMoveMarkGryphon = transform.parent.GetComponent<pieceMoveMarkGryphon>();
        piecetype = pieceMoveMarkGryphon.initialpiecetype;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Board.board[(int)pieceMoveMarkGryphon.NowPosition.x, (int)pieceMoveMarkGryphon.NowPosition.y * -1] = 0;
        gameObject.transform.parent.transform.position = gameObject.transform.position;
        pieceMoveMarkGryphon.NowPosition = gameObject.transform.parent.transform.position;
        Board.board[(int)pieceMoveMarkGryphon.NowPosition.x, (int)pieceMoveMarkGryphon.NowPosition.y * -1] = piecetype;
        for (int i = 0; i < pieceMoveMark.NowviewedMark.Count; i++)
        {
            Destroy(pieceMoveMark.NowviewedMark[i]);
        }
        pieceMoveMark.NowviewedMark.Clear();

    }
}
