   M S B A M L   `   `   `  ����D  @CodeRuner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CodeRuner	CodeRuner  5   	       CodeRuner.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CodeRuner     5   	   ] YICSharpCode.AvalonEdit, Version=5.0.3.0, Culture=neutral, PublicKeyToken=9cc39be672370310;avalon.http://icsharpcode.net/sharpdevelop/avalonedit  5   	   X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4AbusyIndicatorEasy)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  
Code Runer��5
   	   $	��350��6   $	��525��6)    � Icon$ icon.ico��65    � 	Resources 5         Local_TextBox �� 
TargetType �� Property �� Value �� 
TargetType ��Name��%�   &	        �� 5   
   " ��6&   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $��Border��6!   #��z��6/   ._�5      �� $ PART_ContentHost��6+   5      5      5      5      5      .��5      � .+�5   
   �� .@�5      �� $
��CodN��6   .��5      � $��5,5,5,5q�6   ���	#FFE5E5E5 � RowDefinitions 5      �� 5      $
��208* �6(   �� 5      $
��101* �6(   .+�5       %  Xceed.Wpf.Toolkit.BusyIndicator  -   5        	  Name$	 MyBusyIndicator��5    6   
   BusyContent$
 Loading��5!   	   .��5"      '  !ICSharpCode.AvalonEdit.TextEditor  -   5          Name$ nevise��5"   -      ShowLineNumbers . $��	5,28,10,3q�6T      Text. 6|   . 5#   �   5$      5%      �� 5)      -   5         ��Name$ 
ErrorList1��5)      $��	5,2,10,20q�63   $��1��6F    �� View 5*      �� 5+      .P�5,   "   �� 5-      5/      c� 50      $��28��6   $	��Top=�6*   .@�51      �� -   5        $
��File��51   !   $	��Top=�60    � ContextMenu 52      �� 53   "   .@�54   &   m� -   5         m�Name$
 Open��54   /   $��_Open��6=   6L   m� 55   &   -   5        $
 Save��55   /   $��_Save��6=   6L   56   #   58      �� 59      -   5        $��Debug��59   !   $��Stretch=�61   $��0,0,0,1q�6b   �� 5:      -   5        $��
Save *.Exe��5:   !   66   �� 5;      -	   5        $��Convert��5;   !   63   5<      5=      5>      �� 5?      $��C#��6   .��5@      � $��5,5,5,5q�6   ���	#FFE5E5E5 5A      �� 5B      $��2* �6(   �� 5C      .+�5E        -
   5        $ CshapTextBox��5E   *    . $��	5,28,10,3q�6W   . 6   . 5F   �   5G      �� 5O      -   5         ��Name$ 	ErrorText��5O      $��	5,3,10,20q�61    �� TextWrapping$
 Wrap=�6D   $��1��6Y   "   CodeRuner.AttachedProperties   HasBindableLineCount .  �� AcceptsReturn . #��[  6�   6�   c� 5P      $��28��6   $	��Top=�6*   .@�5Q      �� -   5        $
��File��5Q   !   $	��Top=�60    5R      �� 5S   "   .@�5T   &   m� -   5        $ Open1��5T   /   $��_Open��6>   6M   m� 5U   &   -   5        $ Save1��5U   /   $��_Save��6>   6M   5V   #   5X      �� 5Y      -   5        $��Debug��5Y   !   61   �� 5Z      -   5        $��
Save *.Exe��5Z   !   66   5\      5]      5^      5_      5`      5a      