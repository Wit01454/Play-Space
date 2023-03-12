using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameSetterCanvas : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _Input;

    private void Awake()
    {
        _Input.onSubmit.AddListener(_input_OnSumit);
    }

    private void _input_OnSumit(string text)
    {
        PlayerNameTracker.SetName(text);
    }
}
