using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pieceMoveamazon : MonoBehaviour, IPointerClickHandler
{
    public pieceMoveMarkamazon pieceMoveMarkamazon;
    public int piecetype;
    // Start is called before the first frame update
    void Start()
    {
        pieceMoveMarkamazon = transform.parent.GetComponent<pieceMoveMarkamazon>();
        piecetype = pieceMoveMarkamazon.initialpiecetype;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.transform.parent.transform);
        Board.board[(int)pieceMoveMarkamazon.NowPosition.x,(int)pieceMoveMarkamazon.NowPosition.y * -1] = 0;
        gameObject.transform.parent.transform.position = gameObject.transform.position;
        pieceMoveMarkamazon.NowPosition = gameObject.transform.parent.transform.position;
        Board.board[(int)pieceMoveMarkamazon.NowPosition.x,(int)pieceMoveMarkamazon.NowPosition.y * -1] = piecetype;
            for(int i=0; i<pieceMoveMark.NowviewedMark.Count;i++)
            {
                Destroy(pieceMoveMark.NowviewedMark[i]);
            }
            pieceMoveMark.NowviewedMark.Clear();
            
    }
}
