using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;                   //szerokość planszy
    public int height;                  //wysokość planszy
    public GameObject tilePrefab;       //prefab dla pojedynczego kafelka na planszy
    public GameObject[] dots;
    private BackgroundTile[,] allTiles; //dwuwymiarowa tablica przechowująca wszystkie kafelki
    public GameObject[,] allDots;       //dwuwymiarowa tablica przechowująca wszystkie kropki

    //metoda startująca sktypt
    void Start()
    {

       allTiles = new BackgroundTile[width, height];
        allDots = new GameObject[width, height];
        SetUp();
    }

    //metoda ustawiająca planszę na początku gry
    private void SetUp()
    {
        for (int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                Vector2 tempPostion = new Vector2(i, j);
                GameObject backgroundTile = Instantiate(tilePrefab, tempPostion, Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform;    //zrobiemie z kafelków dzieci w stosunku do board'a
                backgroundTile.name = "( " + i + "," + j + " )";    //nazwanie obiektów
                int dotToUse = Random.Range(0, dots.Length);
                GameObject dot = Instantiate(dots[dotToUse], tempPostion, Quaternion.identity);
                dot.transform.parent = this.transform;
                dot.name = "( " + i + "," + j + " )";
                allDots[i,j] = dot;
            }
        }
    }
}