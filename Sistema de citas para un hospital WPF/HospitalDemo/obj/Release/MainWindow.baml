   M S B A M L   `   `   `  ���� G  CHospitalDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HospitalDemoHospitalDemo      HospitalDemo.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:HospitalDemo       � Title$  HOSPITAL��$	��700��$
��1080��$	��800��$	��500��.��� ����  �� ImageSource$ img/fondo.jpg�� �� Opacity$	 0.4Q� j� Stretch$ UniformToFill=� j� TileMode$ FlipXY=� � ColumnDefinitions �� $	��240 ��� $��* � � RowDefinitions �� $��64 ��� $��2 ��� $��* �.+�� $��0��$��2�����	#FFF9F9F9 �� $��4 ��� $	��232 ��� $��4 ��� $��* � �� $��20 ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* �.+��� -    ��Name$ 
registrBtn��$��2��$��1��$��1��$
��Left=����	#FFF1F1F1
���   �
�������$��40��$	��0,4q�.��]� .+��� $��img/reg_icon.png���� $��Center=�$��Center=�$��18(�.��	Registros�� -   $ confBtn��$��3��$��1��$��1��$
��Left=����	#FFF1F1F1
���   �
�������$��40��$	��0,4q�.��]� .+��� $��img/conf_ico.png���� $��Center=�$��Center=�$��18(�.��Configuraciones� $��0�����	#FF9FFFE0.+��� $��HOSPITAL��$��48(�$
��Bold"����	#FF6AA08F$��Center=�$��Center=�� $��1������  �� EndPoint$ 0.5,1&�	 �� 
StartPoint$	 0.5,0&�.��� 
 � Color$
 	#FF9FFFE0��� $
 	#009FFFE0�� � Offset$ 1Q� �� $��* ��� $	��100 � �� $��42 ��� $��* �.+��� $��1��$��2��$��	10,4,10,4q�$��img/panel_ico.png���� -    ��Name$ usernamePanel��$��0��$��0��$��USERNAME��$��Right=�$��Bottom=�$��28(�$��Arial)�$
��Bold"��� -   $ cerrarSessionBnt��$��0��$��1��$��Cerrar session��$��Right=�$	��Top=�$��16(�$��Arial)�$
��Bold"� � -     �Name$ 	mainFrame��$��1��$��2��  � NavigationUIVisibility$ Hidden=�