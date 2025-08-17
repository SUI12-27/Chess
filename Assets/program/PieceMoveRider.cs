using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PieceMoveRiders : MonoBehaviour, IPointerClickHandler
{
    public pieceMoveMarkRider pieceMoveMarkRider;
    public int piecetype;
    // Start is called before the first frame update
    void Start()
    {
        pieceMoveMarkRider = transform.parent.GetComponent<pieceMoveMarkRider>();
        piecetype = pieceMoveMarkRider.initialpiecetype;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Board.board[(int)pieceMoveMarkRider.NowPosition.x,(int)pieceMoveMarkRider.NowPosition.y * -1] = 0;
        gameObject.transform.parent.transform.position = gameObject.transform.position;
        pieceMoveMarkRider.NowPosition = gameObject.transform.parent.transform.position;
        Board.board[(int)pieceMoveMarkRider.NowPosition.x,(int)pieceMoveMarkRider.NowPosition.y * -1] = piecetype;
            for(int i=0; i<pieceMoveMark.NowviewedMark.Count;i++)
            {
                Destroy(pieceMoveMark.NowviewedMark[i]);
            }
            pieceMoveMark.NowviewedMark.Clear();
            
    }
}
