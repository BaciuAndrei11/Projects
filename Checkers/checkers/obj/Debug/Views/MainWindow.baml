   M S B A M L   `   `   `  ����C  ?checkers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:checkers.ViewModelscheckers.ViewModels  5   	       checkers.Views.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:checkers.ViewModels     5   	     � Title$  
MainWindow��5   	   $��852.8��6   $��999.4��6+    � WindowStartupLocation$ CenterScreen=�69    � DataContext 5	         checkers.ViewModels.GameVM  5
   
   .��5      � $
��Left=�6   $	��719��6&   $	��Top=�63   $	��904��6K   $��0,67,0,0q�6W   .+�5   
   �� -   5        $
��grid��5      $��Bottom=�6E   $	��670��6`   $��87,0,152.8,28.8q�6m   ��6#   �� *	GameBoard+��5      �� 5      .R�5      �� ��6#   �� ��5      �� 5      .R�5   "   ��  �� Orientation$ 
Horizontal=�6-   5      ��5      �� 5      .R�5   "   �� $��80��6)   $��80��64   $��2q�6@   ���#000000._�5   &   �� ��6-   �� *ClickCommand+��6O   �� *
SimpleCell+��5   *   �� 5   .   .R�5   2   �� $��UniformToFill=�6\   ��68   �� *SimpleCell.Image+6\   5   /   5   '   5    #   5!      5#      5$      5&      �� 5'   
   -   5        $��NewGame��5'   &   $
��Left=�68   $	��Top=�6S   $	��130��6k   $��31��6w   $��
87,-46,0,0q�6�    J� RenderTransformOrigin$ -2.929,-1.012&�6�   �� 5(   
   -   5        $��SaveGame��5(   (   $
��Left=�6;   $	��Top=�6V   $	��130��6n   $��31��6z   $��222,-46,0,0q�6�   �� 5)   
   -   5        $��LoadGame��5)   (   $
��Left=�6;   $	��Top=�6V   $	��130��6n   $��31��6z   $��357,-46,0,0q�6�   �� 5*   
   -   5        $��About��5*   (   $
��Left=�68   $	��Top=�6S   $��98��6k   $��31��6v   $��627,-46,0,0q�6�   �� 5+   
   -   5        $��
Statistics��5+   (   $
��Left=�6=   $	��Top=�6X   $	��130��6p   $��31��6|   $��492,-46,0,0q�6�   5,      5/      