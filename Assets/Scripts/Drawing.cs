using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _brush;

    private LineRenderer _currentLineRenderer;

    private Vector2 _lastPosition;

    private void Update()
    {
        Draw();
    }

    private void Draw()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateBrush();
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
                PointToMousePosition();
        }

        else
        {
            _currentLineRenderer = null;
        }
    }

    private void CreateBrush()
    {
        GameObject brushInstance = Instantiate(_brush);
        _currentLineRenderer = brushInstance.GetComponent<LineRenderer>();


        Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);

        _currentLineRenderer.SetPosition(0, mousePos);
        _currentLineRenderer.SetPosition(1, mousePos);

    }

    private void AddAPoint(Vector2 pointPos)
    {
        _currentLineRenderer.positionCount++;
        int positionIndex = _currentLineRenderer.positionCount - 1;
        _currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

    private void PointToMousePosition()
    {
        Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        if (_lastPosition != mousePosition)
        {
            AddAPoint(mousePosition);
            _lastPosition = mousePosition;
        }
    }

}

