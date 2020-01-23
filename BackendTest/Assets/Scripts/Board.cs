using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Material selectedMaterial;
    public Material whiteMaterial;
    public Material blackMaterial;

    public GameObject AddPiece(GameObject piece, int col, int row, String playerName)
    {
        GameObject newPiece;
        Vector2Int gridPoint = new Vector2Int(col, row);
        if (playerName == "black")
        {
            MeshRenderer renderes = piece.GetComponent<MeshRenderer>();
            renderes.material = blackMaterial;
            newPiece = Instantiate(piece, new Vector3(gridPoint.x, -0.5f, gridPoint.y), Quaternion.Euler(0,90f,0));
        }
        else
        {
            newPiece = Instantiate(piece, new Vector3(gridPoint.x, -0.5f, gridPoint.y), Quaternion.Euler(0,-90f,0));
            MeshRenderer renderes = piece.GetComponent<MeshRenderer>();
            renderes.material = whiteMaterial;
        }
        
        return newPiece;
    }

    public void MovePiece(GameObject piece, Vector2Int gridPoint)
    {
        piece.transform.position = new Vector3(gridPoint.x, -0.5f, gridPoint.y);
    }

    public void SelectPiece(GameObject piece)
    {

        MeshRenderer renderers = piece.GetComponentInChildren<MeshRenderer>();
        renderers.material = selectedMaterial;
        Vector2Int gridPoint = GameManager.instance.GridForPiece(piece);
        piece.transform.position = new Vector3(gridPoint.x, 0, gridPoint.y);

        Debug.Log(piece.name + "selected");

        string nameOfPiece = piece.name;

        switch (nameOfPiece)
        {
            case "Pawn_Pikachu (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Pikachu");
                break;
            case "Pawn_Squirtle (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Squirtle");
                break;
            case "Pawn_Bulbasaur (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Bulbasaur");
                break;
            case "Pawn_Charmander (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Charmander");
                break;
            case "Pawn_Eevee (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Eevee");
                break;
            case "Pawn_Jigglypuff (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Jigglypuff");
                break;
            case "Pawn_Psyduck (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Psyduck");
                break;
            case "Pawn_Slowpoke (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Slowpoke");
                break;
            case "Bishop_Arcanine (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Arcanine");
                break;
            case "Bishop_Growlithe (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Growlithe");
                break;
            case "Bishop_Ninetales (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Ninetales");
                break;
            case "Bishop_Vulpix (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Vulpix");
                break;
            case "King_Mewtwo_no_supports (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Mewtwo");
                break;
            case "King_Nidoking (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Nidoking");
                break;
            case "Queen_Mew (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Mew");
                break;
            case "Queen_Nidoqueen (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Nidoqueen");
                break;
            case "Knight_Horsea (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Horsea");
                break;
            case "Knight_Seadra (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Seadra");
                break;
            case "Knight_Ponyta (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Ponyta");
                break;
            case "Knight_Rapidash (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Rapidash");
                break;
            case "Rook_Arbok (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Arbok");
                break;
            case "Rook_Ekans (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Ekans");
                break;
            case "Rook_Dragonair (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Dragonair");
                break;
            case "Rook_Dratini (1)(Clone)":
                FindObjectOfType<AudioManager>().Play("Dratini");
                break;
        }
    }

    public void DeselectPiece(GameObject piece)
    {
        MeshRenderer renderes = piece.GetComponent<MeshRenderer>();
        if (GameManager.instance.currentPlayer.name == "black")
        {
            renderes.material = blackMaterial;
        }
        else
        {
            renderes.material = whiteMaterial;
        }
        Vector2Int gridPoint = GameManager.instance.GridForPiece(piece);
        piece.transform.position = new Vector3(gridPoint.x, -0.5f, gridPoint.y);
    }
}
