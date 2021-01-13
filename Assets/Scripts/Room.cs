using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    private Camera Cam;
    private string markName;
    public GameObject textMark;
    private Button room;
    public Dropdown dropdownMark;
    private List<string> allMarks = new List<string> { "Спортзал", "Столовая", "Кабинет" };

    void Start()
    {
        room = GetComponent<Button>();
        dropdownMark.AddOptions(allMarks);
    }

    void Update()
    {
        CreateMark(allMarks[dropdownMark.value-1]);
        fieldMark();
    }

    public void CreateMark(string markName) {
        this.markName = markName;
    }

    private void fieldMark()
    {
        textMark.GetComponent<Text>().text = this.markName;
    }

}
