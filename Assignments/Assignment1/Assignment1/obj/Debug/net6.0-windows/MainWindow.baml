   M S B A M L   `   `   `  ����F  BAssignment1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Assignment1Assignment1  5   	       Assignment1.MainWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Assignment1     5   	     � Title$  Mark Moulton's MP3 Player��5   	   $	��266��6+   $	��489��68    J� CommandBindings 5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5           Command$ ApplicationCommands.Open��5
      6Y     5   
   -   5        $$ ApplicationCommands.Properties��5      6_     5   
   -   5        $ MediaCommands.Play��5      6S     5   
   -   5        $ MediaCommands.Pause��5      6U     5   
   -   5        $ MediaCommands.Stop��5      6S   .��5      � .+�5   
   r� -   5         r�Name$ myMedia��5       r� LoadedBehavior$ Manual=�6(   �� 5   
    �� Orientation$ 
Horizontal=�6   $��15q�6.   .+�5      ]� $��15q�6   .+�5      �� $	��Top=�6   $��ApplicationCommands.Open��6.   .��6Q   	Load File6\   �� 5      $��Bottom=�6   $$��ApplicationCommands.Properties��64   .��6]   Save Current File6p   5      �� 5      $ 
Horizontal=�6   .+�5      �� .+�5      �� .@�5      �� .��5      �� -   5         ��Name$ mySlider��5   %   $��20��67   $	��200��6C   $��Center=�6P   $��15q�6m   6�   5      �� 5       .��5!      �� -   5         ��Name$ myTimer��5!   (   $��Center=�69   	0:00:006_   5"      5#      �� 5$      $ 
Horizontal=�6!   $��15q�6:   $	��185��6F   .+�5%      �� -	   5         ��Name$
 Play��5%   !   $
��Play��6/   $��MediaCommands.Play��6>   $��20��6[   $��60��6g   �� 5&      -
   5        $ Pause��5&   !   $��Pause��60   $��MediaCommands.Pause��6@   $��20��6^   $��60��6j   �� 5'      -   5        $
 Stop��5'   !   $
��Stop��6/   $��MediaCommands.Stop��6>   $��20��6[   $��60��6g   5(      5*      5,      5/         Assignment1.ViewMetaData  50   
   -   5        	  Name$	 myMeta��50      $��Center=�6.   $��Bottom=�6K   52      55      