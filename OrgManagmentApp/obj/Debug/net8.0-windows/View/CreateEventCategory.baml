   M S B A M L   `   `   `  ����J  FOrgManagmentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:OrgManagmentApp.ViewOrgManagmentApp.View  5   	   .    (OrgManagmentApp.View.CreateEventCategory   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   4local"clr-namespace:OrgManagmentApp.View     5   	   $	��450��5   !   $	��800��6.     � Title  6	   �� *Title+.��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $*��$Название категории:��6   $��0,0,0,5q�5      �� 5   
   $��1��6   $��0,0,0,15q�5      ��5      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5   
   $��2��6   $��Описание:��5      $��0,0,0,5q�5      �� 5   
   $��3��6    �� TextWrapping$
 Wrap=�5       �� AcceptsReturn$
 True��5      $��Stretch=�5      ��5      �� *Description+$ PropertyChanged=�5      �� 5!   
   $��4��6    �� Orientation$ 
Horizontal=�5"      $��Right=�5#      $��0,15,0,0q�5$      .+�5%      �� $��Отмена��6   $��0,0,10,0q�5'      $
��20,5q�5(      ��5&      �� *CancelCommand+5(      �� 5)      $��Сохранить��6   $
��20,5q�5+      ��5*      �� *SaveCommand+5+      5,      5-      5.      