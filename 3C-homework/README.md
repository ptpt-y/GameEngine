# 3C框架游戏demo
- 控制小男孩在森林中随意走动，摘取蘑菇，尝一尝看会发生什么！哦对了，靠近小怪物时它们会跟着你哦。
- 工程文件夹：/3C-demo
- 打包文件夹： /build
- 可直接运行3C-demo.exe

## 具体玩法
### Character

- 小男孩

  - 由玩家控制在场景中随意走动，拾取蘑菇。

  - 有背包系统，可存储、丢弃、使用背包中的蘑菇。

  - 有多种动画状态（idle, walk, run, jump-up, jump-float, jump-down）

    ![pickup.gif](https://github.com/ptpt-y/GameEngine/blob/master/3C-homework/pics/pickup.gif)

- 蘑菇

  - 黄蘑菇：吃了之后会让人变大

  - 红蘑菇：吃了之后会让人变小

  - 紫蘑菇：吃了之后会跳一下

    ![mushrooms.gif](https://github.com/ptpt-y/GameEngine/blob/master/3C-homework/pics/mushrooms.gif)

- 小怪物：

  - 当小男孩靠近后，小怪物会跟随男孩移动，二者相隔超过一定距离时停止跟随。

  - 小怪物也有多种动画状态

    ![follower.gif](https://github.com/ptpt-y/GameEngine/blob/master/3C-homework/pics/follower.gif)

### Controller

- 鼠标
  - 点击**左键**，控制小男孩的移动。
  - 使用**右键**点击蘑菇，小男孩将朝蘑菇移动，到达附近后拾取蘑菇。
  - 打开背包后，使用**左键**点击物品可使用该物品，点击删除按钮可丢弃该物品。
  - 使用**滚轮**控制相机远近
- 键盘
  - **A/D**： 控制相机向左/右旋转
  - **I/B：**控制背包系统UI的打开和关闭（第一次打开的时候可能会有一点卡……）
  - 按下**esc**退出游戏

### Camera

- 相机跟随人物移动

- A/D 控制相机向左/右旋转

- 鼠标滚轮控制相机远近

  ![camera.gif](https://github.com/ptpt-y/GameEngine/blob/master/3C-homework/pics/camera.gif)