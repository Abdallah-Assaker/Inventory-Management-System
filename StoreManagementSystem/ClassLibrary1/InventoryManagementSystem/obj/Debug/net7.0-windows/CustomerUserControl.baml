   M S B A M L   `   `   `  ����T  PInventoryManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:InventoryManagementSystemInventoryManagementSystem  5      3    -InventoryManagementSystem.CustomerUserControl   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:InventoryManagementSystem     5      .��5	      �   � ShowGridLines$  False��6    � RowDefinitions 5
   
   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   � $��0��6    � Orientation$ 
Horizontal=�6!   .+�5      �� $��0,0,0,1q�6   
�������$��5q�6C   ._�5      �� $��50��6   $��
50,20,30,0q�6)   .+�5      �� $��2q�6   $
��Left=�6(   
�������.��6V   Name6\   �� 5      -   5        $��txtCustomerPageName��5   *   $	��200��6   6H   5      5      �� 5      $��0,0,0,1q�6   
�������$��5q�6C   ._�5      �� $��50��6   $��
50,20,30,0q�6)   .+�5      �� $��2q�6   $
��Left=�6(   
�������.��6V   Phone6]   �� 5      -   5        $��txtCustomerPhone��5   *   $	��200��6   6E   5       5!      5#      � 5%   
   $��1��6   $	��350��6!   $��225,0,225,0q�6-   .+�5&      �� -   5        $��btnAddCustomerPage��5&      $	��100��6/   $��30��6;   
�������
��� � �$��2q�6n   
��� � �$��	5,20,10,0q�6�   .��6�   New6�   �� 5'      -   5        $��btnUpdateCustomerPage��5'      $	��100��62   $��30��6>   
�������
����  �$��2q�6p   
����  �$��	5,20,10,0q�6�   .��6�   Save6�   �� 5(      -   5        $��btnDelCusomerPage��5(      $	��100��6.   $��30��6:   
�������
���  ��$��2q�6k   
���  ��$��5,20,5,0q�6�   .��6�   Delete6�   5)      � 5+   
   $��2��6   .+�5-      �� -   5        $��lvCustomersPage��5-   0   $	��800��6   $	��150��6#    �� SelectionMode$ Single=�6G    �� View 5/      �� 51       �� AllowsColumnReorder$
 true��6    �� ColumnHeaderToolTip$ Categories Information��6:   .P�53      ��  �� Width$	 200��6)    �� DisplayMemberBinding 65   �� *ID+.��54      �� .��63   Number56      57      �� 59      $	 200��6)    65   �� *Name+.��5:      �� .��63   Customer Name5<      5=      �� 5?      $	 200��6)    65   �� *Phone+.��5@      �� .��63   Phone5B      5C      �� 5E      $	 200��6)    65   �� *Remain+.��5F      �� .��63   Remain5H      5I      5K      5N      5P      5Q      5R      