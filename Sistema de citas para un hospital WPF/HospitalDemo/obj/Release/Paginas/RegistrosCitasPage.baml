   M S B A M L   `   `   `  ���� G  CHospitalDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:HospitalDemo.PaginasHospitalDemo.Paginas  -    'HospitalDemo.Paginas.RegistrosCitasPage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     4local"clr-namespace:HospitalDemo.Paginas       N� Title$  RegistrosCitasPage�� � 	Resources    DefaultTemplate �Name � ColumnDefinitions ��Name �� Path ��Name	 �� X1	 �� X2		 �� Y1	
 �� Y2 J� SnapsToDevicePixels  SimpleListBoxItem �� 
TargetType �� Property �� Value �� 
TargetType �� Padding �� Triggers P� Property P� Value �� 
TargetName��%  &	        &	 ?    �� .R�� $ GridItem��$	��200�� �� $
��Auto ��� $
��Auto �.+��� $ 	Parameter��$��1��$��5,1,0,0q����� $ id��� $ Value��$��2��$��85,1,0,0q����� $ personal_id��� $ 	Separator��$ 0��$ 0��$	 0��$
 20�� . $��1��
���   �$��2��$��50,0,0,0q�$
��Left=��� " ��.���  �@�FocusVisualStyle Z� ��  � �� �� " ��.R��� $��Border��$ 2q� . ._���  P�  �@��
IsSelected . . ��� $ Border�� � ��
 � ���.��� $��10q�����  �� EndPoint$ 0.5,1&� � MappingMode$ RelativeToBoundingBox=� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF9FFFE0�� � Offset$ 0.245Q�� $ 	#009FFFE0��$
 0.03Q� �� $��* ��� $	��210 � � RowDefinitions �� $	��100 ��� $��* �.+���  �� Orientation$ Vertical=�$��4,0,0,0q�.+��� $ 
Horizontal=�.+��� $��
Personal: ��$��Center=�$��18(��� -    ��Name$ personalComboBox��$��4q�$	��240���� $ 
Horizontal=�$��10,0,0,0q�.+��� $��Tipo: ��$��Center=�$��16(�$
��Bold"��� -   $ tipoComboBox�� �� SelectedIndex$ 2��$��4q�$	��100�� �� IsTextSearchEnabled . .@��� .��Previa�� .��
Emergencia�� .��Todos�� $��Estado: ��$��Center=�$��16(�$
��Bold"��� -   $ estadoComboBox��$ 5��$��4q�$	��100�� . ���	#FF9FFFE0.@��� .��	Pendiente�� .��
Finalizada�� .��	Perdida�� .��	Cancelada�� .��
En Curso�� .��Todos�� -   $��citasListBox��$��Stretch=�$��1��#��[ ���� .R��� 
�������$	��0,2q�$��8q�._�]� ��. .+�� $	��Top=�$��30��
������� �� $��80 ��� $��* ��� $	��120 ��� $	��100 �.+��� $��0��.��Tipo de Cita�� $��1��.��
Pasiente�� $��2��.��Fecha para Cita�� $��3��.��ESTADO�� .���� ���� .R�� $	��0,2q� �� $��80 ��� $��* ��� $	��100 ��� $	��100 �.+���  �� Padding$	 4,2q�$
��Left=�
����������� *tipo+���� *	TipoColor+�� $��1������ *PascienteName+�� $��2������ *CitaFechaEnDias+�� $	 4,2q�$��3������ *estado+���� *EstadoColor+�� $��1��$��1��$
��Auto=�.���� $��8q�.+��� $��0,0,0,8q�.+��� $��Estado:���� -   $ editEstadoComboBox��$��14(�.@��� .��	Pendiente�� .��
Finalizada�� .��	Perdida�� .��	Cancelada�� .��
En Curso�� -     ��Name$  
datosStack��.+��� $��Datos:��$��0,0,0,8q��� $��Personal que atendera:��$��0,0,0,0q��� -   $ persnTexBlock��$�� ��$��0,0,0,0q�$��16(�$
��Bold"�$��WrapWithOverflow=��� $��Fecha de Ingreso:��$��0,8,0,0q��� -   $ finggresoTexBlock��$��
00/00/0000��$��0,0,0,0q�$��16(�$
��Bold"��� $��Fecha de la cita:��$��0,8,0,0q��� -	   $ fcitaTexBlock��$��
00/00/0000��$��0,0,0,0q�$��16(�$
��Bold"��� $��0,0,0,8q�.+��� $��	Acciones:��$��0,0,0,8q��� -
   ! ��Name$! pasienteDetallesBtn��$��Ver Detalles de Paciente��$��14(�$	��0,4q�$��0,0,0,10q�{�.  �� -   $! 
addCitaBtn��$��Añadir Nueva Cita��$��14(�$	��0,4q�$��0,0,0,10q��� -   $! addEmergenciaCitaBtn��$!�� Añadir Cita de Emergencia��$��14(�$	��0,4q�$��0,0,0,10q��� -   $  disponib_panel��$��0��$��1�����	#FF77C9AE$y�Hidden=�.+��� -   $  	DispColor��
���   �.+��� -   $ 	DispLabel��$��Center=�$��18(�$
��Bold"�$	��0,4q�
��������� -   $ horarioText��$��WrapWithOverflow=�$��8,8,8,3q�$��13(�