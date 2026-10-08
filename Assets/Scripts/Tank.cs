using UnityEngine;
using UnityEngine.InputSystem;


public class Tank : MonoBehaviour
{
    #region ==SerializeField==
    [Header("オブジェクト参照")]
    [SerializeField] private Transform _topJoint;
    public Transform TopJoint
    {
        get
        {
            return _topJoint;
        }
    }

    [SerializeField] private Transform _cannonJoint;
    public Transform CannonJoint
    {
        get
        {
            return _cannonJoint;
        }
    }

    private Vector3 topAngls = Vector3.zero;
    private Vector3 cannonAngls = Vector3.zero;
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.wKey.isPressed == true)
        {
            transform.Translate(transform.forward * 5 * Time.deltaTime);
        }
        else if(Keyboard.current.sKey.isPressed == true) 
        {
            transform.Translate(transform.forward * -5 * Time.deltaTime);
        }
        else if (Keyboard.current.aKey.isPressed == true)
        {
            transform.Rotate(Vector3.up * -90 * Time.deltaTime);
        }
        else if (Keyboard.current.dKey.isPressed == true)
        {
            transform.Rotate(Vector3.up * 90 * Time.deltaTime);
        }

        //マウスの移動量を取得
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();
        Debug.Log($"マウスの移動量:{mouseDelta}");
        topAngls.y += mouseDelta.x * 0.1f;
        cannonAngls.x -= mouseDelta.y * 0.1f;

        //各ジョイントに角度を反映する
        _topJoint.localEulerAngles = topAngls;
        _cannonJoint.localEulerAngles = cannonAngls;
    }
}
