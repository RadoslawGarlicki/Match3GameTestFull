using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;                   //szeroko�� planszy
    public int height;                  //wysoko�� planszy
    public GameObject tilePrefab;       //prefab dla pojedynczego kafelka na planszy
    public GameObject[] dots;
    private BackgroundTile[,] allTiles; //dwuwymiarowa tablica przechowuj�ca wszystkie kafelki
    public GameObject[,] allDots;       //dwuwymiarowa tablica przechowuj�ca wszystkie kropki

    //metoda startuj�ca sktypt
    void Start()
    {

        allTiles = new BackgroundTile[width, height];
        allDots = new GameObject[width, height];
        SetUp();
    }

    //metoda ustawiaj�ca plansz� na pocz�tku gry
    private void SetUp()
    {
        for (int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                Vector2 tempPosition = new Vector2(i, j);
                GameObject backgroundTile = Instantiate(tilePrefab, tempPosition, Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform; 
                backgroundTile.name = "( " + i + "," + j + " )";    
                int dotToUse = Random.Range(0, dots.Length);
                GameObject dot = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
                dot.transform.parent = this.transform;
                dot.name = "( " + i + "," + j + " )";
                allDots[i,j] = dot;
            }
        }
    }
}