using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    public GameObject player;
    private new Camera camera;
    private new Renderer renderer;
    public float Speed;
    
    public Renderer Object;
    public Material[] Materials;
    public Renderer TargetRenderer;
    private int _currentIndex = 0;
    public float health;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = Camera.main;
        renderer = GetComponent<Renderer>();
        TargetRenderer.material = Materials[_currentIndex];
        if (health <= 0)
        {
            health = 3;
        }
    }

    private void Update()
    {
        bool isVisible = GeometryUtility.TestPlanesAABB(
          GeometryUtility.CalculateFrustumPlanes(camera),
           renderer.bounds);
        if (_currentIndex >= Materials.Length) _currentIndex = 0;

        TargetRenderer.material = Materials[_currentIndex];
        _currentIndex++;

        if (!isVisible)
        { 
            TryMovingTowardsPlayer(); 
            _currentIndex++;
        }
            
    }

    private void TryMovingTowardsPlayer()
    {
        if (player == null)
            
            return;

        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        Vector3 lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        transform.rotation = Quaternion.LookRotation(lookPos);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            health--;
            Destroy(other.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    
    
}
