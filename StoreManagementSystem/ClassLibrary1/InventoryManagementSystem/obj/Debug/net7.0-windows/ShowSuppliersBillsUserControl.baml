   M S B A M L   `   `   `  ����T  PInventoryManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:InventoryManagementSystemInventoryManagementSystem  5      =    7InventoryManagementSystem.ShowSuppliersBillsUserControl   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:InventoryManagementSystem     5      .��5	      �   � ShowGridLines$  False��6    � RowDefinitions 5
   
   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   � $��0��6    � Orientation$ 
Horizontal=�6!   .+�5      �� $��0,0,0,1q�6   
�������$��5q�6C   ._�5      �� $��50��6   $��
20,20,30,0q�6)   .+�5      �� $��2q�6   $
��Left=�6(   
�������.��6V   Supplier Name6e   �� 5      -   5        $��comboSuppliersBills��5      ��5      �� 5      .R�5   "   � .+�5   &   �� ��60   ��  �� Path$
 Name�6M   5   #   5      5       5"      5#      �� 5%      $��0,0,0,1q�6   
�������$��5q�6C   ._�5&      �� $��50��6   $��
50,20,30,0q�6)   .+�5'      �� $��2q�6   $
��Left=�6(   
�������.��6V   Choose Supplier6g   �� 5(      -   5        $��chkSuppliersBills��5(      
�������.��6�   Select Supplier6�   5)      5*      5,      � 5.   
   $��1��6   .+�50      �� -   5        $��lvSuppliersBills��50   0   $	��800��6   $	��150��6#    �� SelectionMode$ Single=�6H    �� View 52      �� 54       �� AllowsColumnReorder$
 true��6    �� ColumnHeaderToolTip$ Customer Information��6:   .P�56      ��  �� Width$	 100��6)   	 �� DisplayMemberBinding	 65   �� *ID+.��57      �� .��63   Number59      5:      �� 5<      $	 150��6)   	 65   �� *Inventory.Location+.��5=      �� .��63   Inventory Name5?      5@      �� 5B      $	 200��6)   	 65   �� *Supplier.Name+.��5C      �� .��63   Supplier Name5E      5F      �� 5H      $	 150��6)   	 65   �� *
TotalPrice+.��5I      �� .��63   Total Price5K      5L      �� 5O      $	 100��6)   	 65   �� *	OrderedOn+.��5P      �� .��63   Date5R      5S      5U      5X      5Z      � 5\   
   $��2��6   $	��100��6!   $��225,0,225,0q�6-   .+�5]      �� -   5        $��btnSuppliersBillsShow��5]      $	��100��62   $��30��6>   
�������
��� � �$��2q�6q   
��� � �$��	0,20,10,0q�6�   .��6�   Show6�   5^      5`      5a      