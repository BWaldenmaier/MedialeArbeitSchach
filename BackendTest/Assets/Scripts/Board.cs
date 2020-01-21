using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Material selectedMaterial;
    public Material defaultMaterial;

    public GameObject AddPiece(GameObject piece, int col, int row)
    {
        Vector2Int gridPoint = new Vector2Int(col, row);
        GameObject newPiece = Instantiate(piece, new Vector3(gridPoint.x, -0.5f, gridPoint.y), Quaternion.identity);   
          
        return newPiece;
    }

    public void MovePiece(GameObject piece, Vector2Int gridPoint)
    {
        piece.transform.position = new Vector3(gridPoint.x, -0.5f, gridPoint.y);
    }

    public void SelectPiece(GameObject piece)
    {
        Debug.Log(piece.name + "selected");
        if (piece.name.Substring(0, piece.name.Length-11).Equals("Pawn_Pikachu")){
            FindObjectOfType<AudioManager>().Play("Pikachu");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Pawn_Squirtle")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Pawn_Bulbasaur")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Pawn_Charmander")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Pawn_Eevee")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Pawn_Jigglypuff")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Pawn_Psyduck")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Pawn_Slowpoke")){
            //not found
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Bioshop_Arcanine")){
            //not found
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Bioshop_Growlithe")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Bioshop_Ninetales")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Bioshop_Vulpix")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("King_Mewtwo")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("King_Nidoking")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Queen_Mew")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Queen_Nidoqueen")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Knight_Horsea")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Knight_Seadra")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Knight_Ponyta")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Knight_Rapidash")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Rook_Arbok")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Rook_Ekans")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Rook_Dragonair")){

        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Rook_Dratini")){

        }
        
        
        

        MeshRenderer renderers = piece.GetComponentInChildren<MeshRenderer>();
        renderers.material = selectedMaterial;
        Vector2Int gridPoint = GameManager.instance.GridForPiece(piece);
        piece.transform.position = new Vector3(gridPoint.x, 0, gridPoint.y);

        
    }

    public void DeselectPiece(GameObject piece)
    {
        MeshRenderer renderes = piece.GetComponent<MeshRenderer>();
        renderes.material = defaultMaterial;
        Vector2Int gridPoint = GameManager.instance.GridForPiece(piece);
        piece.transform.position = new Vector3(gridPoint.x, -0.5f, gridPoint.y);
    }
}
