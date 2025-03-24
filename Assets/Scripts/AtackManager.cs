using UnityEngine;



public class AtackManager : MonoBehaviour
{
    [SerializeField] private GameObject projectile; 
    public Transform shootOrigin;
    
    public void Shoot()
    {
        Instantiate(projectile, shootOrigin.position, transform.rotation);
    }
    public void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
}