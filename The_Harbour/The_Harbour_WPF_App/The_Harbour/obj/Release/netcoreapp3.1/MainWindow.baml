   M S B A M L   `   `   `  ���� F  BThe_Harbour, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:The_HarbourThe_Harbour  5clr-namespace:The_Harbour.ModelThe_Harbour.Model      The_Harbour.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:The_Harbour     1Modelclr-namespace:The_Harbour.Model       � Title$  
MainWindow��$	��916��$
��1422��$��Stretch=�$
��1422��$	��916������  �� ImageSource$ /background.jpg��.��� $��	0,0,10,-6q�$
��Auto��$
��Auto��.+��� $	��112��$��	-9,0,-9,0q�$	��Top=�#��� ���� $��THE HARBOUR��$��	0,18,-9,0q�$	��Top=�$��Bahnschrift)�$��72(�
�������$
��Auto��$��Medium&�$��Center=�$��5,5,0,5q�#��� ��� $��594,127,10,47q� � Orientation$ 
Horizontal=�.+��� -    ��Name$ Inställningar��$��Settings��$	��256��$	��150��$��18(�$��Bahnschrift)�$
��Bold"�$��Italic$����	#FFBFCDDB.���� 
�������.+��� $%��Select number of incoming boats��$��12(�$��Center=��� -    ��Name$ MySlider��$	��120��$��18�� � Maximum$ 50Q� � Minimum$ 5Q�$��0,5,0,0q� � SmallChange$ 1Q� �� IsSnapToTickEnabled$
 True���� -   	 ��Name$	 SlideNumber��$��5��$
��Wrap=�$��Center=�$��14(�$��Normal$�� $��50��$ Vertical=�$��Stretch=�.+��� -   
 ��Name$
 RowBoatRadio��$��Rowing boat��$��12(� J� RenderTransformOrigin$ 0.486,0.565&� d� 	IsChecked$
 TrueY�$��3,3,3,3q��� -   $
 MotorBoatRadio��$��	Powerboat��$��12(�$
 TrueY�$��3,3,3,3q��� -   $
 SailBoatRadio��$��Sailboat��$��12(�$
 TrueY�$��3,3,3,3q��� -   $
 CargoChipRadio��$��
Cargo ship��$��12(�$
 TrueY�$��3,3,3,3q��� -   $
 CatamaranRadio��$��	Catamaran��$��12(�$
 TrueY�$��3,3,3,3q��� -	   $ Antal_Båtar��$��Number of boats��$��Stretch=�$��Stretch=�$	��256��$	��150��$��18(�$��Normal&�$��Italic$�$
��Bold"�$��Bahnschrift)�#��� ��.���� -
    ��Name$ ListBoxAntalBåtar��$��12(�$��Normal$�$��Normal"�$	��244��$	��245��$	��115���� -   $ Övrigt��$��Other��$	��256��$	��150��$��18(�$��Bahnschrift)�$
��Bold"�$��Italic$�#��� ��.���� -   $ ListBoxÖvrigt��$��Normal"�$��Normal$�$��12(�$	��244��$	��245��$	��115��� $	��784��$	��572��.+��� -   $ Inchecknigar��$��Today's Check-ins��$	��256��$	��150��$��18(�$��Bahnschrift)�$
��Bold"�$��Italic$�#��� ��.���� -   $ 	ListBoxIn��$��12(�$��Normal"�$��Normal$�$	��245��$	��115���� -   $ Utcheckningar��$��Today's Checkouts��$	��150��$	��256��$��Bahnschrift)�$��18(�$
��Bold"�$��Italic$�#��� ��.���� -   $ 	ListBoxUt��$��Normal"�$��Normal$�$��12(�$	��245��$	��115���� -   $ Avvisade��$��Today's Rejected��$	��256��$	��127��$��18(�$��Bahnschrift)�$��Italic$�$
��Bold"�#��� ��.���� -   $ 	ListBoxAv��$��12(�$��Normal"�$��Normal$�$	��244��$	��245��$	��115���� -   $ 	KörenDag��$��Run one day��$	��150��$	��256��$��Bahnschrift)�$��18(�$
��Bold"�$��Italic$�#��� ��$��1,0,1,0q�.���� 
�������.+��� -   $	��Run���� -    ��Name$ KörDagLabel��$	��Day��$��Center=�$��	0,35,0,10q��� -   $ Körenvecka��$��Run one week��$	��150��$	��256��$��Bahnschrift)�$��18(�$
��Bold"�$��Italic$�#��� ��.���� 
�������.+��� -    ��Name$ 	KörVecka��$	��Run���� -   $ körVeckaLable��$	��Day��$��Center=�$��	0,35,0,10q���  �� Orientation$ 
Horizontal=�$��10,127,840,145q�$	��555��$
��Left=�.+��� -   $" Kajplats_1_Alla_Ankarplatser��$��Dock 1��$��Stretch=�$��Stretch=�$	��250��$	��250��$��
15,0,10,10q�$��24(�$
��Bold"�$��Italic$�$��Bahnschrift)�#��� ��.��R� -    R�Name$ MyTreeViewFirst��
�������$��1,1,1,1q�$��Normal$�$��Normal"�$��12(�$	��238��$	��530���� -   $" Kajplats_2_Alla_Ankarplatser��$��Dock 2��$��Stretch=�$��Stretch=�$	��250��$	��250��$��
10,0,15,10q�$��24(�$��Bahnschrift)�$
��Bold"�$��Italic$�#��� ��.��R� -   $ MyTreeViewSecond��
�������$��Normal$�$��Normal"�$��12(�$	��238��$	��530��