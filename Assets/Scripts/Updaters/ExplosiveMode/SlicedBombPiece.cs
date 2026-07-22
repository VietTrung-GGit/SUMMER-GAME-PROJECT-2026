using UnityEngine;

public class SlicedBombPiece : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}