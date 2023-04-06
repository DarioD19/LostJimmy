using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePanel : MonoBehaviour
{
    [SerializeField] private Image _lifeImage;
    [SerializeField] private Color _damegeColor;
    [SerializeField] private Color _originalColor;
    
    public void ShowDamage()
    {
        _lifeImage.color = _damegeColor;
    }
    public void ResetColor()
    {
        _lifeImage.color = _originalColor;
    }
}
