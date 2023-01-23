using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteShapeTest : MonoBehaviour
{

    [SerializeField] SpriteShapeRenderer _spriteShapeRenderer;
    [SerializeField] SpriteShapeController _spriteShapeController;

    void Awake()
    {
        _spriteShapeController = GetComponent<SpriteShapeController>();
        _spriteShapeRenderer = GetComponent<SpriteShapeRenderer>();

    }

    void Start()
    {
        // _spriteShapeController.spline.InsertPointAt(4, new Vector3(2f, 0.5f));
        // var numSplinePoints = _spriteShapeController.spline.GetPointCount();
         /*for (int i = 0; i < numSplinePoints; i++)
        {
//           Debug.Log(_spriteShapeController.spline.GetPosition(i)); 
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSprite(List<Vector3> points)
    {
        _spriteShapeController.spline.Clear();
        for (int i = points.Count - 1; i >= 0; i--)
        {
            _spriteShapeController.spline.InsertPointAt(0, points[i]);
        }
        /*foreach (var point in points)
        {
            // _spriteShapeRenderer.
            _spriteShapeController.spline.InsertPointAt(-1, point);
            
        }*/
    }
}
