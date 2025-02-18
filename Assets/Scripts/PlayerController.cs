using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 move, mouseLook;
    private Vector3 rotationTarget;
    public bool isPc;
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    public void OnMouseLook(InputAction.CallbackContext context)
    {
        mouseLook = context.ReadValue<Vector2>();
    }
    void Start()
    {

    }

    void Update()
    {
        if(isPc)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(mouseLook);

            if(Physics.Raycast(ray, out hit))
            {
                rotationTarget = hit.point;
            }

            movePlayerWithAim();
        }
        else
        {
            MovePlayer();
        }
    }

    public void MovePlayer()
    {
        Vector3 movemant = new Vector3(move.x, 0f, move.y);

        if(movemant != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movemant), 0.15f);
        }

        transform.Translate(movemant * speed * Time.deltaTime, Space.World);
    }

    public void movePlayerWithAim()
    {
        if(isPc)
        {
            var lookPos = rotationTarget - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);

            Vector3 aimDirection = new Vector3(rotationTarget.x, 0f, rotationTarget.z);
            if(aimDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.15f);
            }
        }

        Vector3 movemant = new Vector3(move.x, 0f, move.y);

        transform.Translate(movemant * speed * Time.deltaTime, Space.World);
    }
}
