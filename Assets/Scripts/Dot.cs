using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public int column;
    public int row;
    public int targetX;
    public int targetY;
    private GameObject otherDot;
    private Vector2 firstTouchPostion;
    private Vector2 finalTouchPostion;
    public float swiapeAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        board = FindObiejctOfType<Board>;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        firstTouchPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(firstTouchPostion);
    }
    private void OnMouseUp()
    {
        firstTouchPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CalculateAngle();
    }
    void CalculateAngle()
    {
        swiapeAngle = Mathf.Atan2(finalTouchPostion.y - firstTouchPostion.y, finalTouchPostion.x - firstTouchPostion.x) * 100 / Mathf.PI;
        //Debug.Log(swiapeAngle);
    }
    void MovePieces()       //przesuwanie kropek
    {
        if(swiapeAngle > -45 && swiapeAngle <=45)
        {
            otherDot = board.allDots[column + 1, row];
            otherDot.GetComponent<Dot>
        }
    }
}
 