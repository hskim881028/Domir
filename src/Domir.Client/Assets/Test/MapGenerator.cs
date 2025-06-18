using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [Header("맵 설정")]
    public int width = 50;
    public int height = 50;
    public float scale = 8f;
    public float falloffPower = 2f;

    [Header("타일")]
    [SerializeField] private Tilemap _groundTilemap;
    [SerializeField] private Tilemap _waterTilemap;
    public TileBase waterTile;
    public TileBase landTile;

    public List<TileModel> tileModels = new List<TileModel>();

    private bool[,] landMap;
    private bool[,] visited;
    private int seed;

    public void GenerateMap()
    {
        seed = Random.Range(0, 100000);
        _groundTilemap.ClearAllTiles();
        _waterTilemap.ClearAllTiles();
        tileModels.Clear();

        landMap = new bool[width, height];
        visited = new bool[width, height];

        // Step 1: Generate map data with falloff
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                bool isEdge = (x == 0 || y == 0 || x == width - 1 || y == height - 1);
                if (isEdge)
                {
                    landMap[x, y] = false;
                }
                else
                {
                    float noise = GetIslandNoise(x, y);
                    landMap[x, y] = noise > 0.3f;
                }
            }
        }

        // Step 2: Keep only the largest connected land
        List<Vector2Int> largestLand = GetLargestLandRegion();

        // Step 3: Draw tilemap & create model list
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                TileType type;

                if (largestLand.Contains(new Vector2Int(x, y)))
                {
                    _groundTilemap.SetTile(pos, landTile);
                    type = TileType.Land;
                    RefreshSurroundingTiles(pos);
                }
                else
                {
                    _waterTilemap.SetTile(pos, waterTile);
                    type = TileType.Water;
                }

                tileModels.Add(new TileModel(pos, type));
            }
        }
    }

    float GetIslandNoise(int x, int y)
    {
        float noise = Mathf.PerlinNoise((x + seed) / scale, (y + seed) / scale);

        float xNorm = (float)x / width * 2f - 1f;
        float yNorm = (float)y / height * 2f - 1f;
        float dist = Mathf.Max(Mathf.Abs(xNorm), Mathf.Abs(yNorm));
        float falloff = Mathf.Pow(dist, falloffPower);

        return noise - falloff;
    }

    List<Vector2Int> GetLargestLandRegion()
    {
        List<Vector2Int> largest = new List<Vector2Int>();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (!visited[x, y] && landMap[x, y])
                {
                    List<Vector2Int> region = FloodFill(x, y);
                    if (region.Count > largest.Count)
                        largest = region;
                }
            }
        }

        return largest;
    }

    List<Vector2Int> FloodFill(int startX, int startY)
    {
        List<Vector2Int> result = new List<Vector2Int>();
        Queue<Vector2Int> queue = new Queue<Vector2Int>();
        queue.Enqueue(new Vector2Int(startX, startY));

        while (queue.Count > 0)
        {
            Vector2Int current = queue.Dequeue();
            int x = current.x;
            int y = current.y;

            if (x < 0 || y < 0 || x >= width || y >= height)
                continue;

            if (visited[x, y] || !landMap[x, y])
                continue;

            visited[x, y] = true;
            result.Add(current);

            queue.Enqueue(new Vector2Int(x + 1, y));
            queue.Enqueue(new Vector2Int(x - 1, y));
            queue.Enqueue(new Vector2Int(x, y + 1));
            queue.Enqueue(new Vector2Int(x, y - 1));
        }

        return result;
    }
    
    void RefreshSurroundingTiles(Vector3Int center)
    {
        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                Vector3Int pos = new Vector3Int(center.x + dx, center.y + dy, 0);
                _groundTilemap.RefreshTile(pos);
            }
        }
    }
}
