   M S B A M L   `   `   `  ���� E  AVeloPublic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:VeloPublic
VeloPublic  *    $VeloPublic.ModeDefiChoixParticipants   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:VeloPublic     T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  W SMaterialDesignThemes.Wpf, Version=1.2.0.17629, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$B  <Energie Cycle - Mode Défi - Enregistrement des participants��$	��200��$
��1200�� � 
ResizeMode$ NoResize=�.��� .+��� -    ��Name$ ImageModeTest��$��../Images/Coco.png��$	��200��$	��200��$	��Top=�$
��Left=�$y�Hidden=� K� ZIndex$ -1���� -    ��Name$ 
RectRetour�����#353F40���#353F40$ -1�� �� RadiusX$ 5,5,0,0�� �� RadiusY$ 5,5,0,0��$
��Left=�$��5,5,0,0q�$	��Top=�$��40��$��40��$y�Visible=��� -   $ imageRetour��$��../Images/left-arrow.png��$
��Left=�$��	15,15,0,0q�$	��Top=�$��20��$��20��$y�Visible=� � ToolTip �� $��Précédent���� -    ��Name$ 	labelMode��$��Center=�$	��Top=�$��Center=����#353F40$��25(��� -   $ ImageNbParticipant��$��../Images/people.png��$��50��$��50��$��227,76,917,0q�$	��Top=� �� $��Nombres de participants���� -   $ ��stackpanelchoixnbpersonnes��$
��Left=�$��38��$��
321,88,0,0q�$	��Top=�$	��276��	 �� Orientation$	 
Horizontal=�.+�	� -   
 	�Name$
 radioButton1��$��1��$��53�����#353F40$��25(�	� -	   $
 radioButton2��$��2��$��53�����#353F40$��25(�	� -
   $
 radioButton3��$��3��$��53�����#353F40$��25(�	� -   $
 radioButton4��$��4��$��53�����#353F40$��25(�� $��0,0,0,1q�.+��� -   $ ImageP1��$��../Images/business.png��$��50��$��50��$
��Left=�$��135,193,0,0q�$	��Top=�$y�Hidden=� �� $��Participant 1���� -    ��Name$ textBoxNom1��$
��Left=�$��23��$��100,242,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��120��$y�Hidden=�
������� �� 	MaxLength$ 25���� -   $ textBoxPrenom1��$
��Left=�$��23��$��100,273,0,0q�$
 Wrap=�$	��Top=�$	��120��$y�Hidden=�
�������$ 25���� -   $ textBoxPoids1��$
��Left=�$��23��$��100,304,0,0q�$
 Wrap=�$	��Top=�$	��120��$y�Hidden=�
�������$ 4���� -   $ ImageP2��$��../Images/business.png��$��50��$��50��$
��Left=�$��369,193,0,0q�$	��Top=�$y�Hidden=� �� $��Participant 2���� -   $ textBoxNom2��$
��Left=�$��23��$��334,242,0,0q�$
 Wrap=�$	��Top=�$	��120��$y�Hidden=�
�������$ 25���� -   $ textBoxPrenom2��$
��Left=�$��23��$��334,273,0,0q�$
 Wrap=�$	��Top=�$	��120��$y�Hidden=�
�������$ 25���� -   $ textBoxPoids2��$
��Left=�$��23��$��334,304,0,0q�$
 Wrap=�$	��Top=�$	��120��$y�Hidden=�
�������$ 4���� -   $ ImageP3��$��../Images/business.png��$��50��$��50��$
��Left=�$��617,193,0,0q�$	��Top=�$y�Hidden=� �� $��Participant 3���� -   $ textBoxNom3��$
��Left=�$��23��$��582,242,0,0q�$
 Wrap=�$	��Top=�$	��120��$y�Hidden=�
�������$ 25���� -   $ textBoxPrenom3��$
��Left=�$��23��$��582,273,0,0q�$
 Wrap=�$	��Top=�$	��120��$y�Hidden=�
�������$ 25���� -   $ textBoxPoids3��$
��Left=�$��23��$��582,304,0,0q�$
 Wrap=�$	��Top=�$	��120��$y�Hidden=�
�������$ 4���� -   $ ImageP4��$��../Images/business.png��$��50��$��50��$
��Left=�$��881,193,0,0q�$	��Top=�$y�Hidden=� �� $��Participant 4���� -   $ textBoxNom4��$
��Left=�$��23��$��846,242,0,0q�$
 Wrap=�$	��Top=�$	��120��$y�Hidden=�
�������$ 25���� -   $ textBoxPrenom4��$
��Left=�$��23��$��846,273,0,0q�$
 Wrap=�$	��Top=�$	��120��$y�Hidden=�
�������$ 25���� -   $ textBoxPoids4��$
��Left=�$��23��$��846,304,0,0q�$
 Wrap=�$	��Top=�$	��120��$y�Hidden=�
�������$ 4���� -    ��Name$ checkBoxTest��$
��Test��$
��Left=�$��545,340,0,0q�$	��Top=�$��75�����#353F40$y�Hidden=��� -   $ ImageValider��$��../Images/check.png��$
��Left=�$��545,408,0,0q�$	��Top=�$��50��$��50��$y�Hidden=��� -   $ textBoxTempsHeureDefi��$
��Left=�$��23��$��480,361,0,0q�$
 Wrap=�$	��Top=�$��50��$y�Visible=�$��0��$ 2���� -   $ labelTempsHeureDefi��$��h��$
��Left=�$��530,358,0,0q�$	��Top=�$y�Visible=����#353F40�� -    $ textBoxTempsMinDefi��$
��Left=�$��23��$��550,361,0,0q�$
 Wrap=�$	��Top=�$��50��$y�Hidden=�$ 2���� -!   $ labelTempsMinDefi��$
��mins��$
��Left=�$��606,358,0,0q�$	��Top=�$y�Hidden=����#353F40�� -"   $ textBoxTempsSecDefi��$
��Left=�$��23��$��641,361,0,0q�$
 Wrap=�$	��Top=�$��50�� J� RenderTransformOrigin$ 2.38,-1.465&�$y�Hidden=�$ 2���� -#   $ labelTempsSecDefi��$��secondes��$
��Left=�$��696,358,0,0q�$	��Top=�$ 6.093,1.325&�$y�Hidden=����#353F40