﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NavigationButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject navBtn;
    public Button scaleBtn;
    public Button rotateBtn;
    public Button deleteBtn;
    public Button markBtn;
    public GameObject editPlane;

    //public GameObject Canvas;
    public GameObject MarkMenu;


    private Map Map;
    private Button editableObject;
    private bool editActive = false;
    private bool showNav = false;

    void Start()
    {
        Map = GameObject.Find("Map").GetComponent<Map>();
        editableObject = gameObject.GetComponent<Button>();

        deleteBtn.onClick.AddListener(() => {
            DeleteElement();
        });

        rotateBtn.onClick.AddListener(() => {
            RotateElement();
        });

        editableObject.onClick.AddListener(() =>
        {
            /*foreach (GameObject item in Map.GetAllElementsInScene())
            {
                bool thisNav = item.GetComponent<NavigationButton>().showNav;
                if (thisNav == true)
                {
                    thisNav = false;
                    ToggleInterface(item, thisNav);
                }
            }*/

            showNav = !showNav;
            ToggleInterface(editableObject.gameObject, showNav);
        });

        markBtn.onClick.AddListener(() =>
        {
            showMarks();
        });

        /*editBtn.onClick.AddListener(() => {
            ToggleEditElement();
        });*/
    }

    public void DeleteElement()
    {
        Destroy(gameObject);
    }

    public void RotateElement()
    {
        navBtn.transform.Rotate(0f, 0f, -90f);
        gameObject.transform.Rotate(0f, 0f, 90f);
    }

    public void ToggleInterface(GameObject whoseNav, bool isShow)
    {
        navBtn.SetActive(isShow);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 2)
            OnDoubleClick();
    }

    void OnDoubleClick()
    {
        if(gameObject.GetComponent<Element>().additionallyInfo.Count > 0)
        {
            ToggleInterface(gameObject, false);
            ToggleEditPlane(true);
        }
    }

    public void showMarks()
    {
        // GameObject List = Instantiate(MarkMenu); 
        //List.transform.SetParent(Canvas.transform);

        if (MarkMenu.activeInHierarchy)
        {
            MarkMenu.SetActive(false);
        }
        else
        {
            MarkMenu.SetActive(true);
        }
    }

    public void ToggleEditPlane(bool editValue) {
        foreach (GameObject item in gameObject.GetComponent<Element>().additionallyInfo)
        {
            gameObject.GetComponent<EditButton>().GetListChangedInput().Add(item.GetComponent<InputField>().text);
        }

        editActive = editValue;
        editPlane.SetActive(editActive);
    }
}
