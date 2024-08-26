using UnityEngine;
using ROS2;
using UnityEngine.UI;

public class HelloButton : MonoBehaviour
{
    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    private IPublisher<std_msgs.msg.String> chatter_pub;
    private int i = 0;
    // ボタンの参照
    [SerializeField] private Button button;
    // シーン読み込み時に呼び出される関数
    void Start()
    {
        TryGetComponent(out ros2Unity);
        // onClickに関数を登録
        button.onClick.AddListener(OnButton);
    }

    // フレーム更新時に呼び出される関数
    void Update()
    {
        if (ros2Unity.Ok())
        {
            if (ros2Node == null)
            {
                // Nodeの名前を指定する
                ros2Node = ros2Unity.CreateNode("ROS2UnityTalkerNode");
                //トピックの名前と型を指定する
                chatter_pub = ros2Node.CreatePublisher<std_msgs.msg.String>("hello_from_Unity");
            }
        }
    }

    // ボタンが押されたときに呼び出される関数
    void OnButton()
    {
        i++;
        std_msgs.msg.String msg = new std_msgs.msg.String();
        msg.Data = "unko world from Unity" + i;
        chatter_pub.Publish(msg);
    }
}
