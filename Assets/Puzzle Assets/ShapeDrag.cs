using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeDrag : MonoBehaviour
{
    private bool isDragged, correct;
    private Vector2 offset;
    private Vector2 og;

    public Transform slot;

    void Awake()
    {
        og = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (correct)
            return;
        if (!isDragged)
            return;
        var mousePos = GetMousePos();

        transform.position = mousePos;
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked!");
        isDragged = true;
        offset = GetMousePos() - (Vector2)transform.position;
    }

    void OnMouseUp()
    {
        if (correct)
            return;
        if (Vector2.Distance(transform.position, slot.transform.position) < 1)
        {
            transform.position = slot.transform.position;
            correct = true;
            transform.parent.GetComponent<ShapeVal>().validateShapes();
        }
        //transform.position = og;
        isDragged = false;
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}
