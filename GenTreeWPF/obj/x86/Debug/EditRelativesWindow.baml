   M S B A M L   `   `   `  ����  
GenTreeWPF$    GenTreeWPF.EditRelativesWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  EditRelativesWindow��5   	   $	��300��6%   $	��300��62   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��15* �6   �� 5      $	��91* �6   �� 5	      $
��158* �6   �� 5
      $	��14* �6    � RowDefinitions 5   
   �� 5      $	��22* �6   �� 5      $	��12* �6   �� 5      $
��227* �6   .+�5   
   �� -   5        $��TitleTextBlock��5   M   $��23��6   $
��Left=�6    $��0,-1,0,0q�6;   $��Relations editor��6c   $	��Top=�6{   $	��106��6�   $��2��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��RelationTableDataGrid��5   x      AutoGenerateColumns .  $��2��6/   $��2��6C   $	��157��6P   $
��Left=�6]   $	��Top=�6�   $	��249��6�   $��1��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ First Person��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *FirstPerson.NameOfPerson+  5      $ Relative��6%    67   �� *	Relations+  5      $ Second Person��6%    6<   �� *SecondPerson.NameOfPerson+5      �� 5   
   -   5        $��RelationComboBox��5   ~   $��1��6   $��2��6#   $��2��67   $��23��6D   $
��Left=�6P   $��	0,177,0,0q�6k   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -   5        $��SaveRelationButton��5   �   $��Save Relation��6   $��2��6)   $��2��69   $��23��6F   $
��Left=�6R   $��
60,177,0,0q�6m   $	��Top=�6�   $��98��6�   6�   5      5      