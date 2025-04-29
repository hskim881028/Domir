using UnityEngine;
using UnityEngine.UI;

public class MapUI : MonoBehaviour
{
    public Button generateButton;
    public MapGenerator generator;

    void Start()
    {
        generateButton.onClick.AddListener(generator.GenerateMap);
    }
}