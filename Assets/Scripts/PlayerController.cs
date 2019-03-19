using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera m_Camera;
    public LayerMask m_MovementMask;
    // Start is called before the first frame update
    void Start()
    {
        m_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, m_MovementMask))
            {
                // move our player to what we hit
                Debug.Log("we hit " + hit.collider.name + " " + hit.point);

                // stop focusing any object
            }
        }
    }
}
