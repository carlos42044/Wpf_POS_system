   M S B A M L   `   `   `  ���� A  =WpfPOS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfPOSWpfPOS      WpfPOS.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:WpfPOS       � Title$  Wpf POS��$��388.367��$	��525�� � ContextMenu �� .@�m� -   $��Settings��.��� .+��� -    ��Name$ nameBtn��$
��Name��$
��Left=�$��	10,10,0,0q�$	��Top=�$��75���� -    ��Name$ pictureBox1��$
��Left=�$��27��$��10,7,0,0q�$	��Top=�$	��120���� -    ��Name$ 	comboBox1��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��120���� -    ��Name$ 	nameLabel��$
��Name��$
��Left=�$��10,7,0,0q�$	��Top=�$��27��$��80��
��������� $
��Left=�$	��269��$��	10,42,0,0q�$	��Top=�$	��478��.@��� $
��Cart��.��� ���	#FFFFFFFF � ColumnDefinitions �� $��16 ��� .+�&   System.Windows.Controls.DataGrid  -     Name$ dataGridView1��$
��Left=�$	��206��$	��Top=�$	��472��$��2��$��0,35,0,0q�   
IsReadOnly . �� -   $ addBtn��$	��Add��$
��Left=�$��40��$��2��	 J� RenderTransformOrigin$	 0.733,1&�$��
0,10,0,211q��� -   $ clearBtn��$��Clear��$��1��$��Right=�$��
0,10,387,0q�$	��Top=�$��40���� $��Trans��.��� ���#FFF.+�  -	   $ dataGridView2��$
��Left=�$	��241��$	��Top=�$	��472���� $��Total��$
��Left=�$��
10,316,0,0q�$	��Top=�
��������� -
   $ 
totalLabel��$
��0.00��$
��Left=�$��
50,316,0,0q�$	��Top=�
��������� -   $ payBtn��$	��Pay��$
��Left=�$��
99,316,0,0q�$	��Top=�$��40��$��26��{�.  �� -   
 ��Name$
 tendered��$
��Left=�$��26��$��153,316,0,0q� �� TextWrapping$
 Wrap=�$
��0.00��$	��Top=�$��65��$��Center=�$y�	Collapsed=�$	 	0.887,0.5&��� -   $ requiredLabel��$��required: 0.00��$
��Left=�$��223,316,0,0q�$	��Top=�
���  ��$	��105��$y�	Collapsed=��� -   $ 
processBtn��$��Process��$
��Left=�$��333,316,0,0q�$	��Top=�$��75��$��26��$y�	Collapsed=��� -   $ 	cancelBtn��$��Cancel��$
��Left=�$��413,316,0,0q�$	��Top=�$��75��$��26��$y�	Collapsed=��� -   $ 	timeLabel��$
��Time��$
��Left=�$��
411,11,0,0q�$	��Top=�$��77��
��������� $��ContentControl��$
��Left=�$��863,-12,-446,0q�$	��Top=�$	��100���� $��CheckBox��$
��Left=�$��-150,311,0,0q�$	��Top=�