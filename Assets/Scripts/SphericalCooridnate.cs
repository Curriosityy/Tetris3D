using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalCooridnate
{
    float _r, _phi, _theta;
    public float R { get => _r; set => _r = value; }
    public float Phi { get => _phi; set => _phi = value; }
    public float Theta { get => _theta; set => _theta = value; }

    public SphericalCooridnate(Vector3 pointToConvert)
    {
        _r = Mathf.Sqrt(Mathf.Pow(pointToConvert.x, 2) + Mathf.Pow(pointToConvert.y, 2) + Mathf.Pow(pointToConvert.z, 2));
        _theta = _r == 0 ? 0 : Mathf.Acos(pointToConvert.y / _r);
        _phi = pointToConvert.y == 0 ? 0 : Mathf.Atan(pointToConvert.z / pointToConvert.y);
    }
    public SphericalCooridnate(float r,float phi,float theta)
    {
        _r = r;
        _phi = phi;
        _theta = theta;
    }
    public Vector3 GetCartesianPoint()
    {
        return new Vector3(_r * Mathf.Sin(_theta) * Mathf.Cos(_phi), _r * Mathf.Sin(_theta) * Mathf.Sin(_phi), _r * Mathf.Cos(_theta));
    }
    public SphericalCooridnate RotateCoordinateBy(float phi,float theta)
    {
        return new SphericalCooridnate(_r, _phi + phi, _theta + theta);
    }

}
