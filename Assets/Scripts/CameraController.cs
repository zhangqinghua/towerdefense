using UnityEngine;

public class CameraController : MonoBehaviour
{

    // public float maxX;
    // public float minX;

    // public float maxY;
    // public float minY;

    // public float moveSpeed = 100; // 设置相机移动速度   

    // private void Update()
    // {
    //     // 当按住鼠标右键的时候    
    //     if (Input.GetMouseButton(0))
    //     {
    //         // 获取鼠标的x和y的值，乘以速度和Time.deltaTime是因为这个可以是运动起来更平滑    
    //         float h = Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime;
    //         float v = Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime;
    //         // 设置当前摄像机移动，y轴并不改变    
    //         // 需要摄像机按照世界坐标移动，而不是按照它自身的坐标移动，所以加上Spance.World  
    //         if (transform.position.x > maxX && h < 0)
    //         {
    //             h = 0;
    //         }
    //         if (transform.position.x < minX && h > 0)
    //         {
    //             h = 0;
    //         }
	// 		h = 0;

    //         if (transform.position.z > maxY && v < 0)
    //         {
    //             v = 0;
    //         }

    //         if (transform.position.z < minY && v > 0)
    //         {
    //             v = 0;
    //         }

    //         transform.Translate(-h, 0, -v, Space.World);
    //     }
    // }

    // public float speed = 10f;
    // Vector2 p1, p2;//用来记录鼠标的位置，以便计算移动距离  
    // void Start()
    // {

    // }
    // void Update()
    // {
    //     ///<说明>  
    //     /// 通过鼠标X坐标拖动场景  
    //     ///   
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         //鼠标左键按下时记录鼠标位置p1   
    //         p1 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //     }
    //     if (Input.GetMouseButton(0))
    //     {
    //         //鼠标左键拖动时记录鼠标位置p2     
    //         p2 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //         if (transform.position.x >= 20 && transform.position.x <= 50)  //控制在20-130之内    
    //         {
    //             float dx = speed * (p2.x - p1.x);

    //             float dy = p2.y - p1.y;
    //             //鼠标左右移动    
    //             // transform.Translate(-dx * Vector3.right * Time.deltaTime);
    // 			transform.Translate(-dy * Vector3.forward * Time.deltaTime);
    //         }
    //         else if (transform.position.x < 20 && p2.x < p1.x)
    //         {
    //             float dx = speed * (p2.x - p1.x);

    //             float dy = p2.y - p1.y;
    //             //鼠标左右移动    
    //             // transform.Translate(-dx * Vector3.right * Time.deltaTime);
    // 			transform.Translate(-dy * Vector3.forward * Time.deltaTime);
    //         }
    //         else if (transform.position.x > 50 && p2.x > p1.x)
    //         {
    //             float dx = speed * (p2.x - p1.x);

    //             float dy = p2.y - p1.y;
    //             //鼠标左右移动    
    //             // transform.Translate(-dx * Vector3.right * Time.deltaTime);
    // 			transform.Translate(-dy * Vector3.forward * Time.deltaTime);
    //         }




    //         p1 = p2;
    //     }
    //     //通过鼠标滚轮实现场景缩放  
    //     //鼠标滚轮的效果  
    //     //Camera.main.fieldOfView 摄像机的视野  
    //     //Camera.main.orthographicSize 摄像机的正交投影  
    //     //Zoom out  
    //     if (Input.GetAxis("Mouse ScrollWheel") < 0)
    //     {
    //         if (Camera.main.fieldOfView <= 60)
    //             Camera.main.fieldOfView += 2;
    //         if (Camera.main.orthographicSize <= 20)
    //             Camera.main.orthographicSize += 0.5F;
    //     }
    //     //Zoom in  
    //     if (Input.GetAxis("Mouse ScrollWheel") > 0)
    //     {
    //         if (Camera.main.fieldOfView > 30)
    //             Camera.main.fieldOfView -= 2;
    //         if (Camera.main.orthographicSize >= 1)
    //             Camera.main.orthographicSize -= 0.5F;
    //     }

    // }

    // private Vector2 first = Vector2.zero;
    // private Vector2 second = Vector2.zero;
    // public float speed = 0.7f;

    // void OnGUI()
    // {
    //     if (Event.current.type == EventType.MouseDown)
    //     {
    //         //记录鼠标按下的位置 　　  
    //         first = Event.current.mousePosition;
    //     }
    //     if (Event.current.type == EventType.MouseDrag)
    //     {
    //         //记录鼠标拖动的位置 　　  
    //         second = Event.current.mousePosition;

    // 		transform.Translate((second.x < first.x ? Vector3.right : Vector3.left) * speed);

    // 		Quaternion rotate = transform.rotation;
    // 		transform.rotation = Quaternion.identity;
    //         transform.Translate((second.y < first.y ? Vector3.back : Vector3.forward) * speed);
    // 		transform.rotation = rotate;

    //         first = second;
    //     }
    // }

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    // Update is called once per frame
    void Update1()
    {
        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

    }

    public void Up()
    {
        transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
    }

    public void Down()
    {
        transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
    }

    public void Left()
    {
        transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
    }

    public void Right()
    {
        transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
    }
}
