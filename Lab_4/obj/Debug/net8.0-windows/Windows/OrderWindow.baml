   M S B A M L   `   `   `  ����	  Lab_4    Lab_4.Windows.OrderWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$+  %Замовлення продукту��5   	   $	��300��6%   $	��400��62    � WindowStartupLocation$ CenterScreen=�6>   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $$��Оберіть продукт:��6   �� 5   
   -   5         ��Name$ ProductsComboBox��5      $��1��6-   $	��0,5q�6:   �� 5   
   $��Кількість:��6   $��2��6&   $��0,10,0,0q�63   �� 5   
   -   5         ��Name$ QuantityBox��5      $��3��6'   $	��0,5q�64   �� 5   
   -   5        $1��+Підтвердити замовлення��5      $��4��62   $��30��6?   $��0,20,0,0q�6K   6]   5      5      