   M S B A M L   `   `   `  ����G  CHospitalDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HospitalDemoHospitalDemo  5   	       HospitalDemo.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:HospitalDemo     5   	     � Title$  HOSPITAL��5   	   $	��700��6   $
��1080��6'   $	��800��64   $	��500��6C   .��5	      � ��5
   
   �� 5       �� ImageSource$ img/fondo.jpg��6    �� Opacity$	 0.4Q�65    j� Stretch$ UniformToFill=�6C    j� TileMode$ FlipXY=�6[    � ColumnDefinitions 5   
   �� 5      $	��240 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��64 �6   �� 5      $��2 �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��2��6   ���	#FFF9F9F9 5      �� 5      $��4 �6#   �� 5      $	��232 �6#   �� 5      $��4 �6#   �� 5      $��* �6#    5      �� 5       $��20 �6    �� 5!      $
��auto �6    �� 5"      $
��auto �6    �� 5#      $
��auto �6    �� 5$      $��* �6    .+�5(      �� -   5         ��Name$ 
registrBtn��5(      $��2��6)   $��1��66   $��1��6F   $
��Left=�5)      ���	#FFF1F1F1
���   �
�������$��40��5+      $	��0,4q�6!   .��5,      ]� .+�5-      �� $��img/reg_icon.png��6   �� 5.      $��Center=�6   $��Center=�67   $��18(�6T   .��6b   	Registros6m   5/      50      �� 51      -   5        $ confBtn��51      $��3��6&   $��1��63   $��1��6C   $
��Left=�52      ���	#FFF1F1F1
���   �
�������$��40��54      $	��0,4q�6!   .��55      ]� .+�56      �� $��img/conf_ico.png��6   �� 57      $��Center=�6   $��Center=�67   $��18(�6T   .��6b   Configuraciones6s   58      59      5;      � 5>   
   $��0��6   ���	#FF9FFFE0.+�5?      �� $��HOSPITAL��6   $��48(�6(   $
��Bold"�66   ���	#FF6AA08F$��Center=�6_   $��Center=�6|   5@      � 5C   
   $��1��6   ��5D      �� 5E       �� EndPoint$ 0.5,1&�6&   	 �� 
StartPoint$	 0.5,0&�67   .��5F      � 
 � Color$
 	#FF9FFFE0��6#   � 5G      $
 	#009FFFE0��6#    � Offset$ 1Q�65   5H       5J      �� 5K      $��* �6#   �� 5L      $	��100 �6#    5N      �� 5O      $��42 �6    �� 5P      $��* �6    .+�5R      �� $��1��6   $��2��6$   $��	10,4,10,4q�65   $��img/panel_ico.png��6H   �� 5S      -   5         ��Name$ usernamePanel��5S      $��0��6/   $��0��6?   $��USERNAME��6L   $��Right=�6\   $��Bottom=�6x   $��28(�6�   $��Arial)�6�   $
��Bold"�6�   �� 5T      -   5        $ cerrarSessionBnt��5T      $��0��6/   $��1��6?   $��Cerrar session��6L   $��Right=�6e   $	��Top=�6�   $��16(�6�   $��Arial)�6�   $
��Bold"�6�   6�   5U       � 5W   
   -   5          �Name$ 	mainFrame��5W      $��1��6#   $��2��63     � NavigationUIVisibility$ Hidden=�6@   5X      5Y      