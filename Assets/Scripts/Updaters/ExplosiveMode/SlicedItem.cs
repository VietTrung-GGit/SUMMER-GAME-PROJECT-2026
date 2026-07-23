using UnityEngine;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(PolygonCollider2D), typeof(SpriteRenderer))]
public class SlicedItem : MonoBehaviour
{
    private Action OnItemSliced;
    private Action OnItemOutOfView;
    private PolygonCollider2D polyCollider;
    protected bool isSliced = false;
    private void Awake()
    {
        polyCollider = GetComponent<PolygonCollider2D>();
    }

    public void SetUpSlicedItem(SlicedItemSO slicedItemSO)
    {
        OnItemSliced += slicedItemSO.ExecuteSlicedAction;
        OnItemOutOfView += slicedItemSO.ExecuteOutOfViewAction;
    }
    public void Slice(Vector2 lineStart, Vector2 lineEnd)
    {
        OnItemSliced?.Invoke();

        isSliced = true;

        Vector2[] points = polyCollider.points;

        List<Vector2> leftSidePoints = new List<Vector2>();
        List<Vector2> rightSidePoints = new List<Vector2>();

        Vector2 localStart = transform.InverseTransformPoint(lineStart);
        Vector2 localEnd = transform.InverseTransformPoint(lineEnd);

        for (int index = 0; index < points.Length; index++)
        {
            Vector2 currentPoint = points[index];
            //Add points from correct halves
            if (IsOnLeftSide(localStart, localEnd, currentPoint))
            {
                leftSidePoints.Add(currentPoint);
            }
            else
            {
                rightSidePoints.Add(currentPoint);
            }
            //Check for intersections with edges
            Vector2 nextPoint = points[(index + 1) % points.Length];
            if (TryGetIntersection(localStart, localEnd, currentPoint, nextPoint, out Vector2 intersection))
            {
                leftSidePoints.Add(intersection);
                rightSidePoints.Add(intersection);
            }
        }

        if (leftSidePoints.Count >= 3 && rightSidePoints.Count >= 3)
        {
            CreateSlicePiece(leftSidePoints, localStart, localEnd, true);
            CreateSlicePiece(rightSidePoints, localStart, localEnd, false);

            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    //2D Cross Product to determine which side of the line a point falls on
    private bool IsOnLeftSide(Vector2 a, Vector2 b, Vector2 point)
    {
        return ((b.x - a.x) * (point.y - a.y) - (b.y - a.y) * (point.x - a.x)) > 0;
    }

    //Parametric line segments intersection formula
    private bool TryGetIntersection(Vector2 a1, Vector2 a2, Vector2 b1, Vector2 b2, out Vector2 intersection)
    {
        intersection = Vector2.zero;
        Vector2 b = a2 - a1;
        Vector2 d = b2 - b1;
        float bDotDPerp = b.x * d.y - b.y * d.x;

        //Paralllel or Coincident
        if (Mathf.Abs(bDotDPerp) < 0.0001f)
        {
            return false;
        }

        Vector2 c = b1 - a1;
        float t = (c.x * d.y - c.y * d.x) / bDotDPerp;
        if (t < 0 || t > 1)
        {
            return false;
        }
        float u = (c.x * b.y - c.y * b.x) / bDotDPerp;
        if (u < 0 || u > 1)
        {
            return false;
        }
        intersection = a1 + t * b;
        return true;
    }

    private void CreateSlicePiece(List<Vector2> points, Vector2 lineStart, Vector2 lineEnd, bool isLeft)
    {
        GameObject slicedPiece = new GameObject(name + "_Slice");
        slicedPiece.transform.position = transform.position;
        slicedPiece.transform.rotation = transform.rotation;
        slicedPiece.transform.localScale = transform.localScale;

        slicedPiece.AddComponent<SlicedBombPiece>();

        MeshFilter mf = slicedPiece.AddComponent<MeshFilter>();
        MeshRenderer mr = slicedPiece.AddComponent<MeshRenderer>();
        mr.material = GetComponent<SpriteRenderer>().material;

        mf.mesh = GenerateMeshFromPoints(points.ToArray());

        Rigidbody2D rb = slicedPiece.AddComponent<Rigidbody2D>();
        Vector2 sliceNormal = Vector2.Perpendicular(lineEnd - lineStart).normalized;
        Vector2 pushDirection = isLeft ? -sliceNormal : sliceNormal;
        
        rb.AddForce(pushDirection * 5f, ForceMode2D.Impulse);
        rb.AddTorque(isLeft ? 10f : -10f, ForceMode2D.Impulse);
    }

    private Mesh GenerateMeshFromPoints(Vector2[] points)
    {
        Mesh mesh = new Mesh();
        
        Vector3[] vertices = new Vector3[points.Length];
        Vector2[] uvs = new Vector2[points.Length];

        for (int index = 0; index < points.Length; index++)
        {
            vertices[index] = points[index];
            //Map vertices to UVs (UV goes from 0 to 1)
            uvs[index] = new Vector2(points[index].x + 0.5f, points[index].y + 0.5f);
        }

        //Fan Triangulation (best for concave polygons)
        int[] triangles = new int[(points.Length - 2) * 3];
        int tIndex = 0;
        for (int index = 1; index < points.Length - 1; index++)
        {
            triangles[tIndex++] = 0;
            triangles[tIndex++] = index;
            triangles[tIndex++] = index + 1;
        }

        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }

    private void OnBecameInvisible()
    {
        if (!isSliced)
        {
            OnItemOutOfView?.Invoke();
            isSliced = false;
            gameObject.SetActive(false);
            gameObject.transform.localPosition = Vector3.zero;
        }
    }

}