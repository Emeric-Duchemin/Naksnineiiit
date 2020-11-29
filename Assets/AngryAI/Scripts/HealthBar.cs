using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MBaske.AngryAI;

public class HealthBar : MonoBehaviour
{
    [Header("Camera to be aligned to :")]
    public Camera mainCamera;

    private Fighter fighter; 

    MaterialPropertyBlock matBlock;
    MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        matBlock = new MaterialPropertyBlock();
    }

    private void Start()
    {
        // Cache since Camera.main is super slow
        mainCamera = Camera.main;
        fighter = transform.parent.gameObject.transform.parent.gameObject.transform.GetChild(0).gameObject.GetComponent<Fighter>();
    }

    private void Update()
    {

        int a = 3;
        if (fighter.life <= 10)
        {
            meshRenderer.enabled = true;
            AlignCamera();
            UpdateParams();
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }

    private void UpdateParams()
    {
        meshRenderer.GetPropertyBlock(matBlock);

        matBlock.SetFloat("_Fill", (float)fighter.life / 10f);
        meshRenderer.SetPropertyBlock(matBlock);
    }

    private void AlignCamera()
    {
        if (mainCamera != null)
        {
            var camXform = mainCamera.transform;
            var forward = transform.position - camXform.position;
            forward.Normalize();
            var up = Vector3.Cross(forward, camXform.right);
            transform.rotation = Quaternion.LookRotation(forward, up);
        }
    }
}
