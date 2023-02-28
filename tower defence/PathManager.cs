using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    private PathGenerator pathGenerator;
    public int gridWidth = 16;
    public int gridHeight = 8;
    //there is min size of path
    public int minPathLength = 30;
    private EnemyWaveManager waveManager;

    public GridCellObject[] gridCells;
    public GridCellObject[] sceneryCells;

    // Start is called before the first frame update
    void Start()
    {
        //declare pathgenerator
        pathGenerator = new PathGenerator(gridWidth, gridHeight);
        //gets component from gamemanager
        waveManager = GetComponent<EnemyWaveManager>();
        //initialize and declare list from generator
        List<Vector2Int> pathCells = pathGenerator.GeneratePath();
        //determine how big path size is
        int pathSize = pathCells.Count;
//while there is less elements than minpathlength make generatepath again
        while(pathSize < minPathLength)
        {
            pathCells = pathGenerator.GeneratePath();
            while(pathGenerator.GenerateCrossroads());
            pathSize = pathCells.Count;
        }
        //initialize building
        StartCoroutine(CreateGrid(pathCells));
        //init waves
        
    }

    IEnumerator CreateGrid(List<Vector2Int> pathCells)
    {
        yield return LayPathCells(pathCells);
        yield return LaySceneryCells();
        waveManager.SetPathCells(pathCells);
    }
    private IEnumerator LayPathCells(List<Vector2Int> pathCells)
    {
        foreach(Vector2Int pathCell in pathCells)
        {
            //check if and where are near cells based on values
            int neighbourValue = pathGenerator.getCellNeighbourValue(pathCell.x,pathCell.y);
            GameObject pathTile = gridCells[neighbourValue].cellPrefab;
            GameObject pathTileCell = Instantiate(pathTile,new Vector3(pathCell.x, 0f, pathCell.y), Quaternion.identity);
            pathTileCell.transform.Rotate(0f, gridCells[neighbourValue].yRotation, 0f, Space.Self);
            
            yield return new WaitForSeconds(0.01f);
        }

        yield return null;
    }

    IEnumerator LaySceneryCells()
    {
        //look though whole grid, if there is empty place then instantiate random scene object
        for(int y = gridHeight - 1; y >= 0; y--)
        {
            for(int x = 0; x < gridWidth; x++)
            {
                if(pathGenerator.CellIsFree(x,y))
                {
                   int randomSceneryCellIndex = Random.Range(0, sceneryCells.Length); 
                   Instantiate(sceneryCells[randomSceneryCellIndex].cellPrefab, new Vector3(x, 0f, y), Quaternion.identity);
                   yield return new WaitForSeconds(0.01f);
                }
            }
        }
        yield return null;
    }
}
