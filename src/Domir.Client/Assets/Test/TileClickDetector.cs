using UnityEngine;
using UnityEngine.Tilemaps;

public class TileClickDetector : MonoBehaviour
{
    public MapGenerator mapGenerator;
    public Tilemap tilemap;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int tilePos = tilemap.WorldToCell(worldPos);

            // 모델 리스트에서 찾기
            TileModel model = mapGenerator.tileModels.Find(t => t.position == tilePos);

            if (model != null)
            {
                Debug.Log($"📍 타일 좌표: {tilePos} | 타입: {model.type}");
            }
            else
            {
                Debug.Log($"❌ 해당 좌표에 타일 없음: {tilePos}");
            }
        }
    }
}