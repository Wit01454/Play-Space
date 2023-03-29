using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class NameSetterCanvas : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _Input;


    private void Awake()
    {
        _Input.onEndEdit.AddListener(_input_OnEndEdit);
    }

    private void _input_OnEndEdit(string text)
    {
        PlayerNameTracker.SetName(text);
    }


}
