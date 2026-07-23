using UnityEngine;
using UnityEngine.InputSystem;
public class SliceListener : MonoBehaviour
{
    private Vector2 swipeStart;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            swipeStart = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            Vector2 swipeEnd = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D[] hits = Physics2D.LinecastAll(swipeStart, swipeEnd);

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.TryGetComponent<SlicedItem>(out var item))
                {
                    item.Slice(swipeStart, swipeEnd);
                }
            }
        }
    }
}