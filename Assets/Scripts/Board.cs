using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;                   //szeroko�� planszy
    public int height;                  //wysoko�� planszy
    public GameObject tilePrefab;       //prefab dla pojedynczego kafelka na planszy
    private BackgroundTile[,] allTiles; //dwuwymiarowa tablica przechowuj�ca wszystkie kafelki

    //metoda startuj�ca sktypt
    void Start()
    {

       allTiles = new BackgroundTile[width, height];
        SetUp();
    }

    //metoda ustawiaj�ca plansz� na pocz�tku gry
    private void SetUp()
    {
        for (int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; i++)
            {
                Vector2 tempPostion = new Vector2(i, j);
                GameObject backgroundTile = Instantiate(tilePrefab, tempPostion, Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform;    //zrobiemie z kafelk�w dzieci w stosunku do board'a
                backgroundTile.name = "( " + i + "," + j + " )";    //nazwanie obiekt�w
            }
        }
    }
}