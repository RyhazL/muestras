   M S B A M L   `   `   `  ���� G  CHospitalDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:HospitalDemo.VentanasHospitalDemo.Ventanas  +    %HospitalDemo.Ventanas.PersonalVentana   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:HospitalDemo.Ventanas       � Title$  Ingresa Datos de Personal��$	��420��$	��380�� � 
ResizeMode$ NoResize=�.��� .+��� .+��� -    ��Name$ p_select_stack�� �� Orientation$ 
Horizontal=�$��Right=�$��0,10,0,0q�.+��� $��Personal��$��18(�$��Center=��� -    ��Name$ PersonalSelectCombo��$	��200��$��10q�$��18(� �� Text$  ���� -   $ 
edit_stack��.+��� $ 
Horizontal=�$��Right=�.+��� $��Nombre:��$��18(�$��Center=��� -    ��Name$ nombreTextBox��$	��200��$��10q�$��18(�$�� ���� $ 
Horizontal=�$��Right=�.+��� $��	Apellido:��$��18(�$��Center=��� -   $ apellidoTextBox��$	��200��$��10q�$��18(�$�� ���� $ 
Horizontal=�$��Right=�.+��� $��
Profesion:��$��18(�$��Center=��� -   $ ProfsComboBox��$	��200��$��10q�$��18(��� $ 
Horizontal=�$��Right=�.+��� $��Fecha de ingreso:��$��18(�$��Center=�(  "System.Windows.Controls.DatePicker  -     Name$ fechaDatePicker��$	��200��$��10q�$��18(��� $ 
Horizontal=�$��Right=�.+��� $��Agenda��$��18(�$��Center=��� -   $ agendaComboBox��$	��200�� �� SelectedIndex$ 0��$��10q�$��18(��� $ 
Horizontal=�$��Center=�$��0,40,0,0q�.+��� -	   	 ��Name$	 save_btn��$��Guardar Cambios��$��40��$
��20,0q�$	��4,0q�$��16(�$
��Bold"��� -
   $	 
cancel_btn��$��Cancelar��$��40��$
��20,0q�$	��4,0q�$��16(�$
��Bold"�