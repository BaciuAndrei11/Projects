   M S B A M L   `   `   `  ����>  :Dex, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DexDex  5      clr-namespace:DexDex  5          
Dex.Search   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:Dex     5      !ctxclr-namespace:Dex     5        N� Title$  Search��5
      $	��800��6   $
��1000��6$    N� 
Background
 ����� � DataContext 5        Dex.WordsVM  5   
   .��5      � .+�5   
   �� -   5        $��listBox��5      $y�Hidden=�6!   $
��Left=�66   $	��130��6Q   $	��Top=�6^   $	��717��6v   $��245,136,0,0q�6�    �� DisplayMemberPath$
 Name��6�   �� 5   
   -   5        $��textBox��5      $
��Left=�6C   $��33��6^   $��245,103,0,0q�6j    �� TextWrapping$
 Wrap=�6   $�� ��6�   $	��Top=�6�   $	��717��6�   �� 5   
   -   5        $��category��5      $
��Left=�6"   $	��Top=�6=   $	��138��6U   $��102,109,0,0q�6a   �� 5   
   $
��Left=�6   $��49��6-   $
 Wrap=�69   $	��Top=�6�   $	��225��6�   $��434,325,0,0q�6�   ��6M   ��  �� ElementName$ listBox�� �� Path$ SelectedItem.Name�6�   �� 5   
   $
��Left=�6   $��97��6-   $
 Wrap=�69   $	��Top=�6�   $	��225��6�   $��434,411,0,0q�6�   ��6M   �� $ listBox��$ SelectedItem.Description�6�   �� 5   
   $
��Left=�6   $��49��6-   $
 Wrap=�69   $	��Top=�6�   $	��225��6�   $��434,533,0,0q�6�   ��6M   �� $ listBox��$ SelectedItem.Category�6�   �� 5   
   $��Word:��6   $��
UltraBlack"�6    $
��Left=�68   $��313,345,0,0q�6S   $	��Top=�6h   �� 5   
   $��Description:��6   $��
UltraBlack"�6'   $
��Left=�6?   $	��Top=�6Z   $��310,433,0,0q�6r   �� 5   
   $��	Category:��6   $��
UltraBlack"�6$   $
��Left=�6<   $	��Top=�6W   $��309,556,0,0q�6o    J� RenderTransformOrigin$ 0.497,1.844&�6�   �� 5   
   $��Image:��6   $��
UltraBlack"�6!   $
��Left=�69   $	��Top=�6T   $��308,653,0,0q�6l   $ 0.497,1.844&�6�   �� 5   
   $
��Left=�6Y   $	��130��6t   $	��Top=�6�   $	��212��6�   $��434,621,0,0q�6�   ��6   �� $ listBox��$  SelectedItem.ImageLocation�6�   �� 5   
   $��Search a word!��6   $
��Left=�6)   $	��Top=�6D   $��295,10,-155,0q�6\   $��88��6s   $	��860��6   $��	ExtraBold"�6�   $��50(�6�   5      5      