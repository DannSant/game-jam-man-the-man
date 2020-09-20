﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UITest : MonoBehaviour
{
    [SerializeField] Slider raycastSlider;
    [SerializeField] Text raycastValue;
    [SerializeField] CharController2D controller;
    [SerializeField] GameObject panel;

    bool openWindow = true;

    public void ChangeRaycastValue()
    {
        float raycast = raycastSlider.value;
        raycastValue.text = raycast.ToString();
        controller.raycastRange = raycast;

    }

    public void ToggleWindow()
    {
        openWindow = !openWindow;
        panel.SetActive(openWindow);
    }
}
