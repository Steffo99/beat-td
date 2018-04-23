using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpriteOnHover : MonoBehaviour {

    public Sprite enter;
    public Sprite exit;
    
    private Image image;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    void OnMouseEnter()
    {
        image.sprite = enter;
    }

    void OnMouseExit()
    {
        image.sprite = exit;
    }

}
