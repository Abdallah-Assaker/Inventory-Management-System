   M S B A M L   `   `   `  ����T  PInventoryManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:InventoryManagementSystem.ViewInventoryManagementSystem.View  5   	   .    (InventoryManagementSystem.View.LoginView   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:InventoryManagementSystem.View     5   	     � Title$  	LoginView��5   	   $	��450��6   $	��800��6(   $	��550��5	   	    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency$
 True��5   	   .��5      ��  �� CornerRadius$ 15��6   ��5   
   �� 5       �� ImageSource$ ../Images/storage.jpg��6    j� Stretch$
 None=�5      ._�5   
   �� $ 15��6   $��5q�5       J� Opacity$
 0.90Q�5      ��5      �� 5      	 �� 
StartPoint$		 0,0&�6&   
 �� EndPoint$	
 1,1&�67   .��5      �  � Color$ #462AD8��6#    � Offset$ 0Q�63   � 5      $ #DA34AE��6#   $
 0.75Q�63   � 5      $ #8A16C1��6#   $ 1Q�63   5      ��5       �� 5!      $		 0,1&�6&   $	
 1,0&�67   .��5"      � $ #060531��6#   $	 0.4Q�63   � 5#      $ 	#FF332A6F��6#   $ 1Q�65   5$      ._�5&      �  � RowDefinitions 5'      �� 5(      $��30 �6$   �� 5)      .+�5,      � $��0��6    � ColumnDefinitions 5-      �� 5.      �� 5/      $��25 �6+   �� 50      $��25 �6+   �� 51      $��5 �6+   .+�53      �� $��LOG IN��6    
�������$��10(�55       $��
Montserrat)�56       $��0��57       $��Center=�58       $��10,0,0,0q�59       �� 5:      -   5         ��Name$ btnMinimize��5:      $��2q�5;      $��-��5<      
�������$��16(�5>      $��
Montserrat)�5?       � Cursor$
 Hand��5@      $��1��5A      ��5D      �� 5E       �� 
TargetType" ��6$   .�5F   "   ��  �� Property � �� �� Value �#28AEED6?    �� Triggers 5G   "   P� 5H   &    P� Property �@J�IsMouseOver P� Value$
 True��6E   . �5I   *   ��  � �� �#278BEF6G   5J   '   5L      ��5N      �� 5O       �� 
TargetType" ��6.   .R�5P   "   �� $��18��6)   $��18��64   $ 9��5Q   )   #��z��5R   )   ._�5S   &   �� $��Center=�67   $��Center=�5T   7   5U   #   5V      5X      �� 5Y      -   5        $ btnClose��5Y      $��0q�5Z      $��X��5[      
�������$��12(�5]      $��
Montserrat)�5^      $
 Hand��5_      $��2��5`      ��5c      �� 5d      " ��6$   .�5e   "   ��  � �� �#DA34AE6?    5f   "   P� 5g   &    �@J�IsMouseOver$
 True��6E   . �5h   *   ��  � �� �#C62DAE6G   5i   '   5k      ��5m      �� 5n      " ��6.   .R�5o   "   �� $��18��6)   $��18��64   $ 9��5p   )   #��z��5q   )   ._�5r   &   �� $��Center=�67   $��Center=�5s   7   5t   #   5u      5w      5x      �� 5y      $	��220��6   $��1��5z       �� Orientation$ Vertical=�5{      $��0,35,0,0q�5|      .+�5}      �� $��../Images/loogoo.png��6   $��90��5~      $��80��6'   $��10q�63   �� 5      $��A-Z TECH��6    
�������$��25(�5�       $��Medium"�5�       $��
Montserrat)�5�       $��Center=�5�       �� 5�      $��STORAGE MANAGEMENT SYSTEM��6    
�������$��12(�5�       $��Medium"�5�       $��
Montserrat)�5�       $
��Wrap=�5�        �� TextAlignment$ Center=�5�       $��0,5,0,0q�5�       �� 5�      $ 
Horizontal=�6!   .+�5�      �� $��../Images/person.png��6    $��20��6>   $��0 50 5 0q�6J   $��Center=�6\   �� 5�       �� Padding$ 0,20,0,0q�6$   $��Username��67   
�������$��12(�5�       $��Medium"�5�       $��
Montserrat)�5�       $��0,35,0,0q�5�       5�      �� 5�      -   5         ��Name$ txtUser��5�      $��13(�5�      $��Medium"�5�      $��
Montserrat)�5�      
������� �� 
CaretBrush
 �����
�������$��0,0,0,2q�5�      $��28��5�      $��Center=�5�      $��0,5,0,0q�5�      .��5�      ��5�      �� 5�      $ ../Images/storage.jpg��6)   $
 None=�5�   )    �� Opacity$ 0Q�5�   )    j� 
AlignmentX$
 Left=�5�   )   .��5�   .   5�      �� 5�      $ 
Horizontal=�6!   .+�5�      �� $��../Images/pass.png��6    $��20��6<   $��0 10 5 0q�6H   6\   �� 5�      $��Password��6$   
�������$��12(�5�       $��Medium"�5�       $��
Montserrat)�5�       $��0,15,0,0q�5�       5�      G� 5�      -   5         G�Name$ txtPass��5�   "   $��13(�5�      $��Medium"�5�      $��
Montserrat)�5�      
�������  G� 
CaretBrush
  �����
�������$��0,0,0,2q�5�      $��28��5�      $��Center=�5�      $��0,5,0,0q�5�      $��20,0,0,0q�5�      ��5�      �� 5�      $ 0Q�6)   $
 None=�5�   )   $
 Left=�5�   )   5�      �� 5�      -   5        $ btnLogin��5�      $��0q�5�      $��LOG IN��5�      
�������$��12(�5�      $��
Montserrat)�5�      $
 Hand��5�      $��0,50,0,0q�5�      ��5�      �� 5�      " ��6$   .�5�   "   ��  � �� �#462AD86?    5�   "   P� 5�   &    �@J�IsMouseOver$
 True��6E   . �5�   *   ��  � �� �#28AEED6G   5�   '   5�      ��5�      �� 5�      " ��6.   .R�5�   "   �� $	��150��6)   $��40��65   $ 20��5�   )   ���	#FF4841C6._�5�   &   �� $��Center=�67   $��Center=�5�   7   5�   #   5�      5�      5�      5�      5�      5�      5�      