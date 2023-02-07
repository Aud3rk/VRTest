using System.Linq;
using HurricaneVR.Framework.Components;
using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using UnityEngine;

public class Grenade : HVRDamageProvider
{
    [SerializeField] private float _triggerPullThreshold = .7f;
    
    [SerializeField] private float _explosionRadius = 3f;
    [SerializeField] private float _explosionTime = 2f;

    private bool _activated;
    private HVRGrabbable _grabbable;
    void Start()
    {
        _grabbable = GetComponent<HVRGrabbable>();
    }
    public void Update()
    {
        CheckTriggerPull();
    }
    private void CheckTriggerPull()
    {
        if (!_grabbable.IsHandGrabbed | _activated)
            return;

        var controller = _grabbable.HandGrabbers[0].Controller;

        if (controller.Trigger > _triggerPullThreshold & !_activated)
        {
            _grabbable.Released.AddListener(Activate);
        }
    }
    public void Activate(HVRGrabberBase _grabberBase, HVRGrabbable _grabbable)
    {
        if(_activated) return;
        Invoke(nameof(Explode), _explosionTime);
        _activated = true;
    }
    private void Explode()
    {
        var colliders = Physics.OverlapSphere(transform.position, _explosionRadius).ToList();

        foreach (var col in colliders)
        {
            if (col.TryGetComponent(out HVRDamageHandlerBase damageHandler))
            {
                damageHandler.HandleDamageProvider(this, transform.position, (col.transform.position - transform.position));
            }
        }
        Destroy(gameObject);
    }
}
