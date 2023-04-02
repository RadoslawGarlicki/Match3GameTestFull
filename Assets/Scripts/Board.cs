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
        //Inicializacja dwuwymiarowych tablic przechowywuj�cych kafelki i kropki
        allTiles = new BackgroundTile[width, height];
        allDots = new GameObject[width, height];
        SetUp();
    }

    //metoda ustawiaj�ca plansz� na pocz�tku gry
    private void SetUp()
    {
        for (int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                Vector2 tempPosition = new Vector2(i, j);                                                                   //Ustawienie pozycji dla ka�dego kafelka na planszy
                GameObject backgroundTile = Instantiate(tilePrefab, tempPosition, Quaternion.identity) as GameObject;       //Stworzenie obiektu kafelka na planszy
                backgroundTile.transform.parent = this.transform;                                                           //Ustawienie kafelka jako dziecka board'a
                backgroundTile.name = "( " + i + "," + j + " )";                                
                int dotToUse = Random.Range(0, dots.Length);

                int maxIteration = 0;
                while ((MatchesAt(i,j, dots[dotToUse]) && maxIteration < 100))                  //Warunek kt�ry upewnia si� czy nie ma 3 kropek tege samego typu obok siebie 
                {
                    dotToUse = Random.Range(0, dots.Length);
                    maxIteration++;
                    Debug.Log(maxIteration);
                }
                maxIteration = 0;
                GameObject dot = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);        //stworzenie kropki na planszy
                dot.transform.parent = this.transform;                                                  //kropa jako dziecko board'a
                dot.name = "( " + i + "," + j + " )";
                allDots[j,i] = dot;                                                                 //przypisane kropki do odpowiedniego miejsca w dwuwymiarowej tablicy allDots
            }
        }
    }

    private bool MatchesAt(int row, int column, GameObject piece)                           //Metoda sprawdzaj�ca czy s� wygenerowane 3 kropki ko�o siebie w kolumnie lub rz�dzie
    {
        if(column > 1 && row > 1)               //Je�li nie ma ich w dw�ch pierwszych
        {
            if (allDots[column - 1, row].tag == piece.tag && allDots[column - 2, row].tag == piece.tag)         //Sprawdza czy znajduj� si� w jednym rz�dzie
            { 
                return true; 
            }

            if (allDots[column, row - 1].tag == piece.tag && allDots[column, row - 2].tag == piece.tag)         //... kolumnie
            {
                return true;
            }

        }
        else if(column <= 1 || row <= 1)            //Je�li znajduj� si� w dw�ch pierwszych
        {
            if(row > 1)
            {
                if (allDots[column, row - 1].tag == piece.tag && allDots[column, row - 2].tag == piece.tag)         //sprawdza czy znajduj� si� w jednym rz�dzie
                {
                    return true;
                }
            }
            if (column > 1)
            {
                if (allDots[column - 1, row].tag == piece.tag && allDots[column - 2, row].tag == piece.tag)         // kolumnie
                {
                    return true;
                }
            }
        }

        return false;                       //Je�eli brak kropek
    }

        private void DestroyMatchesAt(int column, int row)
        {
            if (allDots[column, row].GetComponent<Dot>().isMatched)
            {
                Destroy(allDots[column, row]);
                allDots[column, row] = null;
            }
        }

        public void DestroyMatches()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (allDots[i, j] != null)
                    {
                        DestroyMatchesAt(i, j);
                    }
                }
            }
        }
}