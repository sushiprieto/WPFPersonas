   M S B A M L   `   `   `  ����J  F018_WPFPersonas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:_018_WPFPersonas_018_WPFPersonas  5   	   -clr-namespace:UI.ViewModelsUI.ViewModels  5   	   !    _018_WPFPersonas.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:_018_WPFPersonas     5   	   *vmclr-namespace:UI.ViewModels     5   	     �Language$  es-ES�5	   K    � Title$ 
MainWindow��6	   $	��400��6   $	��600��6)    � 
ResizeMode$ NoResize=�65    � DataContext 5      !   UI.ViewModels.clsMainPageVM  5   
   6   .��5      ]� ��. .+�5   
   �� $	��Top=�6    �� Orientation$ 
Horizontal=�6*   $��6q�6C   ���	#FFF0F0F0.+�5      �� -   5        $��btnNew��5      $��2q�6#   
������� � ToolTip$ Crea una nueva persona��6A   ��6b   ��  �� Path$ nuevoCommand�y�6�   �� *Visibilidad+.��5      �� $��..\Images\new.png��6   $��25��63   $��25��6>   6L   5      �� 5      -   5        $��btnSave��5      $��2q�6$   
�������$ Guarda una persona��6B   ��6_   �� $ guardarCommand�.��5      �� $��..\Images\save.png��6   $��25��64   $��25��6?   6M   5      �� 5      -   5        $��	btnDelete��5      $��2q�6&   
�������$ Borra una persona��6D   ��6`   �� $ eliminarCommand�y�6�   �� *Visibilidad+.��5      �� $��..\Images\delete.png��6   $��25��66   $��25��6A   6O   5      �� 5       -   5        $��btnDeshacer��5       $��2q�6(   
�������$ Deshace los cambios��6F   ��6d   �� *deshacerCommand+y�6�   �� *VisibilidadDeshacer+.��5!      �� $��..\Images\noimage.png��6   $��25��67   $��25��6B   5"      5$      �� 5'   
   $��Bottom=�6   $ 
Horizontal=�6-   ���	#FFF0F0F0$��6q�6]   .+�5(      �� $0��*Ameisin application que te cagas caranchoa��6   5)      �� 5,   
   -   5        $��scrLista��5,      ���	#FFF0F0F0$
��Left=�6>   $	��150��6T   .��5.      �� -   5        $��listadoPersonas��5.      ���	#FFF0F0F0$	��150��6E   $��4q�6T   ��6_   �� *	listado+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6�   �� *personaSeleccionada+	 �� Mode$	 TwoWay=�y�6�   �� *Visibilidad+��5/      �� 50      .R�51      �� $ 
Horizontal=�6%   .+�52      �� ��6(   �� *Nombre+�� 53      $��4,0,0,0q�6C   ��6(   �� *	Apellidos+6C   54      55      57      59      � 5=   
   -   5        $��GridContenido��5=   1   $��6q�6   ���	#FFF0F0F0 6F   �� *personaSeleccionada+$	 TwoWay=�
 � RowDefinitions
 5?      �� 5@      $
��auto �6    60   �� 5A      $
��auto �6    60   �� 5B      $
��auto �6    60   �� 5C      $
��auto �6    60   �� 5D      $
��auto �6    60   �� 5E      $
��auto �6    60   �� 5F      $
��auto �6    60   �� 5G      $
��auto �6    60    � ColumnDefinitions 5I      �� 5J      $
��auto �6#   62   �� 5K      $��* �6#   6/   .+�5N      �� $��Nombre:��6   $��0��6'   $
��12,8q�64   $��Center=�6B   �� 5O      -   5        $��	txbNombre��5O      $��1��6'   $
��12,8q�67   $	��100��6E   $
��Left=�6T   ��6o   �� *Nombre+$	 TwoWay=�$ PropertyChanged=��� 5Q      $��
Apellidos:��6   $��1��6*   $
��12,8q�67   $��Center=�6E   �� 5R      -	   5        $��txbApellidos��5R      $��1��6*   $��1��68   $
��12,8q�6H   $	��150��6V   $
��Left=�6e   ��6�   �� *	Apellidos+$	 TwoWay=�$ PropertyChanged=��� 5T      $��Fecha Nacimiento:��6   $��2��61   $
��12,8q�6>   $��Center=�6L   �� 5U      -
   5        $��txbEdad��5U      $��2��6%   $��1��63   $
��12,8q�6C   $	��110��6Q   $
��Left=�6`   ��6{   �� *
FechaNac+$	 TwoWay=�$ PropertyChanged=��� 5W      $��
Teléfono:��6   $��3��6)   $
��12,8q�66   $��Center=�6D   �� 5X      -   5        $��txbTelefono��5X      $��3��6)   $��1��67   $
��12,8q�6G   $	��100��6U   $
��Left=�6d   ��6   �� *
Telefono+$	 TwoWay=�$ PropertyChanged=��� 5Z      $ Vertical=�6   $��4��60   $��2��6=   $	��300��6Q   $
��Left=�6`   .+�5[      �� $��Dirección:��6   $��
12,20,12,0q�6.   $��Center=�6B   �� 5\      -   5        $��txbDireccion��5\      $
��12,0q�6.   $��60��6�    �� TextWrapping$
 Wrap=�6�   ��6<   �� *	Direccion+$	 TwoWay=�$ PropertyChanged=�6�   5]      5_      5c      5d      