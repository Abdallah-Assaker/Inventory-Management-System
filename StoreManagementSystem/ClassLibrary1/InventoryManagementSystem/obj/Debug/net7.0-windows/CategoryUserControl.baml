   M S B A M L   `   `   `  ����T  PInventoryManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:InventoryManagementSystemInventoryManagementSystem  5      3    -InventoryManagementSystem.CategoryUserControl   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:InventoryManagementSystem     5      .��5	      �   � ShowGridLines$  False��6    � RowDefinitions 5
   
   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   � $��0��6    � Orientation$ 
Horizontal=�6!   .+�5      �� $��0,0,0,1q�6   
�������$��5q�6C   ._�5      �� $��50��6   $��
20,20,30,0q�6)   .+�5      �� $��2q�6   $
��Left=�6(   
�������.��6V   Inventory Name6f   �� 5      -   5        $#��CategoryPage_InventoryComboBx��5      ��5      �� 5      .R�5   "   � .+�5   &   �� ��60   ��  �� Path$ Location�6Q   5   #   5      5       5"      5#      �� 5%      $��0,0,0,1q�6   
�������$��5q�6C   ._�5&      �� $��50��6   $��
50,20,30,0q�6)   .+�5'      �� $��2q�6   $
��Left=�6(   
�������.��6V   Category Name6e   �� 5(      -   5        $%��CategoryNameInCategoryPageTxtBx��5(   *   $	��200��6   ��6Q   ��  �� ElementName$ CategoryListView��$ SelectedItem.Name� �� Mode$ OneWay=�6�   5)      5*      5,      � 5.   
   $��1��6   $	��350��6!   $��225,0,225,0q�6-   .+�5/      �� -   5        $��AddNewCategory��5/      $	��100��6+   $��30��67   
�������
��� � �$��2q�6j   
��� � �$��	5,20,10,0q�6�   .��6�   New6�   �� 50      -   5        $��EditCategory��50      $	��100��6)   $��30��65   
�������
����  �$��2q�6g   
����  �$��	5,20,10,0q�6�   .��6�   Save6�   �� 51      -   5        $��DeleteCategory��51      $	��100��6+   $��30��67   
�������
���  ��$��2q�6h   
���  ��$��5,20,5,0q�6�   .��6�   Delete6�   52      � 54   
   $��2��6   .+�56      �� -   5        $��CategoryListView��56   0   $	��800��6   $	��150��6#    �� SelectionMode$ Single=�6H    �� View 58      �� 5:       �� AllowsColumnReorder$
 true��6   	 �� ColumnHeaderToolTip$	 Categories Information��6:   .P�5<      �� 
 �� Width$	
 100��6)    �� DisplayMemberBinding 65   �� *ID+.��5=      �� .��63   Number5?      5@      �� 5B      $	
 700��6)    65   �� *Name+.��5C      �� $
��Left=�63   .��6N   Category Name5E      5F      5H      5K      5M      5N      5P      