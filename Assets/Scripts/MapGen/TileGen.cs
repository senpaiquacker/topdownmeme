using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TileGen : MonoBehaviour
{
    // Start is called before the first frame update
    public int Width;
    public int Length;
    public BasicTile[] TileLib;
    public BasicTile Tile;
    public TextAsset file;
    private BasicTile SelectTile(char sym)
    {
        switch (sym)
        {
            case '0':
                return TileLib[0];
            case 'w':
                return TileLib[1];
            default:
                return TileLib[0];
        }
    }
    void Start()
    {
        TextGen(file);
        //FlatGen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void TextGen(TextAsset file)
    {
        var level = file.text.Replace("\r", "");
        var desc = level.Split('\n')[0].Split(':');
        var layout = level.Remove(0, level.Split('\n')[0].Length+1).Split('\n');
        var size = desc[1].Split('x');
        int width = int.Parse(size[0]), length = int.Parse(size[1]);
        var tileMeshes = new CombineInstance[length * width];
        for (int i=0;i<length;i++)
        {
            for(int j=0;j<width;j++)
            {
                var tile = SelectTile(layout[i][j]);
                var newTile = Instantiate<BasicTile>
                    (
                        tile,
                        Tile.NeighbourPositions[0] * i + Tile.NeighbourPositions[1] * j,
                        tile.transform.rotation,
                        transform
                    );
                newTile.transform.parent = transform;
                newTile.TileId = (j, i);
                tileMeshes[i * width + j].mesh = newTile.GetComponent<MeshFilter>().mesh;
                print(newTile.GetComponent<MeshFilter>().mesh);
                tileMeshes[i * width + j].transform = newTile.transform.localToWorldMatrix;
                //newTile.gameObject.SetActive(false);
            }
        }
        var tilemapMesh = gameObject.AddComponent<MeshFilter>();
        tilemapMesh.mesh.CombineMeshes(tileMeshes);
        gameObject.GetComponent<MeshCollider>().sharedMesh = tilemapMesh.mesh;
    }
    private void FlatGen()
    {
        var zeroTile = Tile;
        var tileMeshes = new CombineInstance[Width * Length];
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Length; j++)
            {
                var newTile = Instantiate<BasicTile>
                    (
                        zeroTile,
                        Tile.NeighbourPositions[0] * i + Tile.NeighbourPositions[1] * j,
                        zeroTile.transform.rotation,
                        transform
                    );
                newTile.transform.parent = transform;
                newTile.TileId = (j, i);
                tileMeshes[i * Width + j].mesh = newTile.GetComponent<MeshFilter>().mesh;
                tileMeshes[i * Width + j].transform = newTile.transform.localToWorldMatrix;
                //newTile.gameObject.SetActive(false);
                //newTile.GetComponent<BoxCollider>().enabled = false;
            }
        }
        var tilemapMesh = gameObject.AddComponent<MeshFilter>();
        tilemapMesh.mesh.CombineMeshes(tileMeshes);
        gameObject.GetComponent<MeshCollider>().sharedMesh = tilemapMesh.mesh;
    }
}
