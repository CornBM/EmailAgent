下面直接开始介绍文件结构
├─EmailAgent //项目主体
│  ├─bin //编译时产生的数据，不要删除，因为里面装着启动时要用的data
│  │  └─Debug 
│  │      └─data //里面有账号密码信息以及邮箱与服务器的对应数据
│  ├─model //关键代码，有Account和EmailContent两个主要的类，还有一个SMTP工具类，在获取SMTP服务器地址时候用
│  ├─Properties //vs项目需要的东西，我还不知道是干嘛的
│  └─tool //里面有一些工具类
│
│
│	//然后这个目录里面剩余的其它文件都和GUI相关，可以不用看
│
│
└─packages //用到的包，不用管
    └─FreeSpire.Doc.12.2.0
        └─lib
            ├─net40
            ├─net48
            ├─net6.0
            └─netstandard2.0


目前就支持qq邮箱和tu.scu.edu.cn校园邮箱
但是理论上可以支持任何邮箱
只要在data文件夹中的server.csv中添加想要支持的邮箱的相关信息就可以了