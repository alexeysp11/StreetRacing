   M S B A M L   `   `   `  ����G  CStreetRacing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:StreetRacing.ViewStreetRacing.View  5   	   ?$clr-namespace:StreetRacing.ViewModelStreetRacing.ViewModel  5   	   "    StreetRacing.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:StreetRacing.View     5   	   3vm$clr-namespace:StreetRacing.ViewModel     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ 
MainWindow��5
   	    � WindowState$ 	Maximized=�5   	    � WindowStyle$
 None=�5   	    J� InputBindings 5      �� 5   
    �� CommandParameter$ Increase��6L   
 �� Key$ W��6h    �� Command 6   �� *$"SpeedometerVM.RegulateSpeedCommand+6h   �� 5   
   $ Decrease��6L   $ S��6h    6   �� *$"SpeedometerVM.RegulateSpeedCommand+6h   �� 5   
   $
 Left��6T   $ A��6l    6   �� *,*SteeringWheelVM.RotateSteeringWheelCommand+6l   �� 5   
   $ Right��6T   $ D��6m    6   �� *,*SteeringWheelVM.RotateSteeringWheelCommand+6m   .��5      � .+�5   
   �� -   5        $��
MainCanvas��5      .+�5      �� -   5        $��SpeedometerArrow��5      $��2��6+   
���  ��6?   F� 5      -   5        $��SpeedometerArc��5      
���   �6)   5      5      5      