﻿using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScaleButtonPresenter : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text text;

    private int scaleSizeIndex;
    private Array scaleSizesValues;
    private int scaleSizesValuesLength;

    private void Awake()
    {
        scaleSizesValues = Enum.GetValues(typeof(UserPreferences.ScaleSizes));
        scaleSizesValuesLength = scaleSizesValues.Length;
        scaleSizeIndex = Enum.GetNames(typeof(UserPreferences.ScaleSizes)).ToList().IndexOf(UserPreferences.CustomScaleSize.ToString());
        button.onClick.AddListener(OnButtonClicked);
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        text.text = $"Scale: {(int) UserPreferences.CustomScaleSize}%";
    }

    private void OnButtonClicked()
    {
        scaleSizeIndex++;
        if (scaleSizeIndex >= scaleSizesValuesLength)
        {
            scaleSizeIndex -= scaleSizesValuesLength;
        }
        var scaleSize = (UserPreferences.ScaleSizes) scaleSizesValues.GetValue(scaleSizeIndex);
        UserPreferences.CustomScaleSize = scaleSize;
        
        UpdateButtonText();
    }
}
