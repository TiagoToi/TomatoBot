   M S B A M L   `   `   `  ����   TomatoTrack    TomatoTrack.LoadingWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Analisando Lote�� � WindowStyle$
 None=� � AllowsTransparency . 
������ $	��400��$	��250�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � Topmost .  � Icon$ logo.ico��.���� 
������� �� CornerRadius$ 20��
�������$��2q� �� Padding$ 5q�	 J� SnapsToDevicePixels	 . ._��� 
�������$ 15��
�������$��1q�$ 30q�$��10,10,10,10q�._�� 
 � RowDefinitions
 �� $
��Auto ��� $��* �.+��� $#��Analisando imagens do lote...��$��22(�$��SemiBold"�
���OO/�$��Center=�$��0,0,0,20q��� $��1�� �� Orientation$ 
Horizontal=�$��Center=�.+�A� $��20��$��20��
���Gc�� � Triggers :�  :� RoutedEvent$ Loaded��.[��� .����  g� RepeatBehavior$ Forever��.��W�  �� TargetProperty$ Opacity� W� From$ 1X�	 W� To$	 0.2X� g� Duration$ 0:0:0.6D� g� AutoReverse . A� $��20��$��20��
���Gc�� :� $ Loaded��.[��� .���� $ Forever��.��W� $ Opacity�$	 0.2X�$ 1X�$ 0:0:0.6D� .  g� 	BeginTime$ 0:0:0.2X�A� $��20��$��20��
���Gc�� :� $ Loaded��.[��� .���� $ Forever��.��W� $ Opacity�$	 0.2X�$ 1X�$ 0:0:0.6D� . $ 0:0:0.4X�