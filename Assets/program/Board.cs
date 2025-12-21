using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
    
    public List<BasePieceMove> ImpenetravleMoveList;
    public List<BasePieceMove> VastMoveList;

    // Start is called before the first frame update
    void Awake()
    {
        boardinstans = this;
        BlackTurnDisplay.SetActive(false);
        WhiteTurnDisplay.SetActive(true);
    }
    public BasePieceMove GetPieceMove(int x,int y)
    {
        var allPiece = FindObjectsByType<BasePieceMove>(FindObjectsInactive.Include,FindObjectsSortMode.InstanceID);
        foreach (var item in allPiece)
        {
            if((int)item.gameObject.transform.position.x == x && (int)item.gameObject.transform.position.y == y)
            {
                return item;
            }
        }
        return null;
    }
    public BasePieceMoveMark GetPieceMoveMark(int x,int y)
    {
        var allPiece = FindObjectsByType<BasePieceMoveMark>(FindObjectsInactive.Include,FindObjectsSortMode.InstanceID);
        foreach (var item in allPiece)
        {
            if((int)item.gameObject.transform.position.x == x && (int)item.gameObject.transform.position.y == y)
            {
                return item;
            }
        }
        return null;
    }
        public BreakthroughMove GetBreakthroughMove(int x,int y)
    {
        var allPiece = FindObjectsByType<BreakthroughMove>(FindObjectsInactive.Include,FindObjectsSortMode.InstanceID);
        foreach (var item in allPiece)
        {
            if((int)item.gameObject.transform.position.x == x && (int)item.gameObject.transform.position.y == y)
            {
                return item;
            }
        }
        return null;
    }
    public void AllClearBreakthroughMove()
    {
        var allPiece = FindObjectsByType<BreakthroughMove>(FindObjectsInactive.Include,FindObjectsSortMode.InstanceID);
        foreach (var item in allPiece)
        {
            Destroy(item.gameObject);
        }
    }
    public void AllClearCanMoveMark()
    {
        var allPiece = FindObjectsByType<BasePieceMove>(FindObjectsInactive.Include,FindObjectsSortMode.InstanceID);
        foreach (var item in allPiece)
        {
            Destroy(item.gameObject);
        }
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
    public void CheckBoardthoroughly(BasePieceMove basePieceMovePrefab,Transform Parent)
    {
        //Boardの水平の長さ分繰り返す
        for(int x = 0; x < BOARD_HORIZONTAL; x++)
        {
            //Boardの垂直の長さ分繰り返す
            for (int y = 0; y < BOARD_VERTICAL; y++)
            {
                //指定マスのBreakthroughMoveの取得。以下「  targetBreakthroughMove   」
                BreakthroughMove targetBreakthroughMove = GetBreakthroughMove(x,y * -1);
                //指定マスにBreakthroughMoveがない場合
                if(targetBreakthroughMove == null)
                {
                    //処理を途中で終了
                    continue;
                }
                //  targetBreakthroughMove   に敵がいるかを調べる(ExistEnemy)
                // がfalseの場合
                if(targetBreakthroughMove.ExistEnemy == false)
                {
                    //処理を途中で終了
                    continue;
                }
                //  targetBreakthroughMove   の周囲にCanMoveMarkが存在するかどうか。
                // が存在しない場合
                if(targetBreakthroughMove.AroundBasePieceMoveList.Count == 0)
                {
                    //処理を途中で終了
                    continue;
                }
                // が存在しなくない(存在する)場合
                else
                {
                    var MoveMark = Instantiate(basePieceMovePrefab, new Vector3(x,y * -1,0), Quaternion.identity);
                    MoveMark.transform.SetParent(Parent);
                }
            }
        }
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