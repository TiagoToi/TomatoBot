   M S B A M L   `   `   `  ����  TomatoTrack&     TomatoTrack.ResultadoAnalisePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $��Stretch=�5      $��Stretch=�5	      
�������.��5      � $��60q�6   $��Center=�6     � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Resultado da Análise��6   $��40(�5      $��SemiBold"�5      ���#2E7D32$��0 0 0 40q�5      � 5   
   $��1��6   $��0 0 0 30q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5#      �� $��0��6   .+�5$      �� $��Data e Hora do Lote:��6   $��20(�68   $
��Bold"�6F   �� 5%      -   5         ��Name$ txtDataHora��5%      $��18(�61   $��0,5,0,15q�6?   �� 5'      $��Maduros Detectados:��6   $��20(�67   $
��Bold"�6E   �� 5(      -   5        $ txtQntMaduros��5(      $��18(�63   $��0,5,0,15q�6A   �� 5*      $��Verdes Detectados:��6   $��20(�66   $
��Bold"�6D   �� 5+      -   5        $ txtQntVerdes��5+      $��18(�62   $��0,5,0,15q�6@   �� 5-      $��Número de Imagens:��6   $��20(�66   $
��Bold"�6D   �� 5.      -   5        $ txtNumImagens��5.      $��18(�63   $��0,5,0,15q�6A   5/      �� 52      $��1��6   .+�53      �� $��Total de Tomates:��6   $��20(�65   $
��Bold"�6C   �� 54      -   5        $ txtTotalTomates��54      $��18(�65   $��0,5,0,15q�6C   �� 56      $��Média Score Maduros:��6   $��20(�68   $
��Bold"�6F   �� 57      -   5        $ txtMediaScoreMaduros��57      $��18(�6:   $��0,5,0,15q�6H   �� 59      $��Média Score Verdes:��6   $��20(�67   $
��Bold"�6E   �� 5:      -   5        $ txtMediaScoreVerdes��5:      $��18(�69   $��0,5,0,15q�6G   �� 5<      -   5         ��Name$ 
verImagens��5<      $$��Visualizar Imagens Processadas��6-   $��3��6V   $	��190��6c   $��40��6o   $��0 20 0 0q�6{   
����İ�$��DemiBold"�6�   $
��Left=�6�   6�   5=      5>      �� 5A   
   $��4��6    �� Orientation$ 
Horizontal=�5B      $��Center=�5C      $��0 50 0 0q�5D      .+�5F      �� -	   5        $��
← Voltar��5F      $	��180��5G      $��50��6%   $��18(�5H      ���#E0F2F1���#004D40���#B2DFDB$��2q�5L      $��0 0 40 0q�5M       � Cursor$
 Hand��5N       J� Effect 5P      3  -System.Windows.Media.Effects.DropShadowEffect  5Q         ShadowDepth$ 2Q�6'      
BlurRadius$ 5Q�67   	   Opacity$		 0.3Q�6F   5S      �� 5U      -
   5        $ 	btnSalvar��5]      $��💾 Salvar Lote��5U      $	��200��5V      $��50��6%   $��18(�5W      ���#66BB6A
�������$��0q�5Z      $
 Hand��5[       5^        5_      $ 2Q�6'   $ 6Q�67   $		 0.4Q�6F   5a      5b      5c      5d      