using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicTile : MonoBehaviour
{
    // Start is called before the first frame update
    public (int x, int y) TileId;
    public abstract Vector3[] NeighbourPositions { get; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
