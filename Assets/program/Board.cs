using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public const int BOARD_VERTICAL = 8;
    public const int BOARD_HORIZONTAL = 8;
    public ChildArray[] board = new ChildArray[BOARD_HORIZONTAL];
    public static Board Boardinstans {get => boardinstans;}
    static Board boardinstans;

    // Start is called before the first frame update
    void Awake()
    {
        boardinstans = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class ChildArray
{
    public int[] Value = new int [Board.BOARD_VERTICAL];
}