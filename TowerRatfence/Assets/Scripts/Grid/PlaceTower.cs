using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] private GameObject tower;

    private void Awake()
    {

    }

    private void OnMouseDown()
    {
        tower.transform.position = this.gameObject.transform.position + new Vector3(0,0,-1);
        Instantiate(tower);
    }
}
