using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public const int BOARD_VERTICAL = 12;
    public const int BOARD_HORIZONTAL = 12;
    public ChildArray[] board = new ChildArray[BOARD_HORIZONTAL];
    public static Board Boardinstans { get => boardinstans; }
    static Board boardinstans;
    public static PieceAffiliation Turn = PieceAffiliation.White;
    public GameObject WhiteTurnDisplay;
    public GameObject BlackTurnDisplay;
    public Animator animator;
    public Toggle toggle;
    // Start is called before the first frame update
    void Awake()
    {
        boardinstans = this;
        BlackTurnDisplay.SetActive(false);
        WhiteTurnDisplay.SetActive(true);
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
            if(toggle.isOn)
            {
                animator.Play("Show(BLACK)");
            }
            Turn = PieceAffiliation.black;
            WhiteTurnDisplay.SetActive(false);
            BlackTurnDisplay.SetActive(true);
        }
        else if (Turn == PieceAffiliation.black)
        {
            if(toggle.isOn)
            {
                animator.Play("Show");
            }
                Turn = PieceAffiliation.White;
            BlackTurnDisplay.SetActive(false);
            WhiteTurnDisplay.SetActive(true);
        }
    } 
}
[System.Serializable]
public class ChildArray
{
    public int[] Value = new int [Board.BOARD_VERTICAL];
}