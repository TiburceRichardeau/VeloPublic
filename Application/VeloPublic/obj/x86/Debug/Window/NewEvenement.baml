   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   E AVeloPublic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:VeloPublic
VeloPublic 5   	      VeloPublic.NewEvenement   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   *localclr-namespace:VeloPublic     5   	   -   5          � Title$  événement��5	   	   $	��250��6   $	��300��6(   
������� � 
ResizeMode$ NoResize=�6G   .��5
      � .+�5   
   �� -   5         ��Name$ 
RectRetour��5      ���#353F40���#353F40 K� ZIndex$ -1��6H    �� RadiusX$ 5,5,0,0��6Z    �� RadiusY$ 5,5,0,0��6l   $
��Left=�6~   $��5,5,0,0q�6�   $	��Top=�6�   $��40��6�   $��40��6�   $y�Visible=�6  6C  �� 5   
   -   5         ��Name$ imageRetour��5      $��../Images/left-arrow.png��6%   $
��Left=�6G   $��	15,15,0,0q�6b   $	��Top=�6u   $��20��6�   $��20��6�   $y�Visible=�6�    � ToolTip 5      �� 5      $��Précédent��6   5      �� 5   
   -   5         ��Name$ 
labelNewEv��5      $	��Top=�6$   $��Center=�6<   �� 5   
   -   5        $ RectNouvelEv��5      ���#353F40���#353F40$ -1��6J   $ 5,5,0,0��6\   $ 5,5,0,0��6n   $
��Left=�6�   $��	18,61,0,0q�6�   $	��Top=�6�   $	��100��6�   $	��100��6�   6�   �� 5   
   -   5        $ imageNouvelEv��5      $��../Images/Add.png��6'   $ 1��6B   $
��Left=�6S   $��	38,81,0,0q�6n   $	��Top=�6�   $��60��6�   $��60��6�   6	  �� 5   
   -   5        $ RectEvExistant��5      ���#353F40���#353F40$ -1��6L   $ 5,5,0,0��6^   $ 5,5,0,0��6p   $��	0,61,18,0q�6�   $	��Top=�6�   $	��100��6�   $��Right=�6�   $	��100��6�   6�   �� 5   
   -   5        $ imageEvExistant��5      $��../Images/find.png��6)   $ 1��6E   $��	0,81,38,0q�6V   $	��Top=�6i   $��60��6�   $��Right=�6�   $��60��6�   6  �� 5   
   -	   5        	 ��Name$	 textBoxNomEv��5      $��Center=�6(   $��23��6E   $��0,55,0,0q�6Q   
 �� TextWrapping$
 WrapWithOverflow=�6c   $	��Top=�6�   $	��200��6�   $y�Hidden=�6�   
�������$��Nom de l'événement��61   �� 	MaxLength$ 50��6K  �� 5   
   -
   5        $	 textBoxLieu��5      $��Center=�6'   $��23��6D   $��	0,108,0,0q�6P   $

 Wrap=�6c   $	��Top=�6w   $	��200��6�   $y�Hidden=�6�   
�������$
��Lieu��6�   $ 50��6*  (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$
 DPEv��5      $
��Left=�6#   $��
75,153,0,0q�6>   $	��Top=�6R   $y�Hidden=�6j    � 	Resources 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value��%[   '        �� 5      "  6   .�5      ��  �@��
IsReadOnly . 63   5      5      5      �� 5    
   -   5        $ imageValider��5       $��../Images/check.png��6&   $��50��6C   $��50��6O   $��Center=�6Z   $��Bottom=�6w   $��108,0,108,10q�6�   $y�Hidden=�6�   6  &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ dataGridListEv��5!      $	��185��6+   $��18,56,18,-62q�68   $	��Top=�6N   $y�Hidden=�6f   $��20(�6�      
IsReadOnly .    Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$	 Nom��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   ��  �� Path$	 nom�  5$      $
 Date��6%    63   �� $ 
dateString�  5%      $
 Lieu��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Q    63   �� $
 lieu�6Q     5&      $ id��6%      
Visibility$ Hidden=�6Q    61   �� $ idLong�6Q   5(      �� 52   
   -   5        $ labelNouvelEv��52      $��Nouvel Evénement��6'   $
��Left=�6B   $��
12,164,0,0q�6]   $	��116��6q   $��26��6}   $	��Top=�6�   $��Center=�6�   6  �� 53   
   -   5        $ labelEvExistant��53      $��Evénements Existants��6)   $��	0,164,6,0q�6H   $��26��6[   $	��Top=�6g   $��Center=�6   $��Right=�6)  $	��135��6E  54      55      