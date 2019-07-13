# TimeEditer
一个wpf实现的时间编辑控件，可以双向绑定。Hour、Minute、Seccond属性。
实现效果如下：
![](https://i.imgur.com/ztWzovb.gif)
## 如何使用：

     <local:TimeEditer 
	Hour="{Binding Hour,Mode=TwoWay}" 
	Minute="{Binding Minute,Mode=TwoWay}" 
	Second="{Binding Seccond,Mode=TwoWay}" 
	Width="90" Height="30" HorizontalAlignment="Left"/>
