using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Camera cameraPlayer1;
    public Camera cameraPlayer2;
    public int aktiveKamera;

    public Board board;
    public List<GameObject> BauerWeiss;
    public List<GameObject> TurmWeiss;
    public List<GameObject> SpringerWeiss;
    public List<GameObject> LaeuferWeiss;
    
    public GameObject KoeniginWeiss;
    public GameObject KoenigWeiss;
    
    public List<GameObject> BauerSchwarz;
    public List<GameObject> TurmSchwarz;
    public List<GameObject> SpringerSchwarz;
    public List<GameObject> LaeuferSchwarz;
    
    public GameObject KoeniginSchwarz;
    public GameObject KoenigSchwarz;

    private GameObject[,] pieces;
    private List<GameObject> movedBauern;

    private Player black;
    private Player white;
    public Player currentPlayer;
    public Player otherPlayer;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pieces = new GameObject[8,8];
        movedBauern = new List<GameObject>();
        
        black = new Player("black",true);
        white = new Player("white",false);
        
        currentPlayer = black;
        otherPlayer = white;
      
        InitialSetup();
    }

    //Figuren werden mit der AddPiece-Funktion aufs Spielfeld gestellt
    private void InitialSetup()
    {
        AddPiece(KoeniginSchwarz, black, 3, 0);
        AddPiece(KoenigSchwarz, black, 4, 0);
        
        AddPiece(KoeniginWeiss, white, 3, 7);
        AddPiece(KoenigWeiss, white, 4,7);
        
        
        int LaeuferWeissCount = LaeuferWeiss.Count;

        if (LaeuferWeissCount == 2)
        {
            AddPiece(LaeuferWeiss[0], white, 2,7);
            AddPiece(LaeuferWeiss[1], white, 5,7);
        }
        else
        {
            AddPiece(LaeuferWeiss[0], white, 2,7);
            AddPiece(LaeuferWeiss[0], white, 5,7);
        }

        int LaeuferSchwarzCount = LaeuferSchwarz.Count;

        if (LaeuferSchwarzCount == 2)
        {
            AddPiece(LaeuferSchwarz[0], black, 2, 0);
            AddPiece(LaeuferSchwarz[1], black, 5, 0);
        }
        else
        {
            AddPiece(LaeuferSchwarz[0], black, 2, 0);
            AddPiece(LaeuferSchwarz[0], black, 5, 0);
        }
        
        int SpringerWeissCount = SpringerWeiss.Count;

        if (SpringerWeissCount == 2)
        {
            AddPiece(SpringerWeiss[0], white, 1, 7);
            AddPiece(SpringerWeiss[1], white, 6, 7);
        }
        else
        {
            AddPiece(SpringerWeiss[0], white, 1, 7);
            AddPiece(SpringerWeiss[0], white, 6, 7);
        }

        int SpringerSchwarzCount = SpringerSchwarz.Count;

        if (SpringerSchwarzCount == 2)
        {
            AddPiece(SpringerSchwarz[0], black, 1, 0);
            AddPiece(SpringerSchwarz[1], black, 6, 0);
        }
        else
        {
            AddPiece(SpringerSchwarz[0], black, 1, 0);
            AddPiece(SpringerSchwarz[0], black, 6, 0);
        }
        
        int TurmWeissCount = TurmWeiss.Count;
        
        if (TurmWeissCount == 2)
        {
            AddPiece(TurmWeiss[0], white, 0, 7);
            AddPiece(TurmWeiss[1], white, 7, 7);
        }
        else
        {
            AddPiece(TurmWeiss[0], white, 0, 7);
            AddPiece(TurmWeiss[0], white, 7, 7);
        }
        
        int TurmSchwarzCount = TurmSchwarz.Count;

        if (TurmSchwarzCount == 2)
        {
            AddPiece(TurmSchwarz[0], black, 0, 0);
            AddPiece(TurmSchwarz[1], black, 7, 0);
        }
        else
        {
            AddPiece(TurmSchwarz[0], black, 0, 0);
            AddPiece(TurmSchwarz[0], black, 7, 0);
        }
        
        
        int BauerWeissCount = BauerWeiss.Count - 1;
        int BauerWeissIterator = BauerWeissCount;
        int BauerSchwarzCount = BauerSchwarz.Count - 1;
        int BauerSchwarzIterator = BauerSchwarzCount;
        
        for (int i = 0; i < 8; i++)
        {
            if (BauerSchwarzIterator < 0)
            {
                BauerSchwarzIterator = BauerSchwarzCount;
            }
            AddPiece(BauerSchwarz[BauerSchwarzIterator], black, i, 1);
            BauerSchwarzIterator -= 1;
            
            
            if (BauerWeissIterator < 0)
            {
                BauerWeissIterator = BauerWeissCount;
            }
            AddPiece(BauerWeiss[BauerWeissIterator], white, i, 6);
            BauerWeissIterator -= 1;
        }

        cameraPlayer1.enabled = true;
        cameraPlayer2.enabled = false;
        aktiveKamera = 1;

    }

    //Stellt die Figuren auf die übergebene Position und fügt sie dem Figuren-Array des jeweiligen Spielers hinzu
    public void AddPiece(GameObject prefab, Player player, int col, int row)
    {
        GameObject pieceObject;
        if (player.name == "black")
        {
            pieceObject = board.AddPiece(prefab, col, row, "black");
        }
        else
        {
            pieceObject = board.AddPiece(prefab, col, row, "white");
        }
        player.pieces.Add(pieceObject);
        pieces[col, row] = pieceObject;
    }

    //Bewegt eine Figur auf dem Spiefeld und änder die Position im Figuren-Array des GameManager
    public void Move(GameObject piece, Vector2Int gridPoint)
    {
        Piece pieceComponent = piece.GetComponent<Piece>();
        if (pieceComponent.type == PieceType.Bauer && !HasBauerMoved(piece))
        {
            movedBauern.Add(piece);
        }

        Vector2Int startGridPoint = GridForPiece(piece);
        pieces[startGridPoint.x, startGridPoint.y] = null;
        pieces[gridPoint.x, gridPoint.y] = piece;
        board.MovePiece(piece, gridPoint);
    }

    //Gibt der Board-Klasse die Anweisung eine Figur auszuwählen
    public void SelectPiece(GameObject piece)
    {
        board.SelectPiece(piece);
    }

    //Gibt der Board-Klasse die Anweisung eine Auswahl aufzuheben
    public void DeselectPiece(GameObject piece)
    {
        board.DeselectPiece(piece);
    }

    //Entfernt die Spielfigur an der angegebenen Position aus dem Spiel und fügt sie dem Array der geschlagenen Figuren hinzu
    public void CapturePieceAt(Vector2Int gridPoint)
    {
        GameObject pieceToCapture = PieceAtGrid(gridPoint);
        //Gewinn Benachrichtigung wenn König geschlagen wird
        currentPlayer.capturedPieces.Add(pieceToCapture);
        Debug.Log(currentPlayer.capturedPieces.Count);
        pieces[gridPoint.x, gridPoint.y] = null;
        Destroy(pieceToCapture);
    }

    //gibt das GameObject zurück das auf dem übergebenen Punkt steht
    public GameObject PieceAtGrid(Vector2Int gridPoint)
    {
        if (gridPoint.x > 7 || gridPoint.x < 0 || gridPoint.y > 7 || gridPoint.y < 0)
        {
            return null;
        }

        return pieces[gridPoint.x, gridPoint.y];
    }

    //Gibt die Züge zurück die eine Figur durchführen kann
    public List<Vector2Int> MovesForPiece(GameObject pieceObject)
    {
        Piece piece = pieceObject.GetComponent<Piece>();
        Vector2Int gridPoint = GridForPiece(pieceObject);
        List<Vector2Int> locations = piece.MoveLocations(gridPoint);
        List<Vector2Int> opponentLocations = new List<Vector2Int>();

        foreach (var opponent in otherPlayer.pieces)
        {
            
        }
        
        //Locations außerhalb des Boards ausfiltern
        locations.RemoveAll(gp => gp.x < 0 || gp.x > 7 || gp.y < 0 || gp.y > 7);

        locations.RemoveAll(gp => FriendlyPieceAt(gp));

        return locations;
    }
    
    //Gibt die Position einer Spielfigur zurück
    public Vector2Int GridForPiece(GameObject piece)
    {
        for (int i = 0; i < 8; i++) 
        {
            for (int j = 0; j < 8; j++)
            {
                if (pieces[i, j] == piece)
                {
                    return new Vector2Int(i, j);
                }
            }
        }

        return new Vector2Int(-1, -1);
    }

    //Gibt an ob auf dem Feld mit den übergebenen Koordinaten eine eigene Figur steht
    public bool FriendlyPieceAt(Vector2Int gridPoint)
    {
        GameObject piece = PieceAtGrid(gridPoint);

        if (piece == null)
        {
            return false;
        }

        if (otherPlayer.pieces.Contains(piece))
        {
            return false;
        }

        return true;
    }

    //Gibt zurück ob die übergebene Figur im eigenen Figuren-Array vorhanden ist
    public bool DoesPieceBelongToCurrentPlayer(GameObject piece)
    {
        return currentPlayer.pieces.Contains(piece);
    }

    public bool HasBauerMoved(GameObject bauer)
    {
        return movedBauern.Contains(bauer);
    }

    //Wechselt den Spieler der an der Reihe ist
    public void NextPlayer()
    {
        
        if (cameraPlayer1.enabled)
        {
            cameraPlayer1.enabled = false;
            cameraPlayer2.enabled = true;
            aktiveKamera = 2;
        }
        else
        {
            cameraPlayer2.enabled = false;
            cameraPlayer1.enabled = true;
            aktiveKamera = 1;
        }
        
        Player tempPlayer = currentPlayer;
        currentPlayer = otherPlayer;
        otherPlayer = tempPlayer;
    }
}
