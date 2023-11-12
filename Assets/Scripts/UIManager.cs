using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This class is a singleton! Only one instance should be created.
public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    private int _points;
    public int Points
    {
        get => _points;
        set
        {
            _points = value;
            // If the points text has been assigned, set the string.
            if (_pointsText)
            {
                _pointsText.text = _points.ToString();
            }
        }
    }

    [Header("Object Assignments")]
    [SerializeField] private TextMeshProUGUI _pointsText;

    /// <summary>
    /// Destroy this instance if a UIManager already exists, since
    /// this functions as a Singleton.
    /// </summary>
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

}
