   M S B A M L   `   `   `  ����T  PInventoryManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:InventoryManagementSystemInventoryManagementSystem  5      =    7InventoryManagementSystem.ReturnSypplierBillUserControl   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:InventoryManagementSystem     5      .��5
      �   � ShowGridLines$  False��6    � ColumnDefinitions 5   
   �� 5      $��1* �6    6-   �� 5      $��2* �6   6,   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      6"   �� 5      6"   .+�5      �� $��0��6   $��10 0 0 0q�6&   .+�5      �� 
�������Supplier Name6>   �� 5      -   5        $��ReturnBillSupplerName��5   /   
�������6P   �� 5      
�������	Inventory6;   �� 5      -   5        $��ReturnBillInventory��5   /   
�������6L   �� 5       
�������
Quantity69   �� 5!      -   5        $��ReturnBillQty��5!   /   
�������6F   �� 5#      
�������Date65   �� 5$      -   5        $��ReturnBillDate��5$      65   �� 5&      
�������
Bill Total6;   �� 5'      -   5        $��ReturnBillTotal��5'   /   
�������6J   �� 5)      
�������Total Return6=   �� 5*      -   5        $��ReturnBillReturnedTotal��5*   /   
�������6Q   5,      5/      � 51   
   $��1��6    52      �� 53      $	��150 �6    6/   �� 54      $��70 �6    6.   �� 55      $	��150 �6    6/   �� 56      $	��150 �6    6/   .+�59      �� $��0��6   .+�5:      �� -   5        $!��lvReturnBillCurrentProducts��5:      $	��150��6>    �� SelectionMode$ Single=�6K   $	��500��6b    �� View 5;      �� 5=      .P�5@      �� $
��Name��6[    �� Width$	 200��6i    �� DisplayMemberBinding 6-   �� *Product.Name+6w   �� 5A      $��Quantity��6W   $	 150��6i    6-   �� *
Quantity+6w   �� 5B      $��Price��6Y   $	 150��6h    6-   �� *
TotalPrice+6v   5D      5G      5H      � 5J      $��1��6   $	��500��6%   $��
50 20 50 0q�61   .+�5L      �� -   5        $��ReturnBillIdSearch��5L      $	��100��64   $��30��6@   6O   �� 5M      -	   5        $��btnReturnBillSelectedQty��5M      $	��100��69   $��30��6E   
�������
��� � �$��2q�6x   
��� � �$��5,0,10,0q�6�   .��6�   Search6�   �� 5O      -
   5        $��txtReturnBillQty��5O      $	��100��62   $��30��6>   6M   �� 5P      -   5        $��btnReturnBillSearch��5P      $	��100��64   $��30��6@   
�������
��� � �$��2q�6s   
��� � �$��5,0,10,0q�6�   .��6�   Select6�   5R      �� 5T      $��2��6   .+�5U      �� -   5        $"��lvReturnBillSelectedProducts��5U      $ Single=�6?   $	��500��6V   $	��150��6b   $��Center=�6o    5V      �� 5X      .P�5Z      �� $
��Name��6[   $	 200��6i    6-   �� *Product.Name+6w   �� 5[      $��Quantity��6W   $	 150��6i    6-   �� *
Quantity+6w   �� 5\      $��Price��6T   $	 150��6c    6-   �� *Price+6q   5^      5a      5b      � 5d      $��3��6   $	��350��6%   .+�5e      �� -   5        $��ReturnBillConfirm��5e      $	��100��62   $��30��6>   
�������
��� � �$��2q�6q   
��� � �$��	5,20,10,0q�6�   .��6�   	Confirm6�   �� 5f      -   5        $��ReturnBillReset��5f      $	��100��60   $��30��6<   
�������
����  �$��2q�6n   
����  �$��	5,20,10,0q�6�   .��6�   Reset6�   �� 5g      -   5        $��ReturnBillRemove��5g      $	��100��61   $��30��6=   
�������
���  ��$��2q�6n   
���  ��$��5,20,5,0q�6�   .��6�   Delete6�   5h      5i      5l      5o      