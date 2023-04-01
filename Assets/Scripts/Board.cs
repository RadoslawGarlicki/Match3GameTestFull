using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;                   //szerokoœæ planszy
    public int height;                  //wysokoœæ planszy
    public GameObject tilePrefab;       //prefab dla pojedynczego kafelka na planszy
    public GameObject[] dots;
    private BackgroundTile[,] allTiles; //dwuwymiarowa tablica przechowuj¹ca wszystkie kafelki
    public GameObject[,] allDots;       //dwuwymiarowa tablica przechowuj¹ca wszystkie kropki

    //metoda startuj¹ca sktypt
    void Start()
    {

        allTiles = new BackgroundTile[width, height];
        allDots = new GameObject[width, height];
        SetUp();
    }

    //metoda ustawiaj¹ca planszê na pocz¹tku gry
    private void SetUp()
    {
        for (int i = 0; i < height; i++)            // nie zmieniaæ kolejnoœci height i width, bo kurwa dzia³a
        {
            for(int j = 0; j < width; j++)          // nie zmieniaæ kolejnoœci height i width, bo kurwa dzia³a
            {
                Vector2 tempPosition = new Vector2(i, j);
                GameObject backgroundTile = Instantiate(tilePrefab, tempPosition, Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform; 
                backgroundTile.name = "( " + i + "," + j + " )";    
                int dotToUse = Random.Range(0, dots.Length);
                GameObject dot = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
                dot.transform.parent = this.transform;
                dot.name = "( " + i + "," + j + " )";
                allDots[j,i] = dot;                 // tutaj to samo kurwa nie zmieniaæ xD
            }
        }
    }
}