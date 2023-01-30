using UnityEngine;
using System.Collections.Generic;

public class WorldGenerator : MonoBehaviour {
//size of world
    public int size = 10;
    public GameObject tilePrefab;
    public GameObject mountainPrefab;
    public GameObject lakePrefab;
    public GameObject treePrefab;
    public GameObject grassPrefab;

    void Start() {
        for (int x = 0; x < size; x++) {
            for (int z = 0; z < size; z++) {
                Vector3 pos = new Vector3(x, 0, z);
                GameObject tile = Instantiate(tilePrefab, pos, Quaternion.identity);
                //generate random number for each block
                int randomNumber = Random.Range(0, 100);
                //depends on number world block generates diffrent prefab
                if (randomNumber < 20) {
                    Instantiate(mountainPrefab, pos, Quaternion.identity, tile.transform);
                } else if (randomNumber < 40) {
                    Instantiate(lakePrefab, pos, Quaternion.identity, tile.transform);
                } else if (randomNumber < 60) {
                    Instantiate(treePrefab, pos, Quaternion.identity, tile.transform);
                } else if (randomNumber < 80) {
                    Instantiate(grassPrefab, pos, Quaternion.identity, tile.transform);
                }
            }
        }
    }
}