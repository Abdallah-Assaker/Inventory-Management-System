   M S B A M L   `   `   `  ����T  PInventoryManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:InventoryManagementSystemInventoryManagementSystem  5      @    :InventoryManagementSystem.CustomerOrderProductsUserControl   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:InventoryManagementSystem     5      .��5	      �   � RowDefinitions  5   
   �� 5      $��60 �6   6*   �� 5      $��60 �6   6*   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   �� 5      $��70 �6   6*   �� 5      $��60 �6   6*   �� 5      $��60 �6   6*   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      6%   �� 5      6%   �� 5      6%   .+�5      �� $��0��6   $��0,0,0,1q�6%   
�������$��5q�6S   ._�5      �� .+�5       �� $��2q�6   $
��Left=�6)   
�������.��6W   Inventory Name6g   �� 5!      -   5        $"��CustomerOrderInventoryComBox��5!   +   $��25��6   ��5"      �� 5#      .R�5$   "   � .+�5%   &   �� ��60   ��  �� Path$ Location�6Q   5&   #   5'      5)      5*      5+      �� 5-      $��1��6   $	��145��6)   $��5q�65   .+�5.      �� $��2q�6   $
��Left=�6%   
�������.��6S   Purshase Date6b   �� 5/      -   5        $ ��CustomerOrderDateTextBlock��5/      
�������6S   50      �� 52      $��2��6   $	��140��6%   $��0,0,0,1q�61   
�������._�53      �� .+�54      �� $��2q�6   $
��Left=�6)   $��30 0 0 0q�6D   
�������.��6i   Customer Name6x   �� 55      -   5        $!��CustomerOrderCustomerComBox��55   +   $��25��6   $	��140��6P   ��57      �� 58      .R�59   "   � .+�5:   &   �� ��60   �� $
 Name�6M   5;   #   5<      5>      5?      5@      5C      � 5E   
   $��1��6    5F      �� 5G      6%   �� 5H      6%   �� 5I      6%   .+�5L      �� $��0��6   $��0,0,0,1q�6&   
�������$��5q�6T   ._�5M      �� .+�5N      �� $��2q�6   $
��Left=�6)   
�������.��6W   Product Name6e   �� 5O      -   5        $ ��CustomerOrderProductComBox��5O   +   $��25��6   ��5P      �� 5Q      .R�5R   "   � .+�5S   &   �� ��60   �� $
 Name�6M   5T   #   5U      5W      5X      5Y      �� 5[      $��1��6   $	��145��6%   $��0,0,0,1q�61   
�������$��5q�6_   ._�5\      �� .+�5]      �� $��2q�6   $
��Left=�6)   
�������.��6W   
Quantity6a   �� 5^      -   5        $"��CustomerOrderQuantityTextBox��5^      $��0q�6B   $��1��6V   
�������6u   5_      5`      �� 5b      $��2��6   $	��145��6)   $��10q�66   .+�5c      �� $��2q�6   $
��Left=�6%   
�������.��6T   Price6[   �� 5d      -   5        $!��CustomerOrderPriceTextBlock��5d      $	��145��6?   
�������6a   5e      5g      � 5j   
   $��2��6   $	��420��6    5k      �� 5l      6%   �� 5m      6%   �� 5n      6%   .+�5q      �� -   5        $ ��CustomerOrderAddProductBtn��5q      $��0��67   $	��100��6G   $��30��6S   
�������
��� � �$��2q�6�   
��� � �$��	5,20,10,0q�6�   .��6�   Add Product6�   �� 5r      -   5        $!��CustomerOrderSaveProductBtn��5r      $��1��68   $	��100��6H   $��30��6T   
�������
����  �$��2q�6�   
����  �$��	5,20,10,0q�6�   .��6�   Save Product6�   �� 5s      -	   5        $#��CustomerOrderDeleteProductBtn��5s      $��2��6:   $	��100��6J   $��30��6V   
�������
���  ��$��2q�6�   
���  ��$��5,20,5,0q�6�   .��6�   Delete Product6�   5u      � 5w   
   $��3��6   .+�5z      �� -
   5        $"��CustomerOrderProductListView��5z   $   $	��600��6    �� SelectionMode$ Single=�6H    �� View 5{      �� 5|       �� ColumnHeaderToolTip$ customer Information��6   .P�5}      �� $��ProductName��6)    �� Width$	 200��6l    �� DisplayMemberBinding 6>   �� *Product.Name+6l   �� 5~      $��Quantity��6)   $	 200��6e    6;   �� *
Quantity+6e   �� 5      $��Price��6)   $	 200��6e    69   �� *
TotalPrice+6e   5�      5�      5�      � 5�   
   $��4��6    5�      �� 5�      6%   �� 5�      6%   �� 5�      6%   .+�5�      �� $��0��6   $	��145��6)   $��200 10 0 0 q�67   .+�5�      ��  �� TextAlignment$
 Left=�6   
�������Total6L   �� 5�      -   5        $!��CustomerOrderTotalTextBlock��5�      
�������6T   5�      �� 5�      $��1��6   $	��140��6&   $��0,0,0,1q�62   
�������$��	20 6 0 12q�6`   ._�5�      �� .+�5�      �� $
��Left=�6   
�������.��6L   
Paid Money6X   �� 5�      -   5        $#��CustomerOrderPaidMoneyTextBox��5�      $	��145��6C   $��0q�6O   6f   5�      5�      �� 5�      $��2��6   $	��145��6)   $��	0 10 0 0 q�66   .+�5�      �� $
 Left=�6   
�������Remain6L   �� 5�      -   5        $"��CustomerOrderRemainTextBlock��5�      
�������6U   5�      5�      � 5�   
   $��5��6    5�      �� 5�      $	��250 �6#   61   �� 5�      $	��250 �6#   61   .+�5�      �� $��0��6   $��	200 0 0 0q�6)   $	��145��6<   .+�5�      �� $
 Left=�6   
�������Net6I   �� 5�      -   5        $��CustomerOrderNetTextBlock��5�      
�������6R   5�      �� 5�      $��1��6   $	��140��6&   $��0,0,0,1q�62   
�������$��	70 0 0 12q�6`   ._�5�      �� .+�5�      �� $��2q�6   $
��Left=�6)   
�������.��6W   
Discount6a   �� 5�      -   5        $'��!CustomerOrderDiscountMoneyTextBox��5�      $��0��6G   $��0q�6P   6g   5�      5�      5�      � 5�   
   $��6��6   $	��300��6    5�      �� 5�      6%   �� 5�      6%   .+�5�      �� -   5        $��CustomerOrderAddBillBtn��5�      $��0��64   $	��100��6D   $��30��6P   
�������
��� � �$��2q�6�   
��� � �$��	5,20,10,0q�6�   .��6�   
Add Bill6�   �� 5�      -   5        $��CustomerOrderResetBillBtn��5�      $��1��66   $	��100��6F   $��30��6R   
�������
���  ��$��2q�6�   
���  ��$��	5,20,10,0q�6�   .��6�   
Reset Bill6�   5�      5�      5�      