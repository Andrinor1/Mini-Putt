using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public GameObject tableRows;

    public void toMainMenu()
    {
        FreeplayManager.instance.isFreePlay = false;
        GameEvents.instance.ExitToMainMenu();
        SceneManager.LoadScene("MainMenu");
    }

    void Start()
    {
        Dictionary<string, int> levelPars = ScoreKeeper.instance.getPars();
        Dictionary<string, string> score = ScoreKeeper.instance.getScore();

        // Populate the score table
        for (int i = levelPars.Count; i > 0; i--)
        {
            // Create row
            GameObject newRow = createTableRow();

            // Create cells
            GameObject tableCell = createTableCell(newRow); // Level
            setCellText(tableCell, i.ToString());

            tableCell = createTableCell(newRow); // Par
            setCellText(tableCell, levelPars["Level" + i].ToString());

            tableCell = createTableCell(newRow); // Score
            try { setCellText(tableCell, score["Level" + i]); }
            catch { setCellText(tableCell, "None"); }
        }
    }

    private GameObject createTableRow()
    {
        // Initialize Row
        GameObject newRow = new GameObject();
        newRow.name = "Table Row";

        // Add necessary row components
        newRow.AddComponent<CanvasRenderer>();
        newRow.AddComponent<LayoutElement>();
        newRow.AddComponent<HorizontalLayoutGroup>();

        // Edit the row components
        LayoutElement layoutElement = newRow.GetComponent<LayoutElement>();
        HorizontalLayoutGroup horizontalLayoutGroup = newRow.GetComponent<HorizontalLayoutGroup>();
        layoutElement.minHeight = 100f;
        horizontalLayoutGroup.childControlWidth = true;
        horizontalLayoutGroup.childControlHeight = true;

        // Set the parent object and sibling order
        newRow.transform.SetParent(tableRows.transform, false);
        newRow.transform.SetAsFirstSibling();

        return newRow;
    }

    /* Creates a table cell and sets that cell to the parent of the game object given
     * 
     */
    private GameObject createTableCell(GameObject parent)
    {
        // Initialize Cell
        GameObject tableCell = new GameObject();
        tableCell.name = "Table Data";

        // Add necessary cell components
        tableCell.AddComponent<RectTransform>();
        tableCell.AddComponent<CanvasRenderer>();
        tableCell.AddComponent<TextMeshProUGUI>();
        tableCell.AddComponent<LayoutElement>();

        // Edit the cell components
        LayoutElement layoutElement = tableCell.GetComponent<LayoutElement>();
        TextMeshProUGUI textMeshProUGUI = tableCell.GetComponent<TextMeshProUGUI>();
        layoutElement.preferredWidth = 999f;
        textMeshProUGUI.enableAutoSizing = true;
        textMeshProUGUI.alignment = TextAlignmentOptions.Center;

        // Set the parent object
        tableCell.transform.SetParent(parent.transform, false);

        return tableCell;
    }

    private void setCellText(GameObject cell, string text)
    {
        TextMeshProUGUI textMeshProUGUI = cell.GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.text = text;
    }
}
