   M S B A M L   `   `   `  ���� [  WExaminationsuppgift-VG-Nivå-WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Examinationsuppgift_VG_Nivå_WPF Examinationsuppgift_VG_Nivå_WPF  e7clr-namespace:Examinationsuppgift_G_Nivå_Console.Model)Examinationsuppgift_G_Nivå_Console.Model  1    +Examinationsuppgift_VG_Nivå_WPF.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @local.clr-namespace:Examinationsuppgift_VG_Nivå_WPF     IModel7clr-namespace:Examinationsuppgift_G_Nivå_Console.Model       � Title$  
MainWindow��$	��916��$
��1422��$��Stretch=�$
��1422��$	��916������  �� ImageSource$ /thumb-1920-550274.jpg��.��� $��	0,0,10,-6q�$
��Auto��$
��Auto��.+��� $	��112��$��	-9,0,-9,0q�$	��Top=�#��� ���� $��HAMNEN��$��0,18,0,0q�$	��Top=�$��Bahnschrift)�$��72(�
�������$
��Auto��$��Medium&�$��Center=�$��5,5,0,5q�#��� ��� $��594,127,10,47q� � Orientation$ 
Horizontal=�.+��� -    ��Name$ Inställningar��$��Inställningar��$	��256��$	��150��$��18(�$��Bahnschrift)�$
��Bold"�$��Italic$����	#FFBFCDDB.���� 
�������.+��� $��Välj antal inkommande��$��12(�$��Center=��� -    ��Name$ MySlider��$	��120��$��18�� � Maximum$ 50Q� � Minimum$ 5Q�$��0,5,0,0q� � SmallChange$ 1Q� �� IsSnapToTickEnabled$
 True���� -   	 ��Name$	 SlideNumber��$��5��$
��Wrap=�$��Center=�$��14(�$��Normal$�� $��50��$ Vertical=�$��Stretch=�.+��� -   
 ��Name$
 RowBoatRadio��$��Roddbåt��$��12(� J� RenderTransformOrigin$ 0.486,0.565&� d� 	IsChecked$
 TrueY�$��3,3,3,3q��� -   $
 MotorBoatRadio��$��	Motorbåt��$��12(�$
 TrueY�$��3,3,3,3q��� -   $
 SailBoatRadio��$��	Segelbåt��$��12(�$
 TrueY�$��3,3,3,3q��� -   $
 CargoChipRadio��$��
Lastfartyg��$��12(�$
 TrueY�$��3,3,3,3q��� -   $
 CatamaranRadio��$��	Katamaran��$��12(�$
 TrueY�$��3,3,3,3q��� -	   $ Antal_Båtar��$��Antal Båtar��$��Stretch=�$��Stretch=�$	��256��$	��150��$��18(�$��Normal&�$��Italic$�$
��Bold"�$��Bahnschrift)�#��� ��.���� -
    ��Name$ ListBoxAntalBåtar��$��12(�$��Normal$�$��Normal"�$	��244��$	��245��$	��115���� -   $ Övrigt��$��Övrigt��$	��256��$	��150��$��18(�$��Bahnschrift)�$
��Bold"�$��Italic$�#��� ��.���� -   $ ListBoxÖvrigt��$��Normal"�$��Normal$�$��12(�$	��244��$	��245��$	��115��� $	��784��$	��572��.+��� -   $ Inchecknigar��$��Dagens Incheckningar��$	��256��$	��150��$��18(�$��Bahnschrift)�$
��Bold"�$��Italic$�#��� ��.���� -   $ 	ListBoxIn��$��12(�$��Normal"�$��Normal$�$	��245��$	��115���� -   $ Utcheckningar��$��Dagens Utcheckningar��$	��150��$	��256��$��Bahnschrift)�$��18(�$
��Bold"�$��Italic$�#��� ��.���� -   $ 	ListBoxUt��$��Normal"�$��Normal$�$��12(�$	��245��$	��115���� -   $ Avvisade��$��Dagens Avvisade��$	��256��$	��127��$��18(�$��Bahnschrift)�$��Italic$�$
��Bold"�#��� ��.���� -   $ 	ListBoxAv��$��12(�$��Normal"�$��Normal$�$	��244��$	��245��$	��115���� -   $ 	KörenDag��$��Kör en dag��$	��150��$	��256��$��Bahnschrift)�$��18(�$
��Bold"�$��Italic$�#��� ��$��1,0,1,0q�.���� 
�������.+��� -   $
��Kör���� -    ��Name$ KörDagLabel��$	��Dag��$��Center=�$��	0,35,0,10q��� -   $ Körenvecka��$��Kör en vecka��$	��150��$	��256��$��Bahnschrift)�$��18(�$
��Bold"�$��Italic$�#��� ��.���� 
�������.+��� -    ��Name$ 	KörVecka��$
��Kör���� -   $ körVeckaLable��$	��Dag��$��Center=�$��	0,35,0,10q���  �� Orientation$ 
Horizontal=�$��10,127,840,145q�$	��555��$
��Left=�.+��� -   $" Kajplats_1_Alla_Ankarplatser��$��
Kajplats 1��$��Stretch=�$��Stretch=�$	��250��$	��250��$��
15,0,10,10q�$��24(�$
��Bold"�$��Italic$�$��Bahnschrift)�#��� ��.��R� -    R�Name$ MyTreeViewFirst��
�������$��1,1,1,1q�$��Normal$�$��Normal"�$��12(�$	��238��$	��530���� -   $" Kajplats_2_Alla_Ankarplatser��$��
Kajplats 2��$��Stretch=�$��Stretch=�$	��250��$	��250��$��
10,0,15,10q�$��24(�$��Bahnschrift)�$
��Bold"�$��Italic$�#��� ��.��R� -   $ MyTreeViewSecond��
�������$��Normal$�$��Normal"�$��12(�$	��238��$	��530��