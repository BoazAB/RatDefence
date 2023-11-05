using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] private GameObject tower;
    [SerializeField] private float cooldown = 10;

    private void FixedUpdate()
    {
        Cooldown();
        Place();
    }
    private void Cooldown()
    {
        if (cooldown > 0)
        {
            cooldown -= 1 * Time.deltaTime;
        }
        else
        {
            cooldown = 0;
        }
    }
    private void Place()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero, 100);
            print(hit.transform.position);

            if (cooldown <= 0)
            {
                tower.transform.position = hit.transform.position + new Vector3(0,0,-1);
                Instantiate(tower);
                cooldown = 10;
            }
        }
    }
}
