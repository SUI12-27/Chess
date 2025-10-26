using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Board : MonoBehaviour
{
    public const int BOARD_VERTICAL = 12;
    public const int BOARD_HORIZONTAL = 12;
    public ChildArray[] board = new ChildArray[BOARD_HORIZONTAL];
    public static Board Boardinstans { get => boardinstans; }
    static Board boardinstans;
    public static PieceAffiliation Turn = PieceAffiliation.White;
    // Start is called before the first frame update
    void Awake()
    {
        boardinstans = this;
    }
    public void RemovePieceFromBoard(int x, int y)
    {
        var allPiece = FindObjectsByType<BasePieceMoveMark>(FindObjectsInactive.Include,FindObjectsSortMode.InstanceID);
        foreach (var item in allPiece)
        {
            if((int)item.gameObject.transform.position.x == x && (int)item.gameObject.transform.position.y == y)
            {
                Debug.Log(item.gameObject.name);
                if(item.affiliation != Turn)
                {
                    Destroy(item.gameObject);   
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void TurnChange()
    {
        if (Turn == PieceAffiliation.White)
        {
            Turn = PieceAffiliation.black;
        }
        else if (Turn == PieceAffiliation.black)
        {
            Turn = PieceAffiliation.White;
        }
    } 
}
[System.Serializable]
public class ChildArray
{
    public int[] Value = new int [Board.BOARD_VERTICAL];
}