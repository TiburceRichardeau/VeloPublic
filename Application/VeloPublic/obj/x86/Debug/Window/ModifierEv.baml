   M S B A M L   `   `   `  ����E  AVeloPublic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:VeloPublic.WindowVeloPublic.Window  5   	   T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5	   	   "    VeloPublic.Window.ModifierEv   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:VeloPublic.Window     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5	   	   -   5          � Title$  Modifier Evenement��5   	   $	��300��6$   $	��300��61   
�������.��5      � .+�5   
   �� -   5         ��Name$ 
RectRetour��5      ���#353F40���#353F40 K� ZIndex$ -1��6H    �� RadiusX$ 5,5,0,0��6Z    �� RadiusY$ 5,5,0,0��6l   $
��Left=�6~   $��5,5,0,0q�6�   $	��Top=�6�   $��40��6�   $��40��6�   $y�Visible=�6  6C  �� 5   
   -   5         ��Name$ imageRetour��5      $��../Images/left-arrow.png��6%   $
��Left=�6G   $��	15,15,0,0q�6b   $	��Top=�6u   $��20��6�   $��20��6�   $y�Visible=�6�    � ToolTip 5      �� 5      $��Précédent��6   5      �� 5   
   -   5         ��Name$ textBoxNomEv��5      $��Center=�6(   $��23��6E   $��0,55,0,0q�6Q    �� TextWrapping$ WrapWithOverflow=�6c   $	��Top=�6�   $	��200��6�   $��Nom de l'événement��6
  	 �� 	MaxLength$	 50��6$  .��63   5      �� 5      $��Nom de l'événement��6   .��5      5      �� 5   
   -   5        $ textBoxLieu��5      $��Center=�6'   $��23��6D   $��	0,108,0,0q�6P   $
 Wrap=�6c   $	��Top=�6w   $	��200��6�   $
��Lieu��6�   $	 50��6  .��6   5      �� 5      $��Lieu de l'événement��6   .��5      5      (  "System.Windows.Controls.DatePicker  5   
   -   5        
  Name$

 DPEv��5      $
��Left=�6#   $��
75,153,0,0q�6>   $	��Top=�6R   $y�Visible=�6j    � 	Resources 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value��%[   '        �� 5      "  6   .�5      ��  �@��
IsReadOnly . 63   5       5!      5"      �� 5#   
   -   5        $ imageValider��5#      $��../Images/check.png��6&   $��50��6C   $��50��6O   $��Center=�6Z   $��Bottom=�6w   $��108,0,108,10q�6�   $y�Visible=�6�   6  5$      5%      