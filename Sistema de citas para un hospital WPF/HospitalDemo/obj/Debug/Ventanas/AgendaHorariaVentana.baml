   M S B A M L   `   `   `  ����G  CHospitalDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:HospitalDemo.VentanasHospitalDemo.Ventanas  5   	   0    *HospitalDemo.Ventanas.AgendaHorariaVentana   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:HospitalDemo.Ventanas     5   	     � Title$  AgendaHorariaVentana��5   	   $	��450��6&   $	��800��63   .��5	      � .+�5
   
   �� $
��Auto=�6   .��5      �� .+�5      ��  �� Orientation$ Vertical=�6   $��8q�64   $	��Top=�6?   .+�5      �� $ 
Horizontal=�6!   $��8q�6:   .+�5      �� -   5         ��Name$ 	agenLabel��5   $   $��Agenda: ��67   $
��10,0q�6G   $��14(�6U   $��Center=�6c   �� 5      -   5         ��Name$ selectComboBox��5   #   $	��240��6;   $��14(�6G   6U   5      �� 5      $ 
Horizontal=�6!   $��8q�6:   .+�5      �� $��Nombre: ��6$   $
��10,0q�64   $��14(�6B   $��Center=�6P   �� 5      -   5         ��Name$ nameTextBox��5   "   $	��240��67   $��14(�6C   6Q   5      �� 5      $ 
Horizontal=�6!   $��8q�6:   .+�5      �� -   5         ��Name$ 
aceptarBtn��5   !   $��Guardar��65   $
��20,0q�6G   $��14(�6o   �� 5      -   5        $ 	cancelBtn��5   !   $��Cancelar��64   $
��20,0q�6G   $
��10,0q�6V   $��14(�6|   5      5      �� 5      
���   �$��1��6,   �� 5      $ Vertical=�6   $��8q�64   $	��Top=�6?   .+�5      �� $ 
Horizontal=�6!   $��8q�6:   .+�5      �� $��Lunes: ��6$   $
��22,0q�63   $��14(�6A   $��Center=�6O   �� 5       -   5        $ lunesComboBox��5    "   $	��200��69   $��14(�6E   6S   �� 5!      -   5        $ lunesTextEstado��5!   $   $��No Trabaja Hoy��6=   
��� � � �� Padding$
 20,0q�6f   $��Center=�5"   $   $��Center=�6?   $��14(�6\   
�������$
��Bold"�5#   7   $��WrapWithOverflow=�6I   $	��400��6i   5$      �� 5%      $ 
Horizontal=�6!   $��8q�6:   .+�5&      �� $��Martes: ��6$   $
��19,0q�64   $��14(�6B   $��Center=�6P   �� 5'      -   5        $ martesComboBox��5'   "   $	��200��6:   $��14(�6F   6T   �� 5(      -	   5        $ martesTextEstado��5(   $   $��No Trabaja Hoy��6>   
��� � �$
 20,0q�6g   $��Center=�5)   $   $��Center=�6?   $��14(�6\   
�������$
��Bold"�5*   7   $��WrapWithOverflow=�6I   5+      �� 5,      $ 
Horizontal=�6!   $��8q�6:   .+�5-      �� $��Miercoles: ��6$   $
��11,0q�67   $��14(�6E   $��Center=�6S   �� 5.      -
   5        $ miercolesComboBox��5.   "   $	��200��6=   $��14(�6I   6W   �� 5/      -   5        $ miercolesTextEstado��5/   $   $��No Trabaja Hoy��6A   
��� � �$
 20,0q�6j   $��Center=�50   $   $��Center=�6?   $��14(�6\   $
��Bold"�6j   
�������$��WrapWithOverflow=�51   7   52      �� 53      $ 
Horizontal=�6!   $��8q�6:   .+�54      �� $��Jueves: ��6$   $
��20,0q�64   $��14(�6B   $��Center=�6P   �� 55      -   5        $ juevesComboBox��55   "   $	��200��6:   $��14(�6F   6T   �� 56      -   5        $ juevesTextEstado��56   $   $��No Trabaja Hoy��6>   
��� � �$
 20,0q�6g   $��Center=�57   $   $��Center=�6?   $��14(�6\   
�������$
��Bold"�58   7   $��WrapWithOverflow=�6I   59      �� 5:      $ 
Horizontal=�6!   $��8q�6:   .+�5;      �� $��	Viernes: ��6$   $
��17,0q�65   $��14(�6C   $��Center=�6Q   �� 5<      -   5        $ viernesComboBox��5<   "   $	��200��6;   $��14(�6G   6U   �� 5=      -   5        $ viernesTextEstado��5=   $   $��No Trabaja Hoy��6?   
��� � �$
 20,0q�6h   $��Center=�5>   $   $��Center=�6?   $��14(�6\   
�������$
��Bold"�5?   7   $��WrapWithOverflow=�6I   5@      �� 5A      $ 
Horizontal=�6!   $��8q�6:   .+�5B      �� $��Sabado: ��6$   $
��16,0q�64   $��14(�6B   $��Center=�6P   �� 5C      -   5        $ sabadoComboBox��5C   "   $	��200��6:   $��14(�6F   6T   �� 5D      -   5        $ sabadoTextEstado��5D   $   $��No Trabaja Hoy��6>   
��� � �$
 20,0q�6g   $��Center=�5E   $   $��Center=�6?   $��14(�6\   
�������$
��Bold"�5F   7   $��WrapWithOverflow=�6I   5G      �� 5H      $ 
Horizontal=�6!   $��8q�6:   .+�5I      �� $��	Domingo: ��6$   $
��10,0q�65   $��14(�6C   $��Center=�6Q   �� 5J      -   5        $ domingoComboBox��5J   "   $	��200��6;   $��14(�6G   6U   �� 5K      -   5        $ domingoTextEstado��5K   $   $��No Trabaja Hoy��6?   
��� � �$
 20,0q�6h   $��Center=�5L   $   $��Center=�6?   $��14(�6\   
�������$
��Bold"�5M   7   $��WrapWithOverflow=�6I   5N      5O      5P      5Q      5R      5S      