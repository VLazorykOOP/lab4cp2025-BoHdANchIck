   M S B A M L   `   `   `  ����	  Lab_4    Lab_4.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$0  *Облік молочних виробів��5   	   $	��450��6(   $	��800��65    � WindowStartupLocation$ CenterScreen=�6A   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ProductsGrid��5      $��0��6)      AutoGenerateColumns$ False��66      
IsReadOnly$
 True��6R      SelectionMode$ Single=�6d   $��0,0,0,10q�6{      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 40 6H   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *Id+6H     5      $ 
Назва��6%   $	 * 6M   
 64   �� *Name+6M     5      $ Категорія��6%   $	 * 6U   
 68   �� *
Category+6U     5      $ Вид��6%   $	 * 6K   
 62   �� *Type+6K     5      $) #Термін придатності��6%   $		 150 6�   
 6A   �� *ExpirationDate+ �� StringFormat$ {0:dd.MM.yyyy}��6�     5      $ Постачальник��6%   $	 * 6X   
 6;   �� *
Supplier+6X     5      $ Ціна��6%   $	 80 6M   
 63   �� *Price+6M   5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,5,0,0q�6W   .+�5      �� -   5        $��Додати��5      $	��100��6&   $��5q�62   6=   �� 5      -   5        $��Редагувати��5      $	��100��6*   $��5q�66   6A   �� 5      -   5        $��
Пошук��5      $	��100��6%   $��5q�61   6<   �� 5      -   5        $��Замовити��5      $	��100��6(   $��5q�64   6?   �� 5      -   5        $��Видалити��5      $	��100��6(   $��5q�64   6?   5      5      5      