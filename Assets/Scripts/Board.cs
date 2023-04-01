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
        for (int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                Vector2 tempPosition = new Vector2(i, j);
                GameObject backgroundTile = Instantiate(tilePrefab, tempPosition, Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform; 
                backgroundTile.name = "( " + i + "," + j + " )";   
                int dotToUse = Random.Range(0, dots.Length);

                int maxIteration = 0;
                while ((MatchesAt(i,j, dots[dotToUse]) && maxIteration < 100))
                {
                    dotToUse = Random.Range(0, dots.Length);
                    maxIteration++;
                    Debug.Log(maxIteration);
                }
                maxIteration = 0;
                GameObject dot = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
                dot.transform.parent = this.transform;
                dot.name = "( " + i + "," + j + " )";
                allDots[j,i] = dot;
            }
        }
    }

    private bool MatchesAt(int row, int column, GameObject piece)
    {
        if(column > 1 && row > 1)
        {
            if (allDots[column - 1, row].tag == piece.tag && allDots[column - 2, row].tag == piece.tag)
            { 
                return true; 
            }

            if (allDots[column, row - 1].tag == piece.tag && allDots[column, row - 2].tag == piece.tag)
            {
                return true;
            }

        }
        else if(column <= 1 || row <= 1)
        {
            if(row > 1)
            {
                if (allDots[column, row - 1].tag == piece.tag && allDots[column, row - 2].tag == piece.tag)
                {
                    return true;
                }
            }
            if (column > 1)
            {
                if (allDots[column - 1, row].tag == piece.tag && allDots[column - 2, row].tag == piece.tag)
                {
                    return true;
                }
            }
        }

        return false;
    }
}