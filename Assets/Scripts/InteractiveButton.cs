using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// This class controls the images of a button so that a different effect happens for hover and active.
/// </summary>
public class InteractiveButton : MonoBehaviour
{
    public Sprite normal;
    public Sprite hover;
    public Sprite active;
    private Image buttonImage;
    private Color originalColor;


    /// <summary>
    /// This method sets the buttonImage attribute and normal Sprite. 
    /// </summary>
    void Start()
    {
        buttonImage = GetComponent<Image>();
        originalColor = buttonImage.color;

        buttonImage.sprite = normal;
    }

    /// <summary>
    /// This is the hover effect.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        Color hoverColor = originalColor;
        hoverColor.a = 50f;
        buttonImage.color = hoverColor;
        buttonImage.sprite = hover;
    }

    /// <summary>
    /// This is the end of the hover effect.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        // Change the button's image back to the normal sprite.
        buttonImage.color = originalColor;
        buttonImage.sprite = normal;
    }

    /// <summary>
    /// This is the active effect.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        // Change the button's image to the active sprite.
        buttonImage.sprite = active;
    }

    /// <summary>
    /// This is the end of the active effect.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        // Change the button's image back to the normal sprite.
        buttonImage.sprite = normal;
    }



}
