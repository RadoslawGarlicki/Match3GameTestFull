using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    private Vector2 firstTouchPostion;
    private Vector2 finalTouchPostion;
    public float swiapeAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
 