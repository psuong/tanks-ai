using UnityEngine;
using System.Collections;

public static class CircleMath {

    /// <summary>
    /// Generates a point on te edge of a 2D imaginary circle pointing
    /// towards the reference.
    /// </summary>
    /// <param name="angle">The angle from the origin</param>
    /// <param name="radius">The radius of the circle</param>
    /// <returns>A Vector2 representing a point on a circle.</returns>
    public static Vector2 GetEdge2D(float angle, float radius) {
        Vector2 vector = new Vector2();
        float radians = angle * Mathf.PI / 180f;

        vector.x = radius * Mathf.Cos(radians);
        vector.y = radius * Mathf.Sin(radians);

        return vector;
    }

    /// <summary>
    /// Returns a point on the edge of a 3D imaginary circle orientated towards 
    /// the Y axis.
    /// </summary>
    /// <param name="angle">The angle from origin</param>
    /// <param name="radius">The radius of the circle</param>
    /// <returns>A Vector3 representing a point on a circle.</returns>
    public static Vector3 GetEdgeY3D(float angle, float radius) {
        Vector3 vector = Vector3.zero;

        float radians = angle * Mathf.PI / 180f;

        vector.x = radius * Mathf.Cos(radians);
        vector.z = radius * Mathf.Sin(radians);

        return vector;
    }

}
