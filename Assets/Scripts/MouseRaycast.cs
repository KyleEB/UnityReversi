using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRaycast : MonoBehaviour
{
    public Camera playerCamera;
    
    public Vector3 currentPosition;

    public Vector3 clickedPosition;

    public Collider currentRowCollider;
    public Collider currentColCollider;

    public Collider clickedRowCollider;
    public Collider clickedColCollider;

    public int clickedRowNumber;
    public int clickedColNumber;


    public LayerMask rowLayerMask;
    public LayerMask colLayerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentRowCollider = getCollider(rowLayerMask);
        currentColCollider = getCollider(colLayerMask);

        if (currentRowCollider != null && currentColCollider != null)
        {
            currentPosition = new Vector3(currentRowCollider.transform.position.x, 0f, currentColCollider.transform.position.z);
        }

        if (Input.GetMouseButtonDown(0))
        {
            clickedRowCollider = currentRowCollider;
            clickedColCollider = currentColCollider;
            clickedPosition = currentPosition;

            clickedRowNumber = int.Parse(clickedRowCollider.name.Substring(clickedRowCollider.name.Length - 1, 1));
            clickedColNumber = int.Parse(clickedColCollider.name.Substring(clickedColCollider.name.Length - 1, 1));
        }
    }

    public Collider getCollider(LayerMask layerMask)
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            return hit.collider;   
        }
        
        return null;
        
    }
}
