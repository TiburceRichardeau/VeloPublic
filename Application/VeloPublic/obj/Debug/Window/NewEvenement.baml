   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   E AVeloPublic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:VeloPublic
VeloPublic 5   	      VeloPublic.NewEvenement   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   *localclr-namespace:VeloPublic     5   	     � Title$  	Evenement��5	   	   $	��180��6   $	��300��6(   
������� � 
ResizeMode$ NoResize=�6G   .��5
      � .+�5   
   �� -   5         ��Name$ 
labelNewEv��5      $$��Est-ce un nouvel événement ?��6$   $	��Top=�6K   $��Center=�6c   �� 5   
   -   5         ��Name$ 	buttonOui��5      $	��Oui��6$   $
��Left=�62   $��	18,31,0,0q�6M   $	��Top=�6`   $	��116��6x   $��72��6�   �� 5   
   -   5        $ 	buttonNon��5      $	��Non��6$   $��149,31,18,0q�62   $	��Top=�6G    J� RenderTransformOrigin$ 0.424,0.119&�6_   $��72��6�   �� 5   
   -   5        $ labelNom��5      $��Nom de l'événement ��6"   $
��Left=�6@   $��	10,53,0,0q�6[   $	��Top=�6n   $y�Hidden=�6�   �� 5   
   -   5         ��Name$ textBoxNomEv��5      $
��Left=�6(   $��23��6C   $��
149,55,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��120��6�   $y�Hidden=�6�   �� 5   
   -   5        $ 	labelLieu��5      $
��Lieu��6#   $
��Left=�62   $��
10,108,0,0q�6M   $	��Top=�6a   $y�Hidden=�6y   �� 5   
   -   5        $ textBoxLieu��5      $
��Left=�6'   $��23��6B   $��149,108,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��120��6�   $y�Hidden=�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$
 DPEv��5      $
��Left=�6#   $��
75,153,0,0q�6>   $	��Top=�6R   $y�Hidden=�6j   �� 5   
   -	   5        $ buttonValider��5      $��Valider��6(   $��Center=�6:   $��Bottom=�6W   $��76��6r   $y�Hidden=�6}   $��25��6�   $��108,0,108,10q�6�   6�   �� 5   
   -
   5         ��Name$ 
listViewEv��5      $	��185��6'   $��18,26,18,-62q�64   $	��Top=�6J   $y�Hidden=�6b   	 �� View	 5      �� 5      -   5        gridView��.P�5      �� 
 �� Width$
 80��6%   $	��Nom��6[    �� DisplayMemberBinding 60   ��  �� Path$	 Nom�6[   �� 5      $
 80��6%   $
��Date��6]    60   �� $
 Date�6]   �� 5      $
 80��6%   $
��Lieu��6]    60   �� $
 Lieu�6]   5      5      �� 5   
   -   5        $ buttonCréerEv��5      $��Créer un événement��6(   $
��Left=�6E   $��	18,40,0,0q�6`   $	��Top=�6s   $	��258��6�   $��94��6�   $y�Hidden=�6�   5      5      