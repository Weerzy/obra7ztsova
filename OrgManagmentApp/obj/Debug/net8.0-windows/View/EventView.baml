   M S B A M L   `   `   `  ����J  FOrgManagmentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:OrgManagmentApp.ViewOrgManagmentApp.View  5   	   $    OrgManagmentApp.View.EventView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   4local"clr-namespace:OrgManagmentApp.View     5   	   $	��450��5   !   $	��800��6.     � Title  6	   �� *Title+.��5	      � $��20q�6    � RowDefinitions 5
      �� 5   
   $
��Auto �6   �� 5   
   $��* �6   �� 5   
   $
��Auto �6    � ColumnDefinitions 5      �� 5   
   $��* �6   �� 5   
   $��* �6   .+�5      �� $��0��6   .+�5   
   �� $��Название:��6   �� 5   
   $	��0,5q�6o   ��6   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�" �� ValidatesOnNotifyDataErrors$
 True��.��6|   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property �@=�ErrorTemplate �� Value 5      �� 5      .R�5   "   ]� $
��True��6,   .+�5   &   �� 
���  ��$��Right=�6A   ��6X   ��  �� Path$) #(Validation.Errors)[0].ErrorContent��� 5    &   5!   #   5"      5$      5%      .��5&      5'      �� 5(   
   $��	Дата:��6   (  "System.Windows.Controls.DatePicker  5)   
   	   SelectedDate	 6   �� *Date+$ PropertyChanged=�
 �� ValidatesOnDataErrors$

 True���� 5*   
   $��Категория:��6   �� 5+   
    �� DisplayMemberPath$
 Name��5-      $	��0,5q�5.      ��5+      �� *
Categories+ �� SelectedItem 5,      �� *SelectedCategory+5.      �� 5/   
   $��Организатор:��6   �� 50   
   $ 	FirstName��52      $	��0,5q�53      ��50      �� *
Organizers+ 51      �� *SelectedOrganizer+53      �� 54   
   $&�� Место проведения:��6   �� 55   
   $	��0,5q�57      ��55      �� *	Addresses+ 56      �� *SelectedAddress+��58      �� 59      .R�5:      ��  �� Orientation$ 
Horizontal=�6!   .+�5;      �� ��6$   �� *	Address+�� 5<      $�� (Аудитория: ��6$   $��5,0,0,0q�69   �� 5=      ��6$   �� *VenueNumber+�� 5>      $ ��, Вместимость: ��6$   �� 5?      ��6$   �� *
Capacity+�� 5@      $��)��6$   5A      5B      5D      5E      �� 5H      $��1��6   $��20,0,0,0q�6!   .+�5I   
   �� $!��Уровни билетов��6   .��5J      �� .+�5L      &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��5M         
IsReadOnly$
 True��5N      $	��200��5O      $��0,0,0,10q�5P      ��5L      �� *SelectedTicketLevels+   Columns 5Q      0  *System.Windows.Controls.DataGridTextColumn  5R      ,  &System.Windows.Controls.DataGridColumn   Header$ Уровень��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *
Level.Name+  5S      $ Цена��6-    6;   �� *Price+4  .System.Windows.Controls.DataGridTemplateColumn  5T         CellTemplate 5U      �� 5V   "   .R�5W   &   �� $��Удалить��6-   ��5X   -   �� *&$DataContext.RemoveTicketLevelCommand+ �� RelativeSource ��  �� AncestorType DataGrid��5Z   -   �� 5[   #   5]      5_      �� 5b      $4��.Добавить уровень билетов��6   .��5c      �� $��5q�6!   .+�5d      �� $��Уровень:��6    �� 5e      $
 Name��5g   #   $��0,0,0,5q�5h   #   ��5e   #   �� *AvailableLevels+ 5f   #   �� *SelectedLevel+5h   #   �� 5j      $��	Цена:��6    �� 5k      $��0,0,0,5q�5m   "   ��5k   "   �� *TicketPrice+$ PropertyChanged=�$
 True��5m   "   �� 5o      $%��Добавить уровень��6!   $��Right=�5q   !   $��0,5,0,0q�5r   !   ��5p   !   �� *AddTicketLevelCommand+5r   !   5s      5t      5u      5v      5w      �� 5y      $��Сохранить��6   $��2��5{      $��2��5|      $��Right=�5}      $��0,20,0,0q�5~      ��5z      �� *SaveEventCommand+5~      5      5�      