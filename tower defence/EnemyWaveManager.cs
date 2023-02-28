using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    public GameObject enemyUFO;
    private List<Vector2Int> pathCells;
    int nextPathCellIndex;
    private GameObject enemyInstance;
    // Start is called before the first frame update
    void Start()
    {
        //instance of enemy prefab
        enemyInstance = Instantiate(enemyUFO, new Vector3(0, 0.2f, 0), Quaternion.identity);
        nextPathCellIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(pathCells != null && pathCells.Count > 1)
        {
            Vector3 currentPos = enemyInstance.transform.position;
            Vector3 nextPos = new Vector3(pathCells[nextPathCellIndex].x, 0.2f, pathCells[nextPathCellIndex].y);
            //moving to next cell
            enemyInstance.transform.position = Vector3.MoveTowards(currentPos, nextPos , Time.deltaTime * 2);
    
            if(Vector3.Distance(currentPos,nextPos) < 0.05f)
            {
                if(nextPathCellIndex >= pathCells.Count)
            {
                Debug.Log("reached emd");
            }
            else
            {
                nextPathCellIndex++;
            }
            }
            
        }
    }

    public void SetPathCells(List<Vector2Int> pathCells)
    {
        this.pathCells = pathCells;
    }
}
