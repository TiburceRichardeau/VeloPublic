   M S B A M L   `   `   `  ���� E  AVeloPublic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:VeloPublic
VeloPublic  %    VeloPublic.WindowCollaboEnCours   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:VeloPublic     T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  W SMaterialDesignThemes.Wpf, Version=1.2.0.17629, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$(  "Energie cycle - Mode Collaboration��$
��1050��$
��1680�� � 
ResizeMode$ NoResize=�.��� .+�(  "MaterialDesignThemes.Wpf.ColorZone  $	��242��$	��Top=����#FF8C00.���  � ColumnDefinitions �� $	��43* ��� $
��355* �.+��� -    ��Name$ 
labelNomP5��$
��Left=�$��86,20,0,-53q�$y�Visible=�$	��280��$��2��$��21.333(�$
��Bold"��� -   $ 
labelNomP6��$
��Left=�$��342,20,0,-53q�$y�Visible=�$	��280��$��1��$��21.333(�$
��Bold"��� -   $ 
labelNomP7��$
��Left=�$��769,20,0,-53q�$y�Visible=�$��1��$	��280��$��21.333(�$
��Bold"��� -   $ 
labelNomP8��$
��Left=�$��1167,20,0,-53q�$��1��$	��280��$��21.333(�$
��Bold"�� .+��� -   $ labelCouleur1��$
��Left=�$��	55,24,0,0q�$	��Top=�$��27��$��27�����	#FF00E0E0 J� RenderTransformOrigin$ 2,0.63&��� -   $ vitesse1��$��	Vitesse :��$
��Left=�$��
55,103,0,0q�$	��Top=�$��37��$	��101��$��24(�$
��Bold"��� -    ��Name$ textBoxVitesse1��$
��Left=�$��23��$��286,112,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��82���� -	   $ labelVitesseMoyenne1��$��Vitesse moyenne :��$
��Left=�$��
52,140,0,0q�$	��Top=�$��24(�$
��Bold"��� -
   $ textBoxVitesseMoyenne1��$
��Left=�$��23��$��286,152,0,0q�$
 Wrap=�$	��Top=�$��82���� -   $ labelEnergieProduite1��$��Energie produite :��$
��Left=�$��
21,242,0,0q�$	��Top=�$ 0.292,1.596&�$��29.333(�$
��Bold"��� -   $ textBoxEnergieProduite1��$
��Left=�$��40��$��286,247,0,0q�$
 Wrap=�$	��Top=�$��82�� �� 
IsReadOnly . �� -   $ labelDistanceParcourue1��$��Distance Parcourue :��$
��Left=�$��	52,62,0,0q�$	��Top=�$ 0.292,1.596&�$��24(�$
��Bold"��� -   $ textBoxDistanceParcourue1��$
��Left=�$��23��$��
286,73,0,0q�$
 Wrap=�$	��Top=�$��82��$ 0.486,1.731&��� -   $ labelCalorie1��$��Calories Brûlées :��$
��Left=�$��44��$��
52,182,0,0q�$	��Top=�$	��214��$��24(�$
��Bold"��� -   $ textBoxCalorie1��$
��Left=�$��23��$��286,190,0,0q�$
 Wrap=�$	��Top=�$��82���� $
��Left=�$	��165��$��	52,62,0,0q�
���   �$	��Top=�$	��316������ �� -   $ labelCouleur2��$
��Left=�$��
482,24,0,0q�$	��Top=�$��27��$��27��
���  ��$ 
3.19,0.857&��� -   $ labelVitesse2��$��	Vitesse :��$
��Left=�$��482,103,0,0q�$	��Top=�$ 0.292,1.596&�$��24(�$
��Bold"��� -   $ textBoxVitesse2��$
��Left=�$��23��$��716,112,0,0q�$
 Wrap=�$	��Top=�$��82���� -   $ labelVitesseMoyenne2��$��Vitesse Moyenne :��$
��Left=�$��482,140,0,0q�$	��Top=�$ 0.686,0.212&�$��24(�$
��Bold"��� -   $ textBoxVitesseMoyenne2��$
��Left=�$��23��$��716,152,0,0q�$
 Wrap=�$	��Top=�$��82���� -   $ labelDistanceParcourue2��$��Distance Parcourue :��$
��Left=�$��
482,62,0,0q�$	��Top=�$ 0.292,1.596&�$��24(�$
��Bold"��� -   $ textBoxDistanceParcourue2��$
��Left=�$��23��$��
716,73,0,0q�$
 Wrap=�$	��Top=�$��82��$ 
0.55,0.808&��� -   $ labelEnergieProduite2��$��Energie produite :��$
��Left=�$��459,242,0,0q�$	��Top=�$ 0.292,1.596&�$��29.333(�$
��Bold"��� -   $ textBoxEnergieProduite2��$
��Left=�$��40��$��716,247,0,0q�$
 Wrap=�$	��Top=�$��82�� . �� -   $ labelCalorie2��$��Calories Brûlées :��$
��Left=�$��44��$��482,182,0,0q�$	��Top=�$	��215��$��24(�$
��Bold"��� -   $ textBoxCalorie2��$
��Left=�$��23��$��716,190,0,0q�$
 Wrap=�$	��Top=�$��82���� -    ��Name$
 rec2��$
��Left=�$	��165��$��
482,62,0,0q�
���   �$	��Top=�$	��316������ �� -   $ labelCouleur3��$
��Left=�$��
908,24,0,0q�$	��Top=�$��27��$��26�����	#FF00FF17$ 3.048,0.952&��� -   $ labelVitesse3��$��	Vitesse :��$
��Left=�$��908,103,0,0q�$	��Top=�$ 0.292,1.596&�$��24(�$
��Bold"��� -   $ textBoxVitesse3��$
��Left=�$��23��$��1142,112,0,0q�$
 Wrap=�$	��Top=�$��82���� -    $ labelVitesseMoyenne3��$��Vitesse Moyenne :��$
��Left=�$��908,140,0,0q�$	��Top=�$ 0.686,0.212&�$��24(�$
��Bold"��� -!   $ textBoxVitesseMoyenne3��$
��Left=�$��23��$��1142,152,0,0q�$
 Wrap=�$	��Top=�$��82���� -"   $ labelDistanceParcourue3��$��Distance Parcourue :��$
��Left=�$��
908,62,0,0q�$	��Top=�$ 0.292,1.596&�$��24(�$
��Bold"��� -#   $ textBoxDistanceParcourue3��$
��Left=�$��23��$��1142,73,0,0q�$
 Wrap=�$	��Top=�$��82��$ 
0.55,0.808&��� -$   $ labelEnergieProduite3��$��Energie produite :��$
��Left=�$��885,242,0,0q�$	��Top=�$ 0.292,1.596&�$��29.333(�$
��Bold"��� -%   $ textBoxEnergieProduite3��$
��Left=�$��40��$��1142,247,0,0q�$
 Wrap=�$	��Top=�$��82�� . �� -&   $ labelCalorie3��$��Calories Brûlées :��$
��Left=�$��44��$��908,182,0,0q�$	��Top=�$	��215��$��24(�$
��Bold"��� -'   $ textBoxCalorie3��$
��Left=�$��23��$��1142,190,0,0q�$
 Wrap=�$	��Top=�$��82���� -(   $
 rec3��$
��Left=�$	��165��$��
908,62,0,0q�
���   �$	��Top=�$	��316������ �� -)   $ labelCouleur4��$
��Left=�$��1310,24,0,0q�$	��Top=�$��27��$��27�����	#FFA152FF$ 11.286,4.429&�$y�Visible=��� -*   $ labelVitesse4��$��	Vitesse :��$
��Left=�$��1310,103,0,0q�$	��Top=�$ 0.292,1.596&�$��24(�$
��Bold"��� -+   $ textBoxVitesse4��$
��Left=�$��23��$��1544,112,0,0q�$
 Wrap=�$	��Top=�$��82���� -,   $ labelVitesseMoyenne4��$��Vitesse Moyenne :��$
��Left=�$��1310,140,0,0q�$	��Top=�$ 0.686,0.212&�$��24(�$
��Bold"��� --   $ textBoxVitesseMoyenne4��$
��Left=�$��23��$��1544,152,0,0q�$
 Wrap=�$	��Top=�$��82���� -.   $ labelDistanceParcourue4��$��Distance Parcourue :��$
��Left=�$��1310,62,0,0q�$	��Top=�$ 0.292,1.596&�$��24(�$
��Bold"��� -/   $ textBoxDistanceParcourue4��$
��Left=�$��23��$��1544,73,0,0q�$
 Wrap=�$	��Top=�$��82��$ 
0.55,0.808&��� -0   $ labelEnergieProduite4��$��Energie produite :��$
��Left=�$��1287,242,0,0q�$	��Top=�$ 0.292,1.596&�$��29.333(�$
��Bold"��� -1   $ textBoxEnergieProduite4��$
��Left=�$��40��$��1544,247,0,0q�$
 Wrap=�$	��Top=�$��82�� . �� -2   $ labelCalorie4��$��Calories Brûlées :��$
��Left=�$��44��$��1310,182,0,0q�$	��Top=�$	��215��$��24(�$
��Bold"��� -3   $ textBoxCalorie4��$
��Left=�$��23��$��1544,190,0,0q�$
 Wrap=�$	��Top=�$��82���� -4   $
 rec4��$
��Left=�$	��165��$��1310,62,0,0q�
���   �$	��Top=�$	��316������ �� -5   	 ��Name$	 buttonGo��$
��Go !��$
��Left=�$��74��$��771,888,0,0q�$	��Top=�$	��163��$��48(�$
��Bold"��� -6   $ 
labelTimer��$	��142��$��716,741,0,0q�$	��268��$��41.333(�$
��Left=�$	��Top=�$��Center=��� -7   $	 buttonResume��$��RESUME��$
��Left=�$��71��$��771,891,0,0q�$	��Top=�$	��163��$��32(�$y�Hidden=��� -8   
 ��Name$
 graph_vitesse��$��/Images/Graph_1.png�� J� OpacityMask �	#FFACAC38$��10,292,950,16q��� -9   $
 graph_puissance��$��/Images/Graph_2.png�� �	#FFACAC38$��960,287,0,21q�