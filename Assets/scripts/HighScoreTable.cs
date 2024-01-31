using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{
    public Transform entryTable;
    public Transform entryTemplate;
    void Awake()
    {
        //entryTable = transform.Find("ScoreTableContrainer");
        //entryTemplate = entryTable.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        float templateHight = 30f;
        for (int i = 0; i < 15; i++)
        {
           Transform entryTransform = Instantiate(entryTemplate, entryTable); 
           RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
           entryRectTransform.anchoredPosition = new Vector2(0, -templateHight * i);
           entryTransform.gameObject.SetActive(true);
        }
    }

}
