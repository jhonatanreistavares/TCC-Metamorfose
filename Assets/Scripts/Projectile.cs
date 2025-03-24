using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileTime = 3f;
    [SerializeField] private float projectileVelocity = 100f;
    [SerializeField] private int projectileDamage = 50;

    [SerializeField]private LayerMask layerMask; 
    private float projectileSmoothTime;
    private float projectileSmoothVelocity;
    private void Update()
    {

        float velocity = Mathf.Lerp(0.0f, projectileVelocity, projectileTime);

        //faz o projetil andar
        transform.position += transform.forward * velocity * Time.deltaTime;
        
        //tempo de vida do projetil
        projectileTime -= Time.deltaTime;

        if(projectileTime < 0.0f)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entrou");
       /* if(other.gameObject.layer == layerMask)
        {
            Destroy(this.gameObject);
        }
        else
        {
            return;
        }
        */
    }
}
