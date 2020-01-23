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
            FindObjectOfType<AudioManager>().Play("Squirtle");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Pawn_Bulbasaur")){
            FindObjectOfType<AudioManager>().Play("Bulbasaur");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Pawn_Charmander")){
            FindObjectOfType<AudioManager>().Play("Charmander");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Pawn_Eevee")){
            FindObjectOfType<AudioManager>().Play("Eevee");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Pawn_Jigglypuff")){
            FindObjectOfType<AudioManager>().Play("Jigglypuff");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Pawn_Psyduck")){
            FindObjectOfType<AudioManager>().Play("Psyduck");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Pawn_Slowpoke")){
            FindObjectOfType<AudioManager>().Play("Slowpoke");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Bioshop_Arcanine")){
            FindObjectOfType<AudioManager>().Play("Arcanine");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Bioshop_Growlithe")){
            FindObjectOfType<AudioManager>().Play("Growlithe");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Bioshop_Ninetales")){
            FindObjectOfType<AudioManager>().Play("Ninetales");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Bioshop_Vulpix")){
            FindObjectOfType<AudioManager>().Play("Vulpix");
        }
        else if (piece.name.Substring(0, piece.name.Length-23).Equals("King_Mewtwo")){
            FindObjectOfType<AudioManager>().Play("Mewtwo");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("King_Nidoking")){
            FindObjectOfType<AudioManager>().Play("Nidoking");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Queen_Mew")){
            FindObjectOfType<AudioManager>().Play("Mew");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Queen_Nidoqueen")){
            FindObjectOfType<AudioManager>().Play("Nidoqueen");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Knight_Horsea")){
            FindObjectOfType<AudioManager>().Play("Squirtle");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Knight_Seadra")){
            FindObjectOfType<AudioManager>().Play("Seadra");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Knight_Ponyta")){
            FindObjectOfType<AudioManager>().Play("Ponyta");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Knight_Rapidash")){
            FindObjectOfType<AudioManager>().Play("Rapidash");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Rook_Arbok")){
            FindObjectOfType<AudioManager>().Play("Arbok");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Rook_Ekans")){
            FindObjectOfType<AudioManager>().Play("Ekans");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Rook_Dragonair")){
            FindObjectOfType<AudioManager>().Play("Dragonair");
        }
        else if (piece.name.Substring(0, piece.name.Length-11).Equals("Rook_Dratini")){
            FindObjectOfType<AudioManager>().Play("Dratini");
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
