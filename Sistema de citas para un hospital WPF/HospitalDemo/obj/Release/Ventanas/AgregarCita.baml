   M S B A M L   `   `   `  ���� G  CHospitalDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:HospitalDemo.VentanasHospitalDemo.Ventanas  '    !HospitalDemo.Ventanas.AgregarCita   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:HospitalDemo.Ventanas       � Title$  Agregar Nueva Cita��$	��300��$	��380��.��� .+��� .+��� -    ��Name$ r_select_stack�� �� Orientation$ 
Horizontal=�$��Center=�$��0,10,0,0q�.+��� $��Registro��$��18(�$��Center=��� -    ��Name$ registroSelectCombo��$	��200��$��10q�$��18(��� -   $ 
edit_stack��.+��� $ 
Horizontal=�$��Center=�.+��� $��Paciente��$��18(�$��Center=��� -   $ pacienteComboBox��$	��200��$��10q�$��18(� �� Text$  ���� $ 
Horizontal=�$��Center=�.+��� $��Fecha para la cita:��$��18(�$��Center=�(  "System.Windows.Controls.DatePicker  -     Name$ citaDatePicker��$	��150��$��10q�$��18(�   Text$  ���� $ 
Horizontal=�$��Center=�$��0,20,0,0q�.+��� -    ��Name$ save_btn��$��Guardar��$��40��$
��20,0q�$	��4,0q�$��16(�$
��Bold"��� -   $ 
cancel_btn��$��Cancelar��$��40��$
��20,0q�$	��4,0q�$��16(�$
��Bold"�