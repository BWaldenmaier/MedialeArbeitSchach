﻿using System.Collections;
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
