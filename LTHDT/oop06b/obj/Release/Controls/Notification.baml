   M S B A M L   `   `   `  ���� A  =oop06b, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:De06B_Nhom02.ConvertersDe06B_Nhom02.Converters  (    "De06B_Nhom02.Controls.Notification   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <
Converters%clr-namespace:De06B_Nhom02.Converters     $	��100��$	��200��  � 	Resources  5   /De06B_Nhom02.Converters.BooleanToBrushConverter   BooleanToBrushConverter6   0De06B_Nhom02.Converters.BooleanToStatusConverter  BooleanToStatusConverter  ShowNoti �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value   EasingFunction.  (System.Windows.Media.Animation.CubicEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode R� KeyTime  System.Windows.Visibility   Visible	 R� Value
   	Collapsed  FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background 	 Button.Pressed.Border 
 Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground  ButtonStyle1 �� 
TargetType �� 
TargetType ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	      &	 
     &	 3    &	 �    &	 �    &	 �    &	 �    &	 �    &		 �    &	
 �    &	     &	 )    &	 >    7  7  7  7  7  7  7 	 7 
 7  7      �� .��U� $ (UIElement.Opacity)�$
 grid��.\�  $ 0��$ 0Q�   $ EaseIn=�  $ 0:0:0.7��$ 1Q�   $ EaseIn=�  $ 0:0:9.5��$ 1Q�  $ 0:0:10��$ 0Q�T� $ (UIElement.Visibility)�$
 grid��..�i� $ 0:0:0.7��#	 Z i� $ 0:0:10��#	 Z
 �� .���  � �� �� .R��� $��2q� . #��� ��$��1��$	 1 2R��� $ 	#FFDDDDDD���� $ 	#FF707070���� $ 	#FFBEE6FD���� $ 	#FF3C7FB1���� $ 	#FFC4E5F6���� $ 	#FF2C628B���� $ 	#FFF4F4F4���� $ 	#FFADB2B5���� $ 	#FF838383���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��#��z��#��z��#��z�� . ._��� $ contentPresenter��|�.  #��z��#��z����. # z #��z�� P�  �@��IsDefaulted . . ��� $ border��# � �� � ��P�  �@J�IsMouseOver . . ��� $ border��8   � ���� $ border��8   � ��P�  � �� . . ��� $ border��8   � ���� $ border��8   � ��P�  � {� .  . ��� $ border��8   � ���� $ border��8   � ���� $ contentPresenter��8 	  � �� � Triggers :�  :� RoutedEvent$ FrameworkElement.Loaded��.[��� #��[ .��� -    �Name$
 grid������ *	IsSuccess+ �� 	Converter# [   �� Mode$ OneWay=�.+��� $
��10,0q�.+��� 
�������$��20(�$��SemiBold"�$��10,0,0,0q����� *
ThreadId+ �� StringFormat$ Thread {0}:���� $
��Wrap=�
��������� $�From [�� �� ��� *	Start.X+ �� $�,�� �� ��� *	Start.Y+ �� $�] to [�� �� ��� *Goal.X+ �� $�,�� �� ��� *Goal.Y+ �� $�]���� $
��Wrap=�
����������� *
Distance+$ OneWay=�$ Distance: {0}���� $
��Wrap=�
����������� *	VisitedNo+$ Visited Nodes: {0}���� $
��Wrap=�
����������� *Time+$ 
Time: {0}s���� $��Button��$��Right=�$	��Top=�$��75��#���  $y�	Collapsed=�