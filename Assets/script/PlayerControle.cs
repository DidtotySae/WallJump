using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControle : MonoBehaviour
{
    private Rigidbody2D _body;

    Vector2 _direction;

    [SerializeField]
    private float _vitesse = 4;
    [SerializeField] float _tempsArretSaut = 0.1f;
    float _tempArretSaut = 1;
    bool _peutSauter = true;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        _body.velocity = _direction;
    }

    // Update is called once per frame
    void Update()
    {
        _direction = new Vector2(Input.GetAxis("Horizontal") * _vitesse, _body.velocity.y);

        if (Input.GetAxis("Jump") > 1f && _peutSauter)
        {
            Debug.Log("peut sauter");
            _direction.y += 10;
            _peutSauter = false;
            _tempArretSaut = _tempsArretSaut;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_tempArretSaut <= 0)
        {
            _peutSauter = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _peutSauter = false;
    }
}