using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class LetterContainer : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private TextMeshPro letter;
    [SerializeField] private SpriteRenderer letterContainer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
        letter.text = "";
        letterContainer.color = Color.white;
    }

    internal void SetLetter(char letter, bool isHint = false)
    {
        if (isHint)
            this.letter.color = Color.gray;
        else
            this.letter.color = Color.black;


        this.letter.text = letter.ToString();
    }
    internal char GetLetter()
    {
        return letter.text[0];
    }

    internal void SetValid()
    {
        letterContainer.color = Color.green;
        
        transform.DOScale(Vector3.zero, 0f);
        transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBounce);
    }

    internal void SetPotential()
    {
        letterContainer.color = Color.yellow;
    }

    internal void SetInvalid()
    {
        letterContainer.color = Color.gray;
    }


}
