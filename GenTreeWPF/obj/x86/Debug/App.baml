   M S B A M L   `   `   `  ����E  AGenTreeWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GenTreeBE	GenTreeBE  5          GenTreeWPF.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      )localclr-namespace:GenTreeBE     5        �� 	Resources  5         GenTreeTemplate �� DataType   GenTreeBE.GenTree �� CornerRadius �� Padding  	helpStyle �� 
TargetType �� 	Resources  Key �� 
TargetType �� Triggers P� Property	 P� Value
 �� 
TargetName �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   Opacity   Color   	Direction   ShadowDepth  helpButtonTemplate��%  &	        &	 �     7  �� 5   
   "  6/   .R�5      �� $
��Base��6   
����  �$��1q�64   
�������$ 3��6[   $	  10q�6l   $��3q�6z   $	��100��6�   $��30��6�   ._�5	      �� $��20(�6   $��Medium"�6*   $��Name:��6>   5      5      �� 5   
   " ��6"    5      ���� 5      helpButtonTemplate " ��6>   .R�5      �� $��
helpBorder��6   
����  �$��3q�6C   
���  ��$ 5��6i   ._�5      �� #��z��6+   5       5      P� 5       �@J�IsMouseOver	 . . �5      �� $
 
helpBorder��6%    � ��$ 1q�6X   5      P� 5       �@��	ClickMode$	 Hover=�67   . �5      �� $
 
helpBorder��6%    � ��
 �  ��6S   �� 5      $
 
helpBorder��6%    �@��CornerRadius$ 10��6U   5      5      5      .�5      ��  � ��$ 45��6+   �� 5        � ��$ 45��6*   �� 5!       � ��$ Center=�6=   �� 5"       � ��$ Center=�6?   �� 5#       � �� 5$      �� 5%      $��images\help_button.jpg��6    $��30��6@   $��30��6K   5'      �� 5(       �@J�Effect 5)        5*      $ 5Q�6+   $ 35Q�6:   $ CornflowerBlue��6G   $	 300Q�6^   $ InfinityQ�6n   5,      �� 5-       � ��8   6-   5.      5;      5<      