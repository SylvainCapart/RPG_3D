using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    private Camera m_Camera;
    [SerializeField] private LayerMask m_MovementMask;
    private PlayerMotor m_Motor;

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = Camera.main;
        m_Motor = GetComponent<PlayerMotor>();
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
                m_Motor.MoveToPoint(hit.point);
                // move our player to what we hit
                Debug.Log("we hit " + hit.collider.name + " " + hit.point);

                // stop focusing any object
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {

            }
        }
    }
}
