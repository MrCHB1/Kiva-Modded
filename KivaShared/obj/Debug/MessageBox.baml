   M S B A M L   `   `   `  ����E  AKivaShared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:KivaShared
KivaShared  5   	       KivaShared.MessageBox   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:KivaShared     5   	   -   5        $��Regular"�5   	   $��16(�5	   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5
   	      TextRenderingMode$
 Auto=�5   	    � Title$ 
MessageBox��5   	   $	��100��63   $	��200��6C    � WindowStyle$
 None=�6R    � WindowStartupLocation$ CenterScreen=�6e   $��Center=�6�   $��Center=�6�   $��Stretch=�6�   $��Stretch=�6�    � SizeToContent$ WidthAndHeight=�6
   � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ButtonTemplates.xaml?�6%   %    5      '  !System.Windows.Shell.WindowChrome	   WindowChrome	 5        5   
   
   CaptionHeight
 6   �� *ActualHeight+ �� ElementName$ titlebar��.��5      � .+�5   
   ]� ��. .+�5      �� -   5         ��Name$ titlebar��5   �    K� ZIndex$ 1��6   ���#0068c9$	��Top=�6�   $��40��6�   y�6&   �� *ChromeVisibility+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 5Q�6'      ShadowDepth$ 0Q�66   ._�5      ]� .+�5      ]� $��Right=�6    $��0q�67   $��40��6B   .+�5      �� -   5        $��
ExitButton��5   Y      WindowButton#��[  6!   |�.  
���  ��$��20��6|   $��20��6�   $��3q�6�   $��Right=�6�      IsHitTestVisibleInChrome . 6�   5       � 5!      .+�5"      �� -   5        $��	titleText��5"   $   $
��10,0q�65   $��16(�6C   
�������$
��Left=�6d   $��Center=�6   5#      5$      5%      5&      � 5'      -   5        $��content��5'      ���#0179db.+�5(      �� -   5        $��bodyText��5(      $��16(�6,   
�������$��Center=�6M   $��Center=�6j   $��10q�6�   $
��Wrap=�6�   5)      5*      5+      5,      5-      