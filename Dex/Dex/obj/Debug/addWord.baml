   M S B A M L   `   `   `  ����>  :Dex, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DexDex  5      clr-namespace:DexDex  5          Dex.addWord   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:Dex     5      !ctxclr-namespace:Dex     5        N� Title$  addWord��5
      $	��800��6   $
��1000��6$    N� 
Background
 ����� � DataContext 5        Dex.WordsVM  5   
   .��5      � .+�5   
   �� -   5         ��Name$
 word��5      $
��Left=�6    $��23��6;    �� TextWrapping$
 Wrap=�6G   $	��Top=�6�   $	��120��6�   $��
134,57,0,0q�6�   ��6[   ��  �� ElementName$ listBox�� �� Path$ SelectedItem.Name�6�   �� 5   
   $��Word:��6   $��
UltraBlack"�6    $
��Left=�68   $��	26,55,0,0q�6S   $	��Top=�6f   �� 5   
   -   5        $��description��5   .   $
��Left=�6   $	��144��6A   $��
134,95,0,0q�6N   $
 Wrap=�6b   $	��Top=�6�   $	��473��6�   ��6v   �� $ listBox��$ SelectedItem.Description�6�   �� 5   
   $��Description:��6   $��
UltraBlack"�6'   $
��Left=�6?   $	��Top=�6Z   $��
23,143,0,0q�6r   �� 5   
   -   5        $��category��5       �� 
IsEditable . $
��Left=�6x   $	��Top=�6�   $	��138��6�   $��134,269,0,0q�6�    �� Text 6#   �� $ listBox��$ SelectedItem.Category���6�   �� *	Categorys+�� 5   
   $��	Category:��6   $��
UltraBlack"�6$   $
��Left=�6<   $	��Top=�6W   $��
22,266,0,0q�6o   	 J� RenderTransformOrigin$	 0.497,1.844&�6�   �� 5   
   -   5        $��Add word��5      
�������$��
UltraBlack"�6>   $
��Left=�6V   $	��Top=�6q   $��91��6�   $��
23,577,0,0q�6�   6�   �� 5   
   -   5        $��Delete Word��5      
�������$��
UltraBlack"�6X   $
��Left=�6p   $	��Top=�6�   $��91��6�   $��134,577,0,0q�6�   �� 5   
   -   5        $��Modify Word��5      
�������$��
UltraBlack"�6X   $
��Left=�6p   $	��Top=�6�   $��91��6�   $��245,577,0,0q�6�   �� 5   
   -   5        $��listBox��5      $
��Left=�6!   $	��130��6<   $	��Top=�6I   $	��934��6a   $��
22,621,0,0q�6m   
 �� DisplayMemberPath$

 Name��6�   ��6�   �� *Words+6�   �� 5   
   $
��Left=�6   $	��160��6+   $��
98,322,0,0q�68   $	��Top=�6L   $	��156��6d   $	 0.683,0.468&�6�   ��6p   �� $ imageLocation��$
 Text�6�   �� 5   
   -   5        $��imageLocation��5      $
��Left=�6o   $��37��6�   $
 Wrap=�6�   $	��Top=�6�   $	��155��6�   $��
26,508,0,0q�6�   ��6'   �� $ listBox��$  SelectedItem.ImageLocation�6�   �� 5   
   -	   5        $��Search Image��5      
�������$��
UltraBlack"�6Y   $
��Left=�6q   $	��Top=�6�   $	��124��6�   $��212,508,0,0q�6�   $��37��6�   5      5      