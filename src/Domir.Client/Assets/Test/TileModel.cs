using UnityEngine;

public class TileModel
{
    public Vector3Int position;
    public TileType type;

    public TileModel(Vector3Int pos, TileType tileType)
    {
        position = pos;
        type = tileType;
    }
}