   M S B A M L   `   `   `  ����T  PInventoryManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:InventoryManagementSystemInventoryManagementSystem  5      C    =InventoryManagementSystem.ShowCustomerBillDetailesUserControl   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:InventoryManagementSystem     5      .��5
      � -   5        $��CustomerBillShowPage��5
        � ColumnDefinitions  5   
   �� 5      6!   �� 5      6"   �� 5      $
��247* �6   �� 5      $
��415* �6   �� 5      $	��12* �6   .+�5   
   � $��2��6   $��3��6    � RowDefinitions 5      �� 5      $	��120 �6    6/   �� 5      $	��120 �6    6/   �� 5      $	��130 �6    6/   �� 5      $��50 �6    6.   .+�5#      � $��0��6   $��	10 10 0 0q�6      5$      �� 5%      $	��120 �6'   65   �� 5&      6)   �� 5'      $	��120 �6'   65   �� 5(      6)    5+      �� 5,      6&   �� 5-      6&   �� 5.      6&   �� 5/      6&   .+�52      �� $��0��6   $��0��6,   
�������ID :6R   �� 53      -   5        $��txtShowCustomerBillID��53      $��1��6;   $��0��6M   
�������6q   �� 55      $��2��6   $��2��6.   
�������
User Name:6\   �� 56      -   5        $��txtShowCustomerBillUser��56      $��3��6=   $��2��6O   
�������6s   �� 58      $��0��6   $��1��6.   
�������Inventory name:6b   �� 59      -   5        $"��txtShowCustomerBillInventory��59      $��1��6B   $��1��6T   
�������6x   �� 5;      $��0��6   $��2��6.   
�������Customer Name:6a   �� 5<      -   5        $!��txtShowCustomerBillCustomer��5<      $��1��6A   $��2��6S   
�������6w   �� 5>      $��0��6   $��3��6.   
�������Total:6Y   �� 5?      -   5        $��txtShowCustomerBillTotal��5?      $��1��6>   $��3��6P   
�������6t   �� 5A      $��2��6   $��0��6.   
�������	Remain:6Z   �� 5B      -   5        $��txtShowCustomerBillRemain��5B      $��3��6?   $��0��6Q   
�������6u   �� 5D      $��2��6   $��1��6.   
�������Date :6Y   �� 5E      -   5        $��txtShowCustomerBillDate��5E      $��3��6=   $��1��6O   
�������6s   �� 5G      $��2��6   $��2��6.   
�������Number of Products:6f   �� 5H      -	   5        $��txtShowCustomerBillQty��5H      $��3��6<   $��2��6N   
�������6r   5L      � 5P      $��1��6   .+�5R      �� -
   5        $��lvShowCustomerBill��5R      $	��500��67   $	��120��6F    �� View 5T      �� 5V       �� ColumnHeaderToolTip$ customer Information��6$   .P�5X      �� $
��Name��6.    �� Width$	 170��6>    �� DisplayMemberBinding 6L   �� *Product.Name+�� 5Y      $��Quantity��6.   $	 160��6B    6Q   �� *
Quantity+�� 5Z      $��Price��6.   $	 160��6?    6N   �� *
TotalPrice+5\      5_      5a      � 5d      $��2��6   .+�5f      �� -   5        $��lvShowCustomerReturnBill��5f      $	��500��6=   $	��120��6L    5h      �� 5j      $ customer Information��6$   .P�5l      �� $
��Name��6.   $	 170��6>    6L   �� *Name+�� 5m      $��Quantity��6.   $	 160��6B    6Q   �� *
Quantity+�� 5n      $
��Date��6.   $	 160��6>    6M   �� *	OrderedOn+5p      5s      5u      � 5x      $��3��6   .+�5z      �� -   5        $��btnShowCustomerBillHide��5z      $��30��6:   $��70��6H   .��6~   Back6�   5|      5~      5      5�      