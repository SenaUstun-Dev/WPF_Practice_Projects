   M S B A M L   `   `   `  ����E  AmyToDoList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:myToDoList
myToDoList  5   	   $    myToDoList.selectedChoreWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:myToDoList     5   	     � Title$  Chore Edit Window��5   	   $	��450��6#   $	��600��60      AppBackgroundBrush#��[  6<   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5      �� -   5        $��selectedTitle��5      $��0��5      $��0��5      $��2��5        mainHeaderStyle#��[ 5      $
��Left=�5      $��Segoe UI)�5      �� 5      -   5        $��selectedDeadline��5      $��1��5      #��[ 5        J� Opacity$
 0.85Q�5!      $��	0,-3,0,10q�5"      $
��Left=�5#      $��20(�5$      $��Segoe UI)�5%      �� 5(   
    �� Orientation$ 
Horizontal=�6   $��3��6.   $��1��6>   $��Right=�6K   $��Bottom=�6g   .+�5*      �� -   5        $��editChoreButton��5*      $
��Edit��5+      6$   �� 5-      -   5        $��deleteChoreButton��5-      $��Delete��5.      ���	#FFEE4D165/   ,   50      �� 53      -   5        $��selectedDescription��53      $��2��54      $��2��56       �� Padding$ 10q�57      $��20(�58      $
��Wrap=�59      ���	#99E0CD805:      5<      5=      