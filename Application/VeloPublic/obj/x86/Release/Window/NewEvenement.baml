   M S B A M L   `   `   `  ���� T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  E AVeloPublic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:VeloPublic
VeloPublic    VeloPublic.NewEvenement   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     *localclr-namespace:VeloPublic     -     � Title$  événement��$	��250��$	��300��
������� � 
ResizeMode$ NoResize=�.��� .+��� -    ��Name$ 
RectRetour�����#353F40���#353F40 K� ZIndex$ -1�� �� RadiusX$ 5,5,0,0�� �� RadiusY$ 5,5,0,0��$
��Left=�$��5,5,0,0q�$	��Top=�$��40��$��40��$y�Visible=��� -    ��Name$ imageRetour��$��../Images/left-arrow.png��$
��Left=�$��	15,15,0,0q�$	��Top=�$��20��$��20��$y�Visible=� � ToolTip �� $��Précédent���� -    ��Name$ 
labelNewEv��$	��Top=�$��Center=��� -   $ RectNouvelEv�����#353F40���#353F40$ -1��$ 5,5,0,0��$ 5,5,0,0��$
��Left=�$��	18,61,0,0q�$	��Top=�$	��100��$	��100���� -   $ imageNouvelEv��$��../Images/Add.png��$ 1��$
��Left=�$��	38,81,0,0q�$	��Top=�$��60��$��60���� -   $ RectEvExistant�����#353F40���#353F40$ -1��$ 5,5,0,0��$ 5,5,0,0��$��	0,61,18,0q�$	��Top=�$	��100��$��Right=�$	��100���� -   $ imageEvExistant��$��../Images/find.png��$ 1��$��	0,81,38,0q�$	��Top=�$��60��$��Right=�$��60���� -	   	 ��Name$	 textBoxNomEv��$��Center=�$��23��$��0,55,0,0q�
 �� TextWrapping$
 WrapWithOverflow=�$	��Top=�$	��200��$y�Hidden=�
�������$��Nom de l'événement�� �� 	MaxLength$ 50���� -
   $	 textBoxLieu��$��Center=�$��23��$��	0,108,0,0q�$

 Wrap=�$	��Top=�$	��200��$y�Hidden=�
�������$
��Lieu��$ 50��(  "System.Windows.Controls.DatePicker  -     Name$
 DPEv��$
��Left=�$��
75,153,0,0q�$	��Top=�$y�Hidden=� � 	Resources :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value��%6   '        �� "  .���  �@��
IsReadOnly . �� -   $ imageValider��$��../Images/check.png��$��50��$��50��$��Center=�$��Bottom=�$��108,0,108,10q�$y�Hidden=�&   System.Windows.Controls.DataGrid  -     Name$ dataGridListEv��$	��185��$��18,56,18,-62q�$	��Top=�$y�Hidden=�$��20(�   
IsReadOnly .    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$	 Nom��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$	 nom�  $
 Date�� �� $ 
dateString�  $
 Lieu��   Width5  /System.Windows.Controls.DataGridLengthConverter$ *  �� $
 lieu�  $ id��   
Visibility$ Hidden=� �� $ idLong��� -   $ labelNouvelEv��$��Nouvel Evénement��$
��Left=�$��
12,164,0,0q�$	��116��$��26��$	��Top=�$��Center=��� -   $ labelEvExistant��$��Evénements Existants��$��	0,164,6,0q�$��26��$	��Top=�$��Center=�$��Right=�$	��135��