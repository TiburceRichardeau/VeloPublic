   M S B A M L   `   `   `  ����E  ADragablz, Version=0.0.3.163, Culture=neutral, PublicKeyToken=null5(clr-namespace:Dragablz;assembly=DragablzDragablz  5      E AVeloPublic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:VeloPublic
VeloPublic 5      G1clr-namespace:Dragablz.Dockablz;assembly=DragablzDragablz.Dockablz  5         VeloPublic.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;controls,http://metro.mahapps.com/winfx/xaml/controls  5      7dragablz(clr-namespace:Dragablz;assembly=Dragablz  5      8mahMaterialDragablzMashUpclr-namespace:VeloPublic  5      @dockablz1clr-namespace:Dragablz.Dockablz;assembly=Dragablz  5      W SMaterialDesignThemes.Wpf, Version=1.2.0.17629, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      (  "MahApps.Metro.Controls.MetroWindow    WindowTransitionsEnabled  .  ���#2196F3   AccentColorBrush   	GlowBrush# �   5       � Title$ Energie Cycle��5      $	��450��6-   $	��900��6:   $	��450��6F   $	��900��6V      RightWindowCommands 5      +  %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� -   5         ��Name$ ButtonInfos��5      .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��20��6    $��20��6+   ��67   ��  �� RelativeSource ��  �� AncestorType$ ButtonL� �� Path$ 
Foreground�	 J� OpacityMask	 5      !� 5      
 j� Stretch$

 Fill=�6*     appbar_information_circle !� Visual# [ 69   5      �� 5      -   5         ��Name$ textblockInfos��5       $��
 A propos ��68   5      5      5      .��5      � -   5         �Name$ 	ChoixMode��5       � RowDefinitions 5   
   �� 5      $	��75* �6   �� 5      $
��257* �6   �� 5       $	��87* �6    � ColumnDefinitions 5"   
   �� 5#      �� 5$      .+�5&   
   �� -   5         ��Name$ 
labelTitre��5&      $��Selectionnez un mode��6$   $	��Top=�6C   $��Center=�6[   $��Center=�6   $��30(�6�   $��Center=�6�   $	��320��6�   
�������$��0��6�   $��0��6�   $��2��6  $��50��6  �� 5'   
   -   5         ��Name$ modeCollaboImage��5'      $��../Images/tandem.png��6*   	 �	#FFACAC38|�.  $��1��6�   $��1��6�   $��10,10,10,10q�6�   6�   �� 5(   
   -   5        $ labelCollabo��5(      $��Collaboration��6&   $��Center=�6>   $	��188��6[   
�������$��25(�6�   $��Center=�6�   $��1��6  $��2��6'  �� 5*   
   -   5        $ modeDefiImage��5*      $��../Images/defi.png��6'   	 �	#FFACAC38$��0��6�   $��1��6�   $��10,10,10,10q�6�   �� 5+   
   -   5        $ 	labelDefi��5+      $��Défi��6#   $��Center=�62   
�������$��25(�6�   $��66��6�   $��Center=�6�   $��0��6�   $��2��6  �� 5-   
   -	   5        $ ParamEvenementImage��5-      $��22��6-   $��22��69   $��../Images/circle.png��6D   	 �	#FFACAC38$��	0,0,41,36q�6z   $��Right=�6�   $��Bottom=�6�    J� RenderTransformOrigin$ 6.516,6.536&�6Z  $��1��6~  $��2��6�  $y�Hidden=�6�   � ToolTip 5.      �� 5/      $��A propos��6   51      52      53      