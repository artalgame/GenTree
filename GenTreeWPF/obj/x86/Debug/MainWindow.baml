   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   E AGenTreeWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GenTreeBE	GenTreeBE 5   	      GenTreeWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   +genTrBEclr-namespace:GenTreeBE     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   @   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6}   -   5        $��Main_Window��5        � Title$  
MainWindow��6	    � 
ResizeMode$ 	CanResize=�6�    � WindowStartupLocation$ CenterScreen=�6�    � WindowStyle$ SingleBorderWindow=�6   � SizeToContent$ Manual=�6=   � Topmost .  $��Stretch=�6�  $��Stretch=�6�   � ForceCursor .   � Cursor$
 Hand��6�  $	��700��6�  $	��400��6   � 	Resources 5      ��%    5
      ��5      �� 5   
   	 �� EndPoint$	 1,0.5&�6   
 �� 
StartPoint$
 0,0.5&�6/   .��5      �  � Color$ 	#FF672FE5��6    � Offset$ 0Q�6-   � 5      $ 	#5A26E5E5��6   $ 1Q�6-   � 5      $ 	#D7D2FCD5��6   $ 0.516Q�6-   5      .��5      � -   5        $��grid1��5      $
��Auto��6   $
��Auto��6'   $��Stretch=�6L   $��Stretch=�6j    � DataContext 64   ��  � RowDefinitions 5   
   �� 5      $	��69* �6   �� 5      $��0* �6   �� 5      $	��49* �6   �� 5      $	��45* �6   �� 5      $��0* �6   �� 5      $	��80* �6   �� 5      $	��24* �6   �� 5      $	��49* �6   �� 5      $	��45* �6    � ColumnDefinitions 5    
   �� 5!      $
��192* �6   �� 5"      $	��69* �6   �� 5#      $��0* �6   �� 5$      $	��18* �6   �� 5%      $	��53* �6   �� 5&      $��0* �6   �� 5'      $
��269* �6   �� 5(      $	��61* �6   �� 5)      $	��15* �6   .+�5+   
   �� -   5        $��ProductNameLabel��5+   `   $��GenTree��6   $��58��6"   $��Stretch=�6.   $��
24,15,24,0q�6L   $��Stretch=�6x   $	��214��6�   $
��Bold"�6�   $��25(�6�   $	��Rod)�6�   $��	Condensed&�6�   $��Normal$�6�   $��2��6  $��3��6#   �� Target 6�   �� ��5,      �� 5-      5/      �� 50   
   -   5        $��
HelpButton��50   D      	helpStyle#��[  6   $��7��64   $��Stretch=�6V   $��5,12,0,0q�6r   $��40��6�    �� 	ClickMode$ Release=�6�   �� 51   
   -   5        $��
ExitButton��51   {   $
��Exit��6   $��7��6    $��7��60   $
��Auto��6=   $��Stretch=�6K   $��4,9,8,13q�6i   $��Stretch=�6�   $
��Auto��6�    �� IsCancel . $ Release=�6�   �� 52   
   -   5        $��SelectTreeButton��52   �   $��Select this tree��6   $��6��6,   $��7��6<   $
��Auto��6I   $��Stretch=�6W   $��26,10,52,14q�6u   $��Stretch=�6�   $
��Auto��6�   6�   �� 53   
   -   5        $��ListOfCrTreeLabel��53   f   $��List of Created Tree��6   $��6��6/   $��23��6?   $
��Left=�6K   $��Bottom=�6   $	��185��6�   $��	16,0,0,10q�6�   �� 54   
   -   5        $��SelectedTreeLabel��54   x   $��No selected tree��6   $��6��6+   $��6��6;   $��Stretch=�6H   $��0,0,0,48q�6f   $��Stretch=�6�   $��2��6�   �� 55   
   -	   5        $��CreateTreeButton��56      $��Create new TREE��55      $��7��6+   $��Stretch=�68   $��68,10,68,12q�6V   $��Stretch=�56   )   $	��125��6E   $��2��6p    � ToolTip 57      �� 58      !Press to create new Family Tree5:      5<      �� 5=   
   -
   5        $��label5��5=   W   $��3��6   $	��113��6   $
��Left=�6*   $��-6,0,0,0q�6E   $	��Top=�6e   $	��146��6}   $��3��6�   ��6�   Z� 5?      �� 5@   
   -   5        $��border1��5@   U   $��5q�6   $��Stretch=�6%   $��5,0,68,5q�6C   $��Stretch=�6d    J� OpacityMask
 �   � �� CornerRadius$ 10��6�   $��2��6�   $��4��6�   $��2��6�   ��5A      �� 5B      $	 1,0.5&�6*   $
 0,0.5&�6;   .��5C      � $ 	#FF6BC759��6'   $ 0Q�69   � 5D      $ 	#FF36CE1A��6'   $ 1Q�69   5E      ._�5G      �� -   5        $��Welcome��5G   ]   $��5��6   $
��Auto��6)   $
��Left=�67   $��0q�6R   $����Welcome to GenTree. Only few easy steps and our family tree will created. If you have created tree you can open and edit it(select it on table on right ), else - press Create new TREE below��5H      $	��Top=�6�   $
��Auto��6�   $��WrapWithOverflow=�6  $��LeftToRight=�6&  ���	#FF461FC7$
��Andy)�6Y  $��16(�6k   �� Padding$ 0q�6y  $
��None=�6�  $��ExtraExpanded&�6�   �� TextEffects 6�  z� ��6�  �� 6	  64  ��5I      �� 5J      $	 1,0.5&�6*   $
 0,0.5&�6;   .��5K      � $ 	#FF69C159��6'   $ 0Q�69   � 5L      $ 	#FF28DE44��6'   $ 1Q�69   5M      5O      &   System.Windows.Controls.DataGrid  5Q   
   -   5        $��CrTreesDataGrid��5Q   �    �� AlternationCount$ 2��6      AutoGenerateColumns .  $��4��6E   $��4��6U   $��Stretch=�6f   $��Stretch=�6�      SelectionMode$ Single=�6     SelectionUnit$ FullRow=�6     AreRowDetailsFrozen .    
IsReadOnly .    CanUserSortColumns .  $��4��6�  $��18,5,0,0q�6�  $��2��6�  ��6�   �� $ �� IsSynchronizedWithCurrentItem 6�  Z�  6�  �� 5S      �� 5T   
   -   5        $��listBox1��5T   v   $��4��6   $��4��6"   $��4��66   $��Stretch=�6G   $��1,0,0,0q�6e   $��Stretch=�6�   $��2��6�   $	��200��6�     �� SelectionMode$  Single=�6�   ��5U      �� 5V      ! �� DataType  GenTreeBE.GenTree"!  6   .R�5W      �� $
��Base��6   
����  �$��1q�6<   
�������$ 3��6c   " �� Padding$"  1q�6t   $��3q�6�   $
��Auto��6�   ��6�   �� *ActualWidth+# �� RelativeSource# �� $ �� Mode$$ FindAncestor=�% �� AncestorType"% ��._�5X      � $
��Auto��6    $
��Auto��6.   $��Stretch=�6S   $��Stretch=�6q    6;   ��  5Y      �� 5Z   "   $��3* �60   �� 5[   "   $��1* �60    5]      �� 5^   "   $��1* �63   �� 5_   "   $��4* �63   .+�5a      �� $��20(�6(   $��Medium"�66   $��Name:��6J   $��0��6W   $��0��6g   $��1��6t   $��Stretch=�6�   �� 5b      $��20(�6(   $��Medium"�66   $��1��6`   $��0��6p   $��2��6}   $��Stretch=�6�   ��6J   �� *Name+6�   �� 5c      $��9(�6(   $��Medium"�65   $��Create:��6I   $��0��6X   $��1��6h   $��1��6u   $��Stretch=�6�   �� 5d      $��9(�6(   $��Medium"�65   $��1��6g   $��1��6w   $��1��6�   $��Stretch=�6�   ��6I   �� *DateOfCreate+6�   5e      5f      5g      5i      5j      5k      