using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//allow to create gridcell from inspector
[CreateAssetMenu(fileName = "GridCell" , menuName ="TowerDefence/Grid Cell")]
public class GridCellObject : ScriptableObject
{
    //enum containing 2 consts
    public enum CellType { Path,Ground }

    public CellType cellType;
    public GameObject cellPrefab;
    public int yRotation;
}
