using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private int height, width;

    [SerializeField]
    private Tile _tilePrefab;

    [SerializeField]
    private Transform _cam;

    [SerializeField] private GameObject Rat;

    private void Start()
    {
        GenerateGrid();
        Instantiate(Rat);
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var SpawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                SpawnedTile.name = $"Floor {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                SpawnedTile.Initialize(isOffset);
            }
        }

        _cam.transform.position = new Vector3((float)width / 2 - 0.5f, 4.4f, -10);
    }
}

