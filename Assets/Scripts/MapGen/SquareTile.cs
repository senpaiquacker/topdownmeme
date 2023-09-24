using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareTile : BasicTile
{
    // Start is called before the first frame update
    
    public override Vector3[] NeighbourPositions
    {
        get => new Vector3[4] {
        new Vector3(0f, 0f, 1f),
        new Vector3(1, 0f, 0f),
        new Vector3(-1f, 0f, 0f),
        new Vector3(0f, 0f, -1f)
        };
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
