using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

enum Validity
{
    None,
    Valid,
    Potential,
    Invalid
}

public class KeyboardKey : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI letterText;
    [SerializeField] private Image renderer;

    [Header("Settings")]
    private Validity validity;

    [Header("Events")]
    public static Action<char> onKeyPressed;

    

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SendKeyPressedEvent);
        Initialize();
    }

    private void SendKeyPressedEvent()
    {
        onKeyPressed?.Invoke(letterText.text[0]);
    }

    internal bool IsUntouched()
    {
        return validity == Validity.None;
    }

    internal char GetLetter()
    {
        return letterText.text[0];
    }

    public void Initialize()
    {
        renderer.color = Color.white;
        validity = Validity.None;
    }

    internal void SetValid()
    {
        renderer.color = Color.green;
        validity = Validity.Valid;
    }

    internal void SetPotential()
    {
        if (validity == Validity.Valid)
            return;

        renderer.color = Color.yellow;
        validity = Validity.Potential;
    }

    internal void SetInvalid()
    {
        if (validity == Validity.Valid || validity == Validity.Potential) 
            return;

        renderer.color = Color.grey;
        validity = Validity.Invalid;
    }
}
