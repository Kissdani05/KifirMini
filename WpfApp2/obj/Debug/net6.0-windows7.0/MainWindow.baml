   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� $��50q�6   $��Right=�6!   .+�5      �� -   5        $��	Új Diák��5      $	��100��6'   $��40��63   $
��10pxq�6^   �� 5      -   5        $��Exportálás CSV��5      $
��10pxq�6.   $
��Left=�6V   $	��Top=�6q   $	��100��6�   $
��40px��6�   �� 5      -   5        $��Exportálás JSON��5      $
��10pxq�6/   $
��Left=�6V   $	��Top=�6q   $	��100��6�   $
��40px��6�   �� 5      -   5        $��Importálás��5      $
��10pxq�6*   $
��Left=�6T   $	��Top=�6o   $	��100��6�   $
��40px��6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
myDataGrid��5         AutoGenerateColumns$ False��6'      
IsReadOnly$
 True��5      $��600px��6"   $
��10pxq�60   $
��Left=�6>      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ OM azonosító��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Om_azonosito+  5      $
 Név��6%    62   �� *Név+  5      $ Értesítési cím��6%    6=   �� *Ertesitesi_cim+  5      $ Születési dátum��6%    6>   �� *Szuletesi_datum+  5      $ Elérhetőség email��6%    6@   �� *Elerhetoseg_email+  5      $ Matek pontszám��6%    6=   �� *	Matekpont+  5      $ Magyar pontszám��6%    6>   �� *Irodalompont+5      5      5      