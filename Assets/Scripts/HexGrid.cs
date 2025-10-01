using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    [field: SerializeField] public HexOrientation orientation { get; private set; }
    [field: SerializeField] public int Width { get; private set; }
    [field: SerializeField] public int Height { get; private set; }
    [field: SerializeField] public float HexSize { get; private set; }
    [field: SerializeField] public GameObject HexPreGab { get; private set; }

    private void OnDrawGizmos()
    {
        for (int z = 0; z < Height; z++)
        {
            for (int x = 0; x < Width; x++)
            {
                Vector3 centrePosition = HexMetrics.Center(HexSize, x, z, orientation) + transform.position;
                for (int s = 0; s < HexMetrics.Corners(HexSize, orientation).Length; s++)
                {
                    Gizmos.DrawLine(
                        centrePosition + HexMetrics.Corners(HexSize, orientation)[s % 6],
                        centrePosition + HexMetrics.Corners(HexSize, orientation)[(s + 1) % 6]
                    );
                }
            }
        }
    }
}
public enum HexOrientation
{
    FlatTop,
    PointyTop
}