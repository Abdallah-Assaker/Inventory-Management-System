   M S B A M L   `   `   `  ����T  PInventoryManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:InventoryManagementSystemInventoryManagementSystem  5      B    <InventoryManagementSystem.ShowSupplierBillDetailsUserControl   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:InventoryManagementSystem     5      .��5	      � -   5        $��SupplierBillShowPage��5	        � ColumnDefinitions  5   
   �� 5      6!   �� 5      6"   �� 5      $
��247* �6   �� 5      $
��415* �6   �� 5      $	��12* �6   .+�5   
   � $��2��6   $��3��6    � RowDefinitions 5      �� 5      $	��120 �6    6/   �� 5      $	��120 �6    6/   �� 5      $	��130 �6    6/   �� 5      $��50 �6    6.   .+�5"      � $��0��6   $��	10 10 0 0q�6      5#      �� 5$      $	��120 �6'   65   �� 5%      6)   �� 5&      $	��120 �6'   65   �� 5'      6)    5*      �� 5+      6&   �� 5,      6&   �� 5-      6&   �� 5.      6&   .+�51      �� $��0��6   $��0��6,   
�������ID :6R   �� 52      -   5        $��txtShowSupplierBillID��52      $��1��6;   $��0��6M   
�������6q   �� 54      $��2��6   $��2��6.   
�������
User Name:6\   �� 55      -   5        $��txtShowSupplierBillUser��55      $��3��6=   $��2��6O   
�������6s   �� 57      $��0��6   $��1��6.   
�������Inventory name:6b   �� 58      -   5        $"��txtShowSupplierBillInventory��58      $��1��6B   $��1��6T   
�������6x   �� 5:      $��0��6   $��2��6.   
�������Supplier Name:6a   �� 5;      -   5        $!��txtShowSupplierBillSupplier��5;      $��1��6A   $��2��6S   
�������6w   �� 5=      $��0��6   $��3��6.   
�������Total:6Y   �� 5>      -   5        $��txtShowSupplierBillTotal��5>      $��1��6>   $��3��6P   
�������6t   �� 5@      $��2��6   $��0��6.   
�������	Remain:6Z   �� 5A      -   5        $��txtShowSupplierBillRemain��5A      $��3��6?   $��0��6Q   
�������6u   �� 5C      $��2��6   $��1��6.   
�������Date :6Y   �� 5D      -   5        $��txtShowSupplierBillDate��5D      $��3��6=   $��1��6O   
�������6s   �� 5F      $��2��6   $��2��6.   
�������Number of Products:6f   �� 5G      -	   5        $��txtShowSupplierBillQty��5G      $��3��6<   $��2��6N   
�������6r   5I      � 5M      $��1��6   .+�5O      �� -
   5        $��lvShowSupplierBill��5O      $	��500��67   $	��120��6F    �� View 5Q      �� 5S       �� ColumnHeaderToolTip$ Supplier Information��6$   .P�5U      �� $
��Name��6.    �� Width$	 170��6>    �� DisplayMemberBinding 6L   �� *Product.Name+�� 5V      $��Quantity��6.   $	 160��6B    6Q   �� *
Quantity+�� 5W      $��Price��6.   $	 160��6?    6N   �� *
TotalPrice+5Y      5\      5^      � 5`      $��2��6   .+�5b      �� -   5        $��lvShowSupplierReturnBill��5b      $	��500��6=   $	��120��6L    5d      �� 5f      $ Supplier Information��6$   .P�5h      �� $
��Name��6.   $	 170��6>    6L   �� *Name+�� 5i      $��Quantity��6.   $	 160��6B    6Q   �� *
Quantity+�� 5j      $
��Date��6.   $	 160��6>    6M   �� *	OrderedOn+5m      5p      5r      � 5t      $��3��6   .+�5v      �� -   5        $��btnShowSupplierBillHide��5v      $��30��6:   $��70��6H   .��6~   Back6�   5x      5z      5{      5}      