   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      (� .��5
   
   � $	��800��6   
�������.+�5      �� $��50q�6   $��Right=�6%    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers :� RoutedEvent		 �� To
 g� Duration �� TargetProperty��%  '��       �� 5      " ��6   .�5      ��  � ��$	 140��62   �� 5       � ��$ 50��63   �� 5       � ��$ 10q�63   �� 5       � �� �#007ACC67   �� 5       � ��
 �����67   �� 5       � ��$ 0q�6<   �� 5       � ��$ Segoe UI)�67   �� 5       � ��$ 14(�65   �� 5       �@�Cursor$
 Hand��63   �� 5       � �� 5      �� 5   "   " ��62   .R�5   &   �� #��z��6-   #��z��5   !   #��z��5   !   $ 8��5   !   ._�5   *   �� $��Center=�6;   $��Center=�6X   5    '    5!   &   :� 5#   *   $ 
MouseEnter��67   [�5$   .   �� 5%   2   .��5&   6   �� .��5'   :   �� 	 #005AA56I   $
 0:0:0.2D�6V   $1 +(Border.Background).(SolidColorBrush.Color)�6i   5(   7   5)   3   5+   +   :� 5-   *   $ 
MouseLeave��67   [�5.   .   �� 5/   2   .��50   6   �� .��51   :   �� 	 #007ACC6I   $
 0:0:0.2D�6V   $1 +(Border.Background).(SolidColorBrush.Color)�6i   52   7   53   3   55   +   57   #   59      5:      5;      .+�5=      �� -   5        $��	Új Diák��5=      6+   �� 5>      -   5        $��Törlés��5>      6*   �� 5?      -   5        $��Exportálás��5?      6.   �� 5@      -   5        $��Importálás��5@      6.   �� 5A      -   5        $��Módosítás��5A      6-   5B      &   System.Windows.Controls.DataGrid  5C      -   5          Name$ 
myDataGrid��5C         AutoGenerateColumns$ False��6+      
IsReadOnly$
 True��5D      $��400px��6"   $
��10pxq�60   $
��Left=�6>      Columns 5E      0  *System.Windows.Controls.DataGridTextColumn  5F      ,  &System.Windows.Controls.DataGridColumn   Header$ OM azonosító��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Om_azonosito+  5G      $
 Név��6)    66   �� *Név+  5H      $ Értesítési cím��6)    6A   �� *Ertesitesi_cim+  5I      $ Születési dátum��6)    6B   �� *Szuletesi_datum+  5J      $ Elérhetőség email��6)    6D   �� *Elerhetoseg_email+  5K      $ Matek pontszám��6)    6A   �� *	Matekpont+  5L      $ Magyar pontszám��6)    6B   �� *Irodalompont+5N      5O      5P      5Q      