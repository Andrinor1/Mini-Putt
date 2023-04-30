using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public GameObject tableRows;

    void Start()
    {
        Dictionary<string, int> levelPars = ScoreKeeper.Instance.getAllPars();

        for (int i = 0;i < levelPars.Count; i++)
        {
            GameObject newRow = new GameObject();
            newRow.name = "Table Row";
            newRow.AddComponent<CanvasRenderer>();
            newRow.AddComponent<LayoutElement>();
            newRow.GetComponent<LayoutElement>().minHeight = 100f;
            newRow.AddComponent<HorizontalLayoutGroup>();
            // We need to change the parameters of the horizontal layout group.
        }
    }
}
