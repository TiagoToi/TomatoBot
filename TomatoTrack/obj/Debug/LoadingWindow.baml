   M S B A M L   `   `   `  ����  TomatoTrack    TomatoTrack.LoadingWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Analisando Lote��5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������ $	��400��5   	   $	��250��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � 
ResizeMode$ NoResize=�5   	    � Topmost .  � Icon$ logo.ico��5   	   .��5      �� 
������� �� CornerRadius$ 20��5      
�������$��2q�5       �� Padding$ 5q�5      	 J� SnapsToDevicePixels	 . ._�5   
   �� 
�������$ 15��5      
�������$��1q�5      $ 30q�5      $��10,10,10,10q�5      ._�5      � 
 � RowDefinitions
 5       �� 5!      $
��Auto �6$   �� 5"      $��* �6$   .+�5%      �� $#��Analisando imagens do lote...��6   $��22(�5&      $��SemiBold"�5'      
���OO/�$��Center=�5)      $��0,0,0,20q�5*      �� 5,      $��1��6    �� Orientation$ 
Horizontal=�6*   $��Center=�6C   .+�5-      A� $��20��6   $��20��6)   
���Gc�� � Triggers 5.      :� 5/       :� RoutedEvent$ Loaded��6+   .[�50   "   �� .��51   &   ��  g� RepeatBehavior$ Forever��61   .��52   *   W�  �� TargetProperty$ Opacity�6:    W� From$ 1X�6^   	 W� To$	 0.2X�6g    g� Duration$ 0:0:0.6D�53   :    g� AutoReverse . 6M   54   '   55   #   56      58      A� 5:      $��20��6   $��20��6)   
���Gc�� 5;      :� 5<      $ Loaded��6+   .[�5=   "   �� .��5>   &   �� $ Forever��61   .��5?   *   W� $ Opacity�6:   $	 0.2X�6^   $ 1X�6i   $ 0:0:0.6D�5@   :    .  g� 	BeginTime$ 0:0:0.2X�6`   5A   '   5B   #   5C      5E      A� 5G      $��20��6   $��20��6)   
���Gc�� 5H      :� 5I      $ Loaded��6+   .[�5J   "   �� .��5K   &   �� $ Forever��61   .��5L   *   W� $ Opacity�6:   $	 0.2X�6^   $ 1X�6i   $ 0:0:0.6D�5M   :    . $ 0:0:0.4X�6`   5N   '   5O   #   5P      5R      5S      5T      5U      5V      5W      